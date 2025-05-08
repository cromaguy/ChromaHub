using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Storage;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Automation;

namespace ChromaHub
{
    public sealed partial class SettingsPage : Page
    {
        // Constant key strings for settings
        private const string THEME_SETTING = "AppTheme";
        private const string BACKDROP_SETTING = "BackdropType";
        private const string ANIMATIONS_SETTING = "EnableAnimations";

        public SettingsPage()
        {
            this.InitializeComponent();

            // Load current settings to UI
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                // Load theme setting
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

                // Load backdrop setting
                var backdropSetting = GetSetting(BACKDROP_SETTING, "Mica");
                BackdropRadioButtons.SelectedIndex = backdropSetting == "Mica" ? 0 : 1;

                // Load animations setting
                bool enableAnimations = GetSetting(ANIMATIONS_SETTING, "True") == "True";
                EnableAnimationsToggle.IsOn = enableAnimations;
            }
            catch (Exception)
            {
                // Recover gracefully if settings fail to load
                SetDefaultSettings();
            }
        }

        private void SetDefaultSettings()
        {
            ThemeRadioButtons.SelectedIndex = 2; // Default theme
            BackdropRadioButtons.SelectedIndex = 0; // Mica backdrop
            EnableAnimationsToggle.IsOn = true; // Enable animations
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

                // Apply and save theme
                ApplyTheme(selectedTheme);
            }
        }

        private void BackdropRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BackdropRadioButtons.SelectedItem is RadioButton rb && rb.Tag is string backdropType)
            {
                // Save backdrop preference
                SaveSetting(BACKDROP_SETTING, backdropType);

                // Apply backdrop change
                ApplyBackdropChange(backdropType);
            }
        }

        private void EnableAnimationsToggle_Toggled(object sender, RoutedEventArgs e)
        {
            bool enableAnimations = EnableAnimationsToggle.IsOn;
            SaveSetting(ANIMATIONS_SETTING, enableAnimations.ToString());
            ApplyAnimationSettings(enableAnimations);
        }

        private void ResetSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirm reset
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
            // Clear all settings
            try
            {
                ApplicationData.Current.LocalSettings.Values.Remove(THEME_SETTING);
                ApplicationData.Current.LocalSettings.Values.Remove(BACKDROP_SETTING);
                ApplicationData.Current.LocalSettings.Values.Remove(ANIMATIONS_SETTING);

                // Apply default settings
                App.SaveThemePreference(ElementTheme.Default);
                SaveSetting(BACKDROP_SETTING, "Mica");
                SaveSetting(ANIMATIONS_SETTING, "True");

                // Reload UI
                LoadCurrentSettings();

                // Apply changes to window
                ApplyTheme(ElementTheme.Default);
                ApplyBackdropChange("Mica");
                ApplyAnimationSettings(true);
            }
            catch (Exception)
            {
                // Handle reset errors gracefully
            }
        }

        private void ApplyTheme(ElementTheme theme)
        {
            // Save theme preference
            App.SaveThemePreference(theme);

            // Apply theme to window
            if (App.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ApplyTheme(theme);
            }
        }

        private void ApplyBackdropChange(string backdropType)
        {
            // Apply backdrop to window
            if (App.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ApplyBackdrop(backdropType);
            }
        }

        private void ApplyAnimationSettings(bool enableAnimations)
        {
            // This could be expanded to actually toggle animations in the app
            // For now, we just save the setting
        }

        #region Settings Helpers

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

        #endregion
    }
}