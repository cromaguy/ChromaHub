using Microsoft.UI.Xaml;
using System;
using Windows.Storage;

namespace ChromaHub
{
    public partial class App : Application
    {
        private Window m_window;

        public static Window MainWindow { get; private set; }
        public static new App Current => (App)Application.Current;
        public static ElementTheme CurrentTheme { get; set; } = ElementTheme.Default;

        public App()
        {
            this.InitializeComponent();
            LoadThemePreference();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            MainWindow = m_window;
            m_window.Activate();
        }

        public static void SaveThemePreference(ElementTheme theme)
        {
            CurrentTheme = theme;
            ApplicationData.Current.LocalSettings.Values["AppTheme"] = theme.ToString();
        }

        private void LoadThemePreference()
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue("AppTheme", out object themeValue) &&
                    themeValue is string themeName)
                {
                    if (Enum.TryParse(typeof(ElementTheme), themeName, out object themeResult) &&
                        themeResult is ElementTheme theme)
                    {
                        CurrentTheme = theme;
                    }
                }
            }
            catch
            {
                CurrentTheme = ElementTheme.Default;
            }
        }
    }
}