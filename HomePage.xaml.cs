using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Media.Animation;
using System.Linq;

namespace ChromaHub
{
    public sealed partial class HomePage : Page
    {
        public ObservableCollection<QuickLinkItem> QuickLinks { get; } = new ObservableCollection<QuickLinkItem>();

        // Remove RecentProjects collection

        // Add a property to store the featured project
        public WebAppProject FeaturedProject { get; private set; }

        // New property for recent projects that will fetch data from ProjectsPage
        public ObservableCollection<ProjectItem> RecentProjects { get; } = new ObservableCollection<ProjectItem>();

        public HomePage()
        {
            this.InitializeComponent();

            // Initialize the featured project
            FeaturedProject = new WebAppProject
            {
                Title = "StudySkill Re",
                Description = "An innovative learning platform designed to enhance study productivity with AI-powered tools and streamlined note-taking capabilities.",
                Url = "https://studyskill.vercel.app/",
                ImageUrl = "ms-appx:///Assets/StudySkill.png",
                Technologies = new List<string> { "React", "Node.js", "MongoDB" }
            };

            // Initialize Quick Links
            QuickLinks.Add(new QuickLinkItem { Title = "Projects", Icon = "\uE8A5", Tag = "Projects" });
            QuickLinks.Add(new QuickLinkItem { Title = "About Me", Icon = "\uE77B", Tag = "About" });
            QuickLinks.Add(new QuickLinkItem { Title = "Contact", Icon = "\uE715", Tag = "Contact" });
            QuickLinks.Add(new QuickLinkItem { Title = "Web Apps", Icon = "\uE774", Tag = "WebApps" });

            // Load recent projects from ProjectsPage data
            LoadRecentProjects();
        }

        // New method to fetch and load recent projects from ProjectsPage
        private void LoadRecentProjects()
        {
            try
            {
                // Get projects from ProjectsPage
                var projectsPage = new ProjectsPage();

                // Take the 3 most recent projects
                var recentItems = projectsPage.Projects
                    .Take(3)  // Take only 3 most recent projects
                    .ToList();

                // Clear and add to our collection
                RecentProjects.Clear();
                foreach (var project in recentItems)
                {
                    RecentProjects.Add(project);
                }

                // Set up binding for Recent Projects repeater in the XAML
                RecentProjectsRepeater.ItemsSource = RecentProjects;
            }
            catch (Exception ex)
            {
                // Handle any errors
                System.Diagnostics.Debug.WriteLine($"Error loading recent projects: {ex.Message}");
            }
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string destination)
            {
                // In WinUI 3, we need to use this approach instead of Window.Current
                Frame rootFrame = this.Frame;
                if (rootFrame != null)
                {
                    // Try to navigate using the tag as the page name
                    Type pageType = Type.GetType($"ChromaHub.{destination}Page");
                    if (pageType != null)
                    {
                        rootFrame.Navigate(pageType, null);
                    }
                }
            }
        }

        private void ViewAllProjects_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = this.Frame;
            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(ProjectsPage), null);
            }
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = this.Frame;
            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(ContactPage), null);
            }
        }

        // Add method for the featured project view button
        private void ViewFeaturedProject_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag?.ToString() == "StudySkillRe")
            {
                Frame.Navigate(typeof(WebAppViewPage), FeaturedProject, new DrillInNavigationTransitionInfo());
            }
        }

        // Add method for the source code button
        private async void ViewSourceCode_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string repoUrl = button.Tag?.ToString();
                if (!string.IsNullOrEmpty(repoUrl))
                {
                    await Windows.System.Launcher.LaunchUriAsync(new Uri(repoUrl));
                }
            }
        }

        // New method to handle viewing a project's details
        private void ViewProject_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is ProjectItem project)
            {
                // Navigate to project details page or handle as needed
                // For example, you might convert the ProjectItem to a WebAppProject or use another approach
                Frame.Navigate(typeof(WebAppViewPage), new WebAppProject
                {
                    Title = project.Title,
                    Description = project.Description,
                    Url = project.LiveUrl,
                    ImageUrl = project.ImageUrl,
                    Technologies = project.Technologies
                }, new DrillInNavigationTransitionInfo());
            }
        }
    }

    public class QuickLinkItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Tag { get; set; }
    }

    // Remove RecentProjectItem class as we'll use ProjectItem from ProjectsPage directly
}