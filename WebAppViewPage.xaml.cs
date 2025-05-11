using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Media.Animation;

namespace ChromaHub
{
    public sealed partial class WebAppViewPage : Page
    {
        public WebAppProject Project { get; private set; }

        public WebAppViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is WebAppProject project)
            {
                Project = project;
                LoadProject();
            }
        }

        private async void LoadProject()
        {
            StatusText.Text = $"Loading {Project.Title}...";
            StatusProgressRing.IsActive = true;
            LoadingTip.Target = ProjectWebView;
            LoadingTip.IsOpen = true;

            try
            {
                await ProjectWebView.EnsureCoreWebView2Async();

                ProjectWebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
                ProjectWebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                ProjectWebView.CoreWebView2.ProcessFailed += CoreWebView2_ProcessFailed;

                ProjectWebView.Source = new Uri(Project.Url);
            }
            catch (Exception ex)
            {
                StatusText.Text = $"Error: {ex.Message}";
                LoadingTip.IsOpen = false;
                StatusProgressRing.IsActive = false;

                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Error Loading Web App",
                    Content = $"Could not load {Project.Title}. Error: {ex.Message}",
                    CloseButtonText = "Close",
                    XamlRoot = this.XamlRoot
                };

                await errorDialog.ShowAsync();
            }
        }

        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            DispatcherQueue.TryEnqueue(() =>
            {
                StatusText.Text = $"Loading {new Uri(e.Uri).Host}...";
                StatusProgressRing.IsActive = true;
            });
        }

        private void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            DispatcherQueue.TryEnqueue(() =>
            {
                LoadingTip.IsOpen = false;

                if (e.IsSuccess)
                {
                    StatusText.Text = $"Loaded: {Project.Url}";
                }
                else
                {
                    StatusText.Text = $"Error: {e.WebErrorStatus}";
                }

                StatusProgressRing.IsActive = false;
            });
        }

        private void CoreWebView2_ProcessFailed(object sender, CoreWebView2ProcessFailedEventArgs e)
        {
            DispatcherQueue.TryEnqueue(async () =>
            {
                LoadingTip.IsOpen = false;
                StatusText.Text = "Web content process failed";
                StatusProgressRing.IsActive = false;

                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Web Process Failed",
                    Content = $"The web content process for {Project.Title} terminated unexpectedly. You may try reloading the page.",
                    PrimaryButtonText = "Reload",
                    CloseButtonText = "Close",
                    XamlRoot = this.XamlRoot
                };

                var result = await errorDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    ReloadButton_Click(null, null);
                }
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void OpenInBrowserButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri(Project.Url));
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = $"Reloading {Project.Title}...";
            StatusProgressRing.IsActive = true;
            ProjectWebView.Reload();
        }

        private void ShowDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            DetailsTip.Target = sender as FrameworkElement;
            DetailsTip.IsOpen = true;
        }
    }
}