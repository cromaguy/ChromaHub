using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace ChromaHub
{
    public sealed partial class HomePage : Page
    {
        public List<SocialLinkItem> SocialLinks { get; } = new List<SocialLinkItem>
        {
            // Updated with proper Unicode icons for social platforms
            new SocialLinkItem { Name = "LinkedIn", Icon = "\uE774", Url = "https://linkedin.com/in/anjishnu-nandi" },
            new SocialLinkItem { Name = "Twitter", Icon = "\uE8AC", Url = "https://twitter.com/AnjiCroma" },
            new SocialLinkItem { Name = "GitHub", Icon = "\uEA0A", Url = "https://github.com/cromaguy" },
            new SocialLinkItem { Name = "Instagram", Icon = "\uE7AA", Url = "https://instagram.com/its.chroma.anji" }
        };

        public HomePage()
        {
            this.InitializeComponent();

            // Set up scroll event - using null checking to fix CS0120 error
            if (ScrollViewer != null)
            {
                ScrollViewer.ViewChanged += ScrollViewer_ViewChanged;
            }
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            // Show/hide back to top button based on scroll position
            if (BackToTopButton != null && ScrollViewer != null)
            {
                BackToTopButton.Visibility = ScrollViewer.VerticalOffset > 300 ?
                    Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void ViewWorkButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to projects page
            if (App.MainWindow != null)
            {
                var mainWindow = App.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.NavigateToPage("Projects");
                }
            }
        }

        private async void ViewProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var url = button?.Tag?.ToString();
            if (!string.IsNullOrEmpty(url))
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
            }
        }

        private void SeeAllProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            // Fixed navigation to projects page
            if (App.MainWindow != null)
            {
                var mainWindow = App.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.NavigateToPage("Projects");
                }
            }
        }

        private async void SocialButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var url = button?.Tag?.ToString();
            if (!string.IsNullOrEmpty(url))
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
            }
        }

        private async void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:anjicroma@gmail.com"));
        }

        private void BackToTopButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer?.ChangeView(null, 0, null, true);
        }
    }

    public class SocialLinkItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}