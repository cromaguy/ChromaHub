using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace ChromaHub
{
    public sealed partial class SplashScreen : Page
    {
        // Properties for theme-aware visibility
        public Visibility LightThemeVisibility { get; private set; }
        public Visibility DarkThemeVisibility { get; private set; }

        public SplashScreen()
        {
            this.InitializeComponent();

            // Set initial theme visibility after InitializeComponent
            UpdateThemeVisibility();

            this.Loaded += SplashScreen_Loaded;

            // Listen for theme changes
            this.ActualThemeChanged += SplashScreen_ActualThemeChanged;
        }

        private void SplashScreen_ActualThemeChanged(FrameworkElement sender, object args)
        {
            UpdateThemeVisibility();
        }

        private void UpdateThemeVisibility()
        {
            // Determine which logo to show based on theme
            var currentTheme = this.ActualTheme;
            if (currentTheme == ElementTheme.Default)
            {
                currentTheme = Application.Current.RequestedTheme == ApplicationTheme.Light
                    ? ElementTheme.Light
                    : ElementTheme.Dark;
            }

            // Set visibility based on theme
            LightThemeVisibility = currentTheme == ElementTheme.Light ? Visibility.Visible : Visibility.Collapsed;
            DarkThemeVisibility = currentTheme == ElementTheme.Dark ? Visibility.Visible : Visibility.Collapsed;

            // Only update bindings if component is initialized
            if (LogoImage != null)
            {
                this.Bindings.Update();
            }
        }

        private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
        {

            // Simulate loading resources
            await Task.Delay(2500);

            // Navigate to HomePage after splash screen
            try
            {
                if (App.MainWindow is MainWindow mainWindow)
                {

                    if (mainWindow.AppFrame != null)
                    {
                        mainWindow.NavigateToPage("Home");
                    }
                }
            }
            catch (Exception) { /* Ignore errors accessing NavView */ }
        }

    }
}