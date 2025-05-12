using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;

namespace ChromaHub
{
    public sealed partial class SettingsPage : Page
    {
        private const string THEME_SETTING = "AppTheme";
        private const string BACKDROP_SETTING = "BackdropType";
        private const string ANIMATIONS_SETTING = "EnableAnimations";

        public SettingsPage()
        {
            this.InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                ElementTheme currentTheme = App.CurrentTheme;
                switch (currentTheme)
                {
                    case ElementTheme.Light:
                        ThemeRadioButtons.SelectedIndex = 0;
                        break;
                    case ElementTheme.Dark:
                        ThemeRadioButtons.SelectedIndex = 1;
                        break;
                    default:
                        ThemeRadioButtons.SelectedIndex = 2;
                        break;
                }

                var backdropSetting = GetSetting(BACKDROP_SETTING, "Mica");
                BackdropRadioButtons.SelectedIndex = backdropSetting == "Mica" ? 0 : 1;

                bool enableAnimations = GetSetting(ANIMATIONS_SETTING, "True") == "True";
                EnableAnimationsToggle.IsOn = enableAnimations;
            }
            catch
            {
                SetDefaultSettings();
            }
        }

        private void SetDefaultSettings()
        {
            ThemeRadioButtons.SelectedIndex = 2;
            BackdropRadioButtons.SelectedIndex = 0;
            EnableAnimationsToggle.IsOn = true;
        }

