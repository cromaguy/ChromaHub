using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Media.Animation;

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
                Frame.Navigate(typeof(WebAppViewPage), project, new DrillInNavigationTransitionInfo());
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

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is WebAppProject project)
            {
                Frame.Navigate(typeof(WebAppViewPage), project, new DrillInNavigationTransitionInfo());
            }
        }
    }
}