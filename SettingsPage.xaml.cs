using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
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
            catch (Exception)
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
            if (AnimationInfoBar == null)
            {
                return;
            }

            AnimationInfoBar.Message = EnableAnimationsToggle.IsOn ?
                "Animations enabled for better visual experience" :
                "Animations disabled for performance optimization";

            AnimationInfoBar.IsOpen = true;

            await System.Threading.Tasks.Task.Delay(3000);

            if (AnimationInfoBar != null)
            {
                AnimationInfoBar.IsOpen = false;
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
            UpdateApplicationAnimations(enableAnimations);
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