        private void ThemeRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeRadioButtons.SelectedItem is RadioButton rb && rb.Tag is string tag)
            {
                ElementTheme selectedTheme = ElementTheme.Default;

                switch (tag)
                {
                    case "Light":
                        selectedTheme = ElementTheme.Light;
                        break;
                    case "Dark":
                        selectedTheme = ElementTheme.Dark;
                        break;
                    case "Default":
                        selectedTheme = ElementTheme.Default;
                        break;
                }

                ApplyTheme(selectedTheme);
            }
        }

        private void BackdropRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BackdropRadioButtons.SelectedItem is RadioButton rb && rb.Tag is string backdropType)
            {
                if (backdropType == "Solid" && App.CurrentTheme == ElementTheme.Default)
                {
                    ApplyTheme(Application.Current.RequestedTheme == ApplicationTheme.Light
                        ? ElementTheme.Light
                        : ElementTheme.Dark);
                }

                SaveSetting(BACKDROP_SETTING, backdropType);
                ApplyBackdropChange(backdropType);
            }
        }

        private void EnableAnimationsToggle_Toggled(object sender, RoutedEventArgs e)
        {
            bool enableAnimations = EnableAnimationsToggle.IsOn;
            SaveSetting(ANIMATIONS_SETTING, enableAnimations.ToString());
            ApplyAnimationSettings(enableAnimations);

            ShowAnimationInfoBar();
        }

        private async void ShowAnimationInfoBar()
        {
            if (AnimationInfoBar == null) return;

            AnimationInfoBar.Message = EnableAnimationsToggle.IsOn ?
                "Animations enabled for better visual experience" :
                "Animations disabled for performance optimization";

            AnimationInfoBar.IsOpen = true;

            await Task.Delay(3000);

            if (AnimationInfoBar != null)
            {
                AnimationInfoBar.IsOpen = false;
            }
        }

        private void ApplyTheme(ElementTheme theme)
        {
            App.SaveThemePreference(theme);

            if (App.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ApplyTheme(theme);
            }
        }

        private void ApplyBackdropChange(string backdropType)
        {
            if (App.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ApplyBackdrop(backdropType);
            }
        }

        private void ApplyAnimationSettings(bool enableAnimations)
        {
            if (App.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ApplyAnimationSettings(enableAnimations);
            }
        }

        private async Task<string> GetLatestReleaseDownloadUrlAsync()
        {
            const string apiUrl = "https://api.github.com/repos/cromaguy/ChromaHub/releases/latest";
            using var httpClient = new HttpClient();

            // Add a User-Agent header (required by GitHub API)
            httpClient.DefaultRequestHeaders.Add("User-Agent", "ChromaHub");

            try
            {
                var response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"GitHub API Response: {json}");

                var release = System.Text.Json.JsonDocument.Parse(json);

                // Find the .msix asset in the release
                foreach (var asset in release.RootElement.GetProperty("assets").EnumerateArray())
                {
                    var assetName = asset.GetProperty("name").GetString();
                    var downloadUrl = asset.GetProperty("browser_download_url").GetString();

                    System.Diagnostics.Debug.WriteLine($"Asset Found: {assetName}, URL: {downloadUrl}");

                    if (assetName.EndsWith(".msix"))
                    {
                        return downloadUrl;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error fetching release: {ex.Message}");
            }

            return null;
        }



        private async void CheckForUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var downloadUrl = await GetLatestReleaseDownloadUrlAsync();
                if (string.IsNullOrEmpty(downloadUrl))
                {
                    // Show an error message if no update is found
                    var dialog = new ContentDialog
                    {
                        Title = "No Updates Found",
                        Content = "Could not find a new update. Please check manually.",
                        CloseButtonText = "OK",
                        XamlRoot = this.XamlRoot
                    };
                    await dialog.ShowAsync();
                    return;
                }

                // Download the .msix file
                var file = await Windows.Storage.DownloadsFolder.CreateFileAsync("ChromaHub_Update.msix", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                using (var httpClient = new HttpClient())
                using (var stream = await httpClient.GetStreamAsync(downloadUrl))
                using (var fileStream = await file.OpenStreamForWriteAsync())
                {
                    await stream.CopyToAsync(fileStream);
                }

                // Launch the installer
                var success = await Windows.System.Launcher.LaunchFileAsync(file);
                if (!success)
                {
                    var dialog = new ContentDialog
                    {
                        Title = "Installation Failed",
                        Content = "The update could not be installed. Please try again.",
                        CloseButtonText = "OK",
                        XamlRoot = this.XamlRoot
                    };
                    await dialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception and show an error dialog
                System.Diagnostics.Debug.WriteLine($"Error during update check: {ex.Message}");
                var dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = $"An error occurred while checking for updates: {ex.Message}",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();
            }
        }
        private void ResetSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowResetConfirmation();
        }

        private async void ShowResetConfirmation()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Reset settings?",
                Content = "This will reset all settings to their default values. Your personal data won't be affected.",
                PrimaryButtonText = "Reset",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.XamlRoot
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                ResetAllSettings();
            }
        }

        private void ResetAllSettings()
        {
            try
            {
                ApplicationData.Current.LocalSettings.Values.Remove(THEME_SETTING);
                ApplicationData.Current.LocalSettings.Values.Remove(BACKDROP_SETTING);
                ApplicationData.Current.LocalSettings.Values.Remove(ANIMATIONS_SETTING);

                App.SaveThemePreference(ElementTheme.Default);
                SaveSetting(BACKDROP_SETTING, "Mica");
                SaveSetting(ANIMATIONS_SETTING, "True");

                LoadCurrentSettings();

                ApplyTheme(ElementTheme.Default);
                ApplyBackdropChange("Mica");
                ApplyAnimationSettings(true);
            }
            catch (Exception)
            {
                // Handle errors silently
            }
        }

        private void UpdateApplicationAnimations(bool enable)
        {
            if (App.Current.Resources.TryGetValue("ContentPageTransitionDuration", out object durationObj))
            {
                var resources = App.Current.Resources;

                if (enable)
                {
                    resources["ContentPageTransitionDuration"] = TimeSpan.FromMilliseconds(300);

                    if (App.MainWindow is MainWindow mainWindow)
                    {
                        var rootGrid = mainWindow.Content as Grid;
                        if (rootGrid != null && rootGrid.FindName("NavView") is NavigationView navView)
                        {
                            if (navView.Content is Grid contentGrid &&
                                contentGrid.FindName("ContentFrame") is Frame contentFrame)
                            {
                                contentFrame.ContentTransitions = new Microsoft.UI.Xaml.Media.Animation.TransitionCollection
                                {
                                    new Microsoft.UI.Xaml.Media.Animation.NavigationThemeTransition()
                                };
                            }
                        }
                    }
                }
                else
                {
                    resources["ContentPageTransitionDuration"] = TimeSpan.FromMilliseconds(0);

                    if (App.MainWindow is MainWindow mainWindow)
                    {
                        var rootGrid = mainWindow.Content as Grid;
                        if (rootGrid != null && rootGrid.FindName("NavView") is NavigationView navView)
                        {
                            if (navView.Content is Grid contentGrid &&
                                contentGrid.FindName("ContentFrame") is Frame contentFrame)
                            {
                                contentFrame.ContentTransitions = null;
                            }
                        }
                    }
                }
            }
            else
            {
                App.Current.Resources["ContentPageTransitionDuration"] =
                    enable ? TimeSpan.FromMilliseconds(300) : TimeSpan.FromMilliseconds(0);
            }
        }

        private string GetSetting(string key, string defaultValue)
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key, out object value) &&
                    value is string stringValue)
                {
                    return stringValue;
                }
            }
            catch { }
            return defaultValue;
        }

        private void SaveSetting(string key, string value)
        {
            try
            {
                ApplicationData.Current.LocalSettings.Values[key] = value;
            }
            catch { }
        }
    }
}
