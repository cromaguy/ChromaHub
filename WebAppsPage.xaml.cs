using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace ChromaHub
{
    public sealed partial class WebAppsPage : Page
    {
        public List<WebAppProject> WebApps { get; } = WebAppProject.GetWebApps();

        public WebAppsPage()
        {
            this.InitializeComponent();
        }

        private void OpenInAppButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var project = button?.Tag as WebAppProject;

            if (project != null)
            {
                Frame.Navigate(typeof(WebAppViewPage), project);
            }
        }

        private async void OpenInBrowserButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var url = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(url))
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
            }
        }
    }
}