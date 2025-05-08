using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace ChromaHub
{
    public sealed partial class SplashScreen : Page
    {
        public SplashScreen()
        {
            this.InitializeComponent();

            Loaded += SplashScreen_Loaded;
        }

        private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            // Simulate loading resources
            await Task.Delay(2000);

            // Navigate to HomePage after splash screen
            if (App.MainWindow != null)
            {
                var mainWindow = App.MainWindow as MainWindow;
                if (mainWindow != null && mainWindow.AppFrame != null)
                {
                    mainWindow.NavigateToPage("Home");
                }
            }
        }
    }
}