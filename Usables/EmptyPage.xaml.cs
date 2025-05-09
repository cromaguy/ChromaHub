using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

namespace ChromaHub
{
    /// <summary>
    /// An enhanced empty page template with modern UI design elements.
    /// </summary>
    public sealed partial class EmptyPage : Page
    {
        public EmptyPage()
        {
            this.InitializeComponent();
            Loaded += EmptyPage_Loaded;

            // Set up button click handlers
            PrimaryActionButton.Click += PrimaryActionButton_Click;
            SecondaryActionButton.Click += SecondaryActionButton_Click;
        }

        private void EmptyPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Simulate initial loading effect if desired
            // ShowLoading(true);
            // 
            // var timer = new DispatcherTimer();
            // timer.Interval = TimeSpan.FromSeconds(1.5);
            // timer.Tick += (s, args) => {
            //     timer.Stop();
            //     ShowLoading(false);
            // };
            // timer.Start();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Handle navigation parameters if needed
            if (e.Parameter != null)
            {
                // Process parameter
            }
        }

        private void PrimaryActionButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle primary action button click
            // For example, show a dialog
            ShowSampleDialog();
        }

        private void SecondaryActionButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle secondary action button click
        }

        private async void ShowSampleDialog()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Welcome to your new page",
                Content = "This is a sample dialog demonstrating the interactive elements of this template. You can customize it to suit your needs.",
                CloseButtonText = "Cancel",
                PrimaryButtonText = "OK",
                DefaultButton = ContentDialogButton.Primary,
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }

        // Show or hide loading indicator with animation
        private void ShowLoading(bool isLoading)
        {
            if (LoadingIndicator != null)
            {
                if (isLoading)
                {
                    LoadingIndicator.Opacity = 0;
                    LoadingIndicator.Visibility = Visibility.Visible;

                    // Animate fade in
                    var fadeIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 0.9,
                        Duration = new Duration(TimeSpan.FromMilliseconds(300))
                    };

                    Storyboard.SetTarget(fadeIn, LoadingIndicator);
                    Storyboard.SetTargetProperty(fadeIn, "Opacity");

                    var storyboard = new Storyboard();
                    storyboard.Children.Add(fadeIn);
                    storyboard.Begin();
                }
                else
                {
                    // Animate fade out
                    var fadeOut = new DoubleAnimation
                    {
                        From = LoadingIndicator.Opacity,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromMilliseconds(300))
                    };

                    Storyboard.SetTarget(fadeOut, LoadingIndicator);
                    Storyboard.SetTargetProperty(fadeOut, "Opacity");

                    var storyboard = new Storyboard();
                    storyboard.Children.Add(fadeOut);
                    storyboard.Completed += (s, e) => LoadingIndicator.Visibility = Visibility.Collapsed;
                    storyboard.Begin();
                }
            }
        }

        // Add your page's methods here
    }
}