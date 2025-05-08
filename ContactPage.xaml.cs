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
            new ContactLinkItem { Name = "LinkedIn", Icon = "\uF3FC", Url = "https://linkedin.com/in/anjishnu-nandi" },
            new ContactLinkItem { Name = "Twitter", Icon = "\uF5B6", Url = "https://twitter.com/AnjiCroma" },
            new ContactLinkItem { Name = "GitHub", Icon = "\uF3EB", Url = "https://github.com/cromaguy" }
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
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
            }
        }
    }

    public class ContactLinkItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}