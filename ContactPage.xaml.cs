using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace ChromaHub
{
    public sealed partial class ContactPage : Page
    {
        public List<ContactLinkItem> ContactLinks { get; } = new List<ContactLinkItem>
        {
            new ContactLinkItem { Name = "LinkedIn", IconPath = "ms-appx:///Assets/Icons/linkedin.svg", Url = "https://linkedin.com/in/anjishnu-nandi" },
            new ContactLinkItem { Name = "X", IconPath = "ms-appx:///Assets/Icons/x.svg", Url = "https://x.com/AnjiCroma" },
            new ContactLinkItem { Name = "GitHub", IconPath = "ms-appx:///Assets/Icons/github.svg", Url = "https://github.com/cromaguy" }
        };

        public ContactPage()
        {
            this.InitializeComponent();
        }

        private async void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:anjicroma@gmail.com"));
        }

        private async void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var url = button?.Tag?.ToString();
            if (!string.IsNullOrEmpty(url))
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
        }
    }

    public class ContactLinkItem
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Url { get; set; }
    }
}