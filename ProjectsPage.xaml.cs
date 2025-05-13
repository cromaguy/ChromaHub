using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Input;

namespace ChromaHub
{
    public sealed partial class ProjectsPage : Page
    {
        // Main projects collection
        public List<ProjectItem> Projects { get; } = new List<ProjectItem>
        {
            new ProjectItem
            {
                Title = "Project NewAngle",
                Description = "An intelligent chat assistant built with Gemini 1.5 Flash that provides conversational AI capabilities with state-of-the-art response quality.",
                ImageUrl = "ms-appx:///Assets/NewAngle.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS", "Gemini 1.5 Flash" },
                LiveUrl = "https://new-angle.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-NewAngle"
            },
            new ProjectItem
            {
                Title = "Project Feel",
                Description = "A modern, responsive weather app that provides real-time weather updates, a 5-day forecast, and auto-location detection with beautiful UI visualizations.",
                ImageUrl = "ms-appx:///Assets/Feel.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS", "Open Weather API" },
                LiveUrl = "https://feel-one.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-Feel"
            },
            new ProjectItem
            {
                Title = "Project GoalGuru",
                Description = "A goal tracking application designed to help users set, track, and achieve their personal and professional goals with intuitive metrics and progress visualization.",
                ImageUrl = "ms-appx:///Assets/GoalGuru.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS" },
                LiveUrl = "https://goal-guru-theta.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-GoalGuru"
            },
            new ProjectItem
            {
                Title = "Project Quizzy",
                Description = "An interactive quiz platform for students and educators, featuring customizable assessments and real-time feedback mechanisms to enhance the learning experience.",
                ImageUrl = "ms-appx:///Assets/Quizzy.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS" },
                LiveUrl = "https://quizzy-dusky.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-Quizzy"
            },
            new ProjectItem
            {
                Title = "StudySkill (2024)",
                Description = "A comprehensive College Management System designed to streamline administrative and academic tasks with modern UX principles and responsive design.",
                ImageUrl = "ms-appx:///Assets/StudySkill.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS", "PHP" },
                LiveUrl = "https://cromaguy.github.io/StudySkill/index.html",
                GithubUrl = "https://github.com/cromaguy/StudySkill"
            },
            new ProjectItem
            {
                Title = "StudySkill Re",
                Description = "StudySkill is a comprehensive digital platform designed to streamline academic processes, enhance communication, and provide real-time insights for students, faculty, and administrators.",
                ImageUrl = "ms-appx:///Assets/StudySkill.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS" },
                LiveUrl = "https://studyskill.vercel.app/",
                GithubUrl = ""
            }
        };

        // Observable collection for the filtered projects
        public ObservableCollection<ProjectItem> FilteredProjects { get; } = new ObservableCollection<ProjectItem>();

        public ProjectsPage()
        {
            this.InitializeComponent();

            // Initialize filtered projects with all projects
            this.Loaded += ProjectsPage_Loaded;

            // Set up pointer events for project items
            ProjectsRepeater.ElementPrepared += ProjectsRepeater_ElementPrepared;
        }

        private void ProjectsPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize combo box
                FilterComboBox.SelectedIndex = 0;

                // Populate all projects
                RefreshProjectsList();

                // Animate header elements more safely
                SafeAnimateHeaderElements();
            }
            catch (Exception ex)
            {
                // Log error or show a message
                System.Diagnostics.Debug.WriteLine($"Error in ProjectsPage_Loaded: {ex.Message}");
            }
        }

        private void SafeAnimateHeaderElements()
        {
            // Safer animation that targets specific elements directly
            var elementsToAnimate = new List<FrameworkElement>();

            // Add rectangle accent element
            var accentRect = this.FindName("AccentRect") as FrameworkElement;
            if (accentRect != null) elementsToAnimate.Add(accentRect);

            // Get TextBlocks within the header area
            var headerStack = VisualTreeHelper.GetChild(this, 0) as DependencyObject;
            if (headerStack != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(headerStack); i++)
                {
                    var child = VisualTreeHelper.GetChild(headerStack, i) as DependencyObject;
                    if (child != null)
                    {
                        var textBlocks = FindChildren<TextBlock>(child);
                        foreach (var textBlock in textBlocks)
                        {
                            elementsToAnimate.Add(textBlock);
                        }
                    }
                }
            }

            // Animate each element with a delay
            int delay = 100;
            foreach (var element in elementsToAnimate)
            {
                try
                {
                    element.Opacity = 0;
                    var anim = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = new Duration(TimeSpan.FromMilliseconds(400)),
                        BeginTime = TimeSpan.FromMilliseconds(delay)
                    };

                    Storyboard.SetTarget(anim, element);
                    Storyboard.SetTargetProperty(anim, "Opacity");

                    var sb = new Storyboard();
                    sb.Children.Add(anim);
                    sb.Begin();

                    delay += 150;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Animation error: {ex.Message}");
                    element.Opacity = 1; // Ensure visibility even if animation fails
                }
            }
        }

        private List<T> FindChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            var results = new List<T>();

            try
            {
                int childCount = VisualTreeHelper.GetChildrenCount(parent);

                for (int i = 0; i < childCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);

                    if (child is T childAsT)
                    {
                        results.Add(childAsT);
                    }

                    results.AddRange(FindChildren<T>(child));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error finding children: {ex.Message}");
            }

            return results;
        }

        private void ProjectsRepeater_ElementPrepared(ItemsRepeater sender, ItemsRepeaterElementPreparedEventArgs args)
        {
            try
            {
                // Add hover effects to each project card
                if (args.Element is Grid projectGrid)
                {
                    // Find the highlight border
                    var highlightBorder = FindChildByName<Border>(projectGrid, "HighlightBorder");

                    // Get the project data
                    var itemIndex = args.Index;
                    if (itemIndex >= 0 && itemIndex < FilteredProjects.Count)
                    {
                        // Set the project as the grid's DataContext (in case it's not already set)
                        projectGrid.DataContext = FilteredProjects[itemIndex];

                        // Add tap event handler directly to ensure navigation works
                        projectGrid.Tapped -= ProjectItem_Tapped; // Remove any previous handlers
                        projectGrid.Tapped += ProjectItem_Tapped;
                    }

                    // Add pointer events
                    projectGrid.PointerEntered += (s, e) => {
                        try
                        {
                            if (highlightBorder != null)
                                highlightBorder.Opacity = 0.6;

                            // Slight elevation effect
                            projectGrid.Translation = new System.Numerics.Vector3(0, -8, 0);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"PointerEntered error: {ex.Message}");
                        }
                    };

                    projectGrid.PointerExited += (s, e) => {
                        try
                        {
                            if (highlightBorder != null)
                                highlightBorder.Opacity = 0;

                            // Reset elevation
                            projectGrid.Translation = new System.Numerics.Vector3(0, 0, 0);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"PointerExited error: {ex.Message}");
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ProjectsRepeater_ElementPrepared: {ex.Message}");
            }
        }

        private T FindChildByName<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            try
            {
                // Find a child element by name
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    if (child is FrameworkElement fe && fe.Name == childName && child is T typedChild)
                        return typedChild;

                    var result = FindChildByName<T>(child, childName);
                    if (result != null)
                        return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FindChildByName error: {ex.Message}");
            }

            return null;
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RefreshProjectsList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FilterComboBox error: {ex.Message}");
            }
        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            try
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    RefreshProjectsList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchBox error: {ex.Message}");
            }
        }

        private void RefreshProjectsList()
        {
            try
            {
                FilteredProjects.Clear();

                // Get filter tag
                string filterTag = (FilterComboBox.SelectedItem as ComboBoxItem)?.Tag?.ToString() ?? "All";

                // Get search text
                string searchText = SearchBox.Text?.ToLower() ?? string.Empty;

                // Apply filters
                var filteredList = Projects.Where(p =>
                    // Apply technology filter
                    (filterTag == "All" || p.Technologies.Any(t => t.Contains(filterTag))) &&

                    // Apply search filter
                    (string.IsNullOrEmpty(searchText) ||
                     p.Title.ToLower().Contains(searchText) ||
                     p.Description.ToLower().Contains(searchText))
                ).ToList();

                // Add filtered projects
                foreach (var project in filteredList)
                {
                    FilteredProjects.Add(project);
                }

                // Show/hide empty state
                EmptyStateGrid.Visibility = FilteredProjects.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RefreshProjectsList error: {ex.Message}");

                // Recovery: Add all projects
                foreach (var project in Projects)
                {
                    if (!FilteredProjects.Contains(project))
                    {
                        FilteredProjects.Add(project);
                    }
                }

                EmptyStateGrid.Visibility = Visibility.Collapsed;
            }
        }

        private async void ViewLiveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var url = button?.Tag?.ToString();

                if (!string.IsNullOrEmpty(url))
                {
                    await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ViewLiveButton error: {ex.Message}");
            }
        }

        private async void ViewSourceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var url = button?.Tag?.ToString();

                if (!string.IsNullOrEmpty(url))
                {
                    await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ViewSourceButton error: {ex.Message}");
            }
        }

        private void ShowAllProjects_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Reset filters
                FilterComboBox.SelectedIndex = 0;
                SearchBox.Text = string.Empty;
                RefreshProjectsList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ShowAllProjects error: {ex.Message}");
            }
        }

        private void ProjectItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("ProjectItem_Tapped event triggered");

                // Method 1: Get project from DataContext
                if (sender is FrameworkElement element && element.DataContext is ProjectItem project)
                {
                    System.Diagnostics.Debug.WriteLine($"Navigating to AppInfoPage for project: {project.Title}");
                    e.Handled = true;
                    Frame.Navigate(typeof(AppInfoPage), project, new DrillInNavigationTransitionInfo());
                    return;
                }

                // Method 2: Find project by searching through visual tree
                if (sender is Grid projectGrid)
                {
                    // Try to determine which project this is from its index
                    var container = ProjectsRepeater.TryGetElement(ProjectsRepeater.GetElementIndex(projectGrid));
                    if (container != null)
                    {
                        int index = ProjectsRepeater.GetElementIndex(container);
                        if (index >= 0 && index < FilteredProjects.Count)
                        {
                            var selectedProject = FilteredProjects[index];
                            System.Diagnostics.Debug.WriteLine($"Found project by index: {selectedProject.Title}");
                            e.Handled = true;
                            Frame.Navigate(typeof(AppInfoPage), selectedProject, new DrillInNavigationTransitionInfo());
                            return;
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("Failed to find project from tapped element");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ProjectItem_Tapped error: {ex.Message}");
            }
        }
    }

    public class ProjectItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Technologies { get; set; } = new List<string>();
        public string LiveUrl { get; set; }
        public string GithubUrl { get; set; }

        public bool HasLiveUrl => !string.IsNullOrEmpty(LiveUrl);
        public bool HasGithubUrl => !string.IsNullOrEmpty(GithubUrl);
    }
}