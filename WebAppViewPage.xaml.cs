using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;

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
            await ProjectWebView.EnsureCoreWebView2Async();
            ProjectWebView.Source = new Uri(Project.Url);
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
            ProjectWebView.Reload();
        }
    }
}