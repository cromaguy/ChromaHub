using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChromaHub
{
    public sealed partial class AppInfoPage : Page
    {
        public ProjectItem CurrentProject { get; private set; }
        private ObservableCollection<string> Features { get; } = new ObservableCollection<string>();
        private HttpClient httpClient = new HttpClient();

        public AppInfoPage()
        {
            this.InitializeComponent();
            this.Loaded += AppInfoPage_Loaded;
        }

        private void AppInfoPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Set up feature items
            FeaturesRepeater.ItemsSource = Features;

            // Apply animations
            AnimatePageElements();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is ProjectItem project)
            {
                // Set current project
                CurrentProject = project;

                // Set hero background with blur effect
                if (!string.IsNullOrEmpty(CurrentProject.ImageUrl))
                {
                    // Create a blurred background from project image
                    HeroBackground.ImageSource = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage(new Uri(CurrentProject.ImageUrl));
                }

                // Ensure screenshot displays correctly
                //Screenshot1.Source = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage(new Uri(CurrentProject.ImageUrl));

                // Load project-specific features
                LoadProjectFeatures();
            }
            else
            {
                // Log the incorrect parameter type for debugging
                System.Diagnostics.Debug.WriteLine($"Error: Parameter passed to AppInfoPage is not a ProjectItem. Type: {e.Parameter?.GetType().FullName ?? "null"}");
            }
        }

        private void LoadProjectFeatures()
        {
            Features.Clear();

            // Add generic and project-specific features
            Features.Add("Modern UI interface with intuitive navigation");
            Features.Add("Responsive design for all device sizes");

            // Add features based on technologies
            if (CurrentProject.Technologies != null)
            {
                if (CurrentProject.Technologies.Contains("JavaScript"))
                {
                    Features.Add("Built with modern JavaScript for optimal performance");
                }

                if (CurrentProject.Technologies.Contains("HTML") || CurrentProject.Technologies.Contains("CSS"))
                {
                    Features.Add("Utilizes the latest web standards for a seamless experience");
                }

                if (CurrentProject.Technologies.Contains("API"))
                {
                    Features.Add("Integrates with external APIs for enhanced functionality");
                }

                if (CurrentProject.Technologies.Contains("Gemini 1.5 Flash"))
                {
                    Features.Add("Powered by Gemini 1.5 Flash for AI-driven conversational capabilities");
                }

                if (CurrentProject.Technologies.Contains("Open Weather API"))
                {
                    Features.Add("Real-time weather data with accurate forecasting");
                }

                if (CurrentProject.Technologies.Contains("PHP"))
                {
                    Features.Add("Backend processing for secure and efficient data management");
                }
            }

            // Add project-specific features based on title
            if (CurrentProject.Title.Contains("NewAngle"))
            {
                Features.Add("Advanced natural language processing capabilities");
                Features.Add("Multi-turn conversations with context awareness");
            }
            else if (CurrentProject.Title.Contains("Feel"))
            {
                Features.Add("Location-based weather forecasting");
                Features.Add("Visual representation of weather conditions");
                Features.Add("5-day forecast with hourly breakdowns");
            }
            else if (CurrentProject.Title.Contains("GoalGuru"))
            {
                Features.Add("Goal tracking with progress visualization");
                Features.Add("Customizable reminders and notifications");
                Features.Add("Achievement system for added motivation");
            }
            else if (CurrentProject.Title.Contains("Quizzy"))
            {
                Features.Add("Customizable quiz creation tools");
                Features.Add("Real-time feedback and scoring");
                Features.Add("Progress tracking for students and educators");
            }
            else if (CurrentProject.Title.Contains("StudySkill"))
            {
                Features.Add("Comprehensive student management system");
                Features.Add("Course scheduling and organization tools");
                Features.Add("Academic performance analytics");
            }
        }

        private void AnimatePageElements()
        {
            // Create a staggered animation for key UI elements
            var elementsToAnimate = new List<FrameworkElement>
            {
                AppIcon,
                AppTitle,
                DeveloperName,
                ViewLiveButton,
                ViewSourceButton,
                ShowReadmeButton
            };

            // Animate with staggered timing
            int delay = 100;
            foreach (var element in elementsToAnimate)
            {
                try
                {
                    element.Opacity = 0;
                    element.Translation = new System.Numerics.Vector3(0, 20, 0);

                    // Create and configure animation
                    var opacityAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = new Duration(TimeSpan.FromMilliseconds(300)),
                        BeginTime = TimeSpan.FromMilliseconds(delay)
                    };

                    // Set target and property
                    Storyboard.SetTarget(opacityAnimation, element);
                    Storyboard.SetTargetProperty(opacityAnimation, "Opacity");

                    // Create storyboard and add animation
                    var storyboard = new Storyboard();
                    storyboard.Children.Add(opacityAnimation);

                    // Start animation
                    storyboard.Begin();

                    // Animate position with composition
                    var elementVisual = Microsoft.UI.Xaml.Hosting.ElementCompositionPreview.GetElementVisual(element);
                    var compositor = elementVisual.Compositor;

                    var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
                    offsetAnimation.InsertKeyFrame(0f, new System.Numerics.Vector3(0, 20, 0));
                    offsetAnimation.InsertKeyFrame(1f, new System.Numerics.Vector3(0, 0, 0));
                    offsetAnimation.Duration = TimeSpan.FromMilliseconds(400);
                    offsetAnimation.DelayTime = TimeSpan.FromMilliseconds(delay);

                    elementVisual.StartAnimation("Translation", offsetAnimation);

                    delay += 80;
                }
                catch (Exception ex)
                {
                    // Ensure element is visible even if animation fails
                    element.Opacity = 1;
                    element.Translation = new System.Numerics.Vector3(0, 0, 0);
                    System.Diagnostics.Debug.WriteLine($"Animation failed: {ex.Message}");
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
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
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = $"Unable to open link: {ex.Message}",
                    CloseButtonText = "OK"
                };

                await dialog.ShowAsync();
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
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = $"Unable to open link: {ex.Message}",
                    CloseButtonText = "OK"
                };

                await dialog.ShowAsync();
            }
        }

        private string ConvertMarkdownToHtml(string markdown)
        {
            // Basic markdown to HTML conversion
            string html = markdown;

            // Process code blocks
            html = Regex.Replace(html, @"```([^`]*?)```", m =>
                $"<pre><code>{System.Net.WebUtility.HtmlEncode(m.Groups[1].Value)}</code></pre>",
                RegexOptions.Singleline);

            // Process code spans
            html = Regex.Replace(html, @"`([^`]*?)`", m =>
                $"<code>{System.Net.WebUtility.HtmlEncode(m.Groups[1].Value)}</code>");

            // Process headers
            html = Regex.Replace(html, @"^# (.*?)$", "<h1>$1</h1>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^## (.*?)$", "<h2>$1</h2>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^### (.*?)$", "<h3>$1</h3>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^#### (.*?)$", "<h4>$1</h4>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^##### (.*?)$", "<h5>$1</h5>", RegexOptions.Multiline);

            // Process bold text
            html = Regex.Replace(html, @"\*\*(.*?)\*\*", "<strong>$1</strong>");
            html = Regex.Replace(html, @"__(.*?)__", "<strong>$1</strong>");

            // Process italic text
            html = Regex.Replace(html, @"\*(.*?)\*", "<em>$1</em>");
            html = Regex.Replace(html, @"_(.*?)_", "<em>$1</em>");

            // Process links
            html = Regex.Replace(html, @"\[(.*?)\]\((.*?)\)", "<a href=\"$2\">$1</a>");

            // Process unordered lists
            html = Regex.Replace(html, @"^\* (.*?)$", "<li>$1</li>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"^- (.*?)$", "<li>$1</li>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"(<li>.*?</li>\n)+", "<ul>$0</ul>", RegexOptions.Singleline);

            // Process ordered lists
            html = Regex.Replace(html, @"^\d+\. (.*?)$", "<li>$1</li>", RegexOptions.Multiline);
            html = Regex.Replace(html, @"(<li>.*?</li>\n)+", "<ol>$0</ol>", RegexOptions.Singleline);

            // Process horizontal rules
            html = Regex.Replace(html, @"^-{3,}$", "<hr>", RegexOptions.Multiline);

            // Process paragraphs
            html = Regex.Replace(html, @"^\s*?\n(.+?)\n\s*?\n", "<p>$1</p>\n\n", RegexOptions.Multiline);

            // Process blockquotes
            html = Regex.Replace(html, @"^> (.*?)$", "<blockquote>$1</blockquote>", RegexOptions.Multiline);

            // Process images
            html = Regex.Replace(html, @"!\[(.*?)\]\((.*?)\)", "<img src=\"$2\" alt=\"$1\">");

            // Wrap the HTML in a styled document
            string styledHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <style>
        body {{
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
            line-height: 1.6;
            color: #333;
            margin: 0;
            padding: 16px;
            font-size: 16px;
        }}
        
        h1, h2, h3, h4, h5, h6 {{
            margin-top: 24px;
            margin-bottom: 16px;
            font-weight: 600;
            line-height: 1.25;
        }}
        
        h1 {{ font-size: 2em; }}
        h2 {{ font-size: 1.5em; }}
        h3 {{ font-size: 1.25em; }}
        
        p, blockquote, ul, ol, table {{
            margin-bottom: 16px;
        }}
        
        blockquote {{
            padding: 0 1em;
            color: #6a737d;
            border-left: 0.25em solid #dfe2e5;
            margin: 0 0 16px 0;
        }}
        
        code {{
            font-family: SFMono-Regular, Consolas, 'Liberation Mono', Menlo, monospace;
            background-color: rgba(27, 31, 35, 0.05);
            border-radius: 3px;
            font-size: 85%;
            padding: 0.2em 0.4em;
        }}
        
        pre {{
            background-color: #f6f8fa;
            border-radius: 3px;
            font-size: 85%;
            line-height: 1.45;
            overflow: auto;
            padding: 16px;
        }}
        
        pre code {{
            background-color: transparent;
            padding: 0;
        }}
        
        a {{
            color: #0366d6;
            text-decoration: none;
        }}
        
        a:hover {{
            text-decoration: underline;
        }}
        
        table {{
            border-collapse: collapse;
            width: 100%;
        }}
        
        table th, table td {{
            padding: 6px 13px;
            border: 1px solid #dfe2e5;
        }}
        
        table tr:nth-child(2n) {{
            background-color: #f6f8fa;
        }}
        
        img {{
            max-width: 100%;
            box-sizing: content-box;
        }}
        
        hr {{
            height: 0.25em;
            padding: 0;
            margin: 24px 0;
            background-color: #e1e4e8;
            border: 0;
        }}
    </style>
</head>
<body>
    {html}
</body>
</html>";

            return styledHtml;
        }
        private async void ShowReadmeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentProject == null || string.IsNullOrEmpty(CurrentProject.GithubUrl))
            {
                return;
            }

            try
            {
                // Show README section and loading indicator
                ReadmeSection.Visibility = Visibility.Visible;
                ReadmeLoadingRing.IsActive = true;
                ReadmeErrorBlock.Visibility = Visibility.Collapsed;
                ReadmeContentBlock.Text = string.Empty;

                // Parse GitHub URL to extract username and repository
                string readme = await FetchReadmeContent(CurrentProject.GithubUrl);

                // Display README content
                if (!string.IsNullOrEmpty(readme))
                {
                    // Convert markdown to HTML
                    string htmlContent = ConvertMarkdownToHtml(readme);

                    // Load the HTML content into the WebView
                    await ReadmeWebView.EnsureCoreWebView2Async();
                    ReadmeWebView.NavigateToString(htmlContent);
                    ReadmeWebView.Visibility = Visibility.Visible;
                }
                else
                {
                    ReadmeErrorBlock.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading README: {ex.Message}");
                ReadmeErrorBlock.Visibility = Visibility.Visible;
            }
            finally
            {
                ReadmeLoadingRing.IsActive = false;
            }
        }

        private async Task<string> FetchReadmeContent(string githubUrl)
        {
            try
            {
                // Extract username and repository name from GitHub URL
                // Example: https://github.com/username/repository

                string pattern = @"github\.com/([^/]+)/([^/]+)";
                Match match = Regex.Match(githubUrl, pattern);

                if (!match.Success || match.Groups.Count < 3)
                {
                    return "Could not parse GitHub URL to extract username and repository.";
                }

                string username = match.Groups[1].Value;
                string repository = match.Groups[2].Value;

                // Form the raw GitHub URL for README.md
                // For raw GitHub content: https://raw.githubusercontent.com/username/repository/main/README.md
                // Try main branch first, then master if that fails

                string[] possibleBranches = new[] { "main", "master" };
                string readmeContent = null;

                foreach (string branch in possibleBranches)
                {
                    try
                    {
                        string readmeUrl = $"https://raw.githubusercontent.com/{username}/{repository}/{branch}/README.md";
                        HttpResponseMessage response = await httpClient.GetAsync(readmeUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            readmeContent = await response.Content.ReadAsStringAsync();
                            break; // Found the README, exit the loop
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error fetching README from {branch} branch: {ex.Message}");
                        // Continue to try the next branch
                    }
                }

                return readmeContent ?? "README not found in main or master branches.";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in FetchReadmeContent: {ex.Message}");
                return null;
            }
        }
    }
}