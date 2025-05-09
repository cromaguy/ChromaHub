using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Composition.SystemBackdrops;
using System;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using Microsoft.UI;
using System.Threading.Tasks;
using WinRT; // Added for proper WinRT interop
using Windows.Storage;
using ChromaHub;
using System.Linq;
using System.Reflection.Metadata;

namespace ChromaHub
{
    public sealed partial class MainWindow : Window
    {
        // Make the Frame accessible for navigation from other classes
        public Frame AppFrame => ContentFrame;

        // Variables to track window backdrop
        private MicaController _micaController;
        private SystemBackdropConfiguration _backdropConfiguration;

        // Is loading flag to prevent multiple navigation attempts during initialization
        private bool _isLoading = true;

        // Track the window for maximize/restore functionality
        private AppWindow _appWindow;
        private bool _isMaximized = false;
        private WindowId _windowId;

        // Backdrop type
        private string _currentBackdropType = "Mica";

        // Variable to track if the window is closing
        private bool _isClosing = false;

        public MainWindow()
        {
            this.InitializeComponent();

            // Set window properties
            Title = "Anjishnu Nandi | Portfolio";
            SetupWindow();

            // Configure navigation
            NavView.ItemInvoked += NavView_ItemInvoked;

            // Load backdrop setting
            LoadBackdropSetting();

            // Apply theme based on saved settings
            ApplyTheme(App.CurrentTheme);

            // Initialize theme icon based on current theme
            ElementTheme currentTheme = App.CurrentTheme;
            UpdateThemeIcon(currentTheme);

            // Initial navigation to splash screen
            ContentFrame.Navigate(typeof(SplashScreen));

            // Set the loading flag to false once the UI is ready
            _isLoading = false;
        }

        private void LoadBackdropSetting()
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue("BackdropType", out object backdropValue) &&
                    backdropValue is string backdropType)
                {
                    _currentBackdropType = backdropType;
                }
            }
            catch
            {
                // Use default if settings cannot be read
                _currentBackdropType = "Mica";
            }
        }
        private void SetupWindow()
        {
            try
            {
                // Get window handle and app window
                IntPtr hWnd = WindowNative.GetWindowHandle(this);
                _windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
                _appWindow = AppWindow.GetFromWindowId(_windowId);

                // Remove the default title bar by extending into the caption area
                // This is the key part to hide the default window controls
                ExtendsContentIntoTitleBar = true;

                // Set the draggable regions for the custom title bar
                SetTitleBar(AppTitleBar);

                // Get the AppWindowTitleBar
                var titleBar = _appWindow.TitleBar;

                // Hide default title bar completely
                titleBar.ExtendsContentIntoTitleBar = true;

                // Make default system title bar buttons invisible
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                titleBar.ButtonForegroundColor = Colors.Transparent;
                titleBar.ButtonInactiveForegroundColor = Colors.Transparent;
                var hWnd1 = WinRT.Interop.WindowNative.GetWindowHandle(this);
                var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd1);
                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                var presenter = appWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter;

                // Hide both the border and the title bar (including system controls)
                presenter.SetBorderAndTitleBar(true, false);

                // Set window size
                _appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 1200, Height = 800 });

                // Center the window
                CenterWindow(_appWindow, _windowId);

                // Apply backdrop based on saved setting
                ApplyBackdrop(_currentBackdropType);
            }
            catch (Exception ex)
            {
                // Fallback in case of failure
                if (RootGrid != null)
                {
                    RootGrid.Background = new SolidColorBrush(
                        RootGrid.RequestedTheme == ElementTheme.Dark ? Colors.Black : Colors.White);
                }
            }
        }

        private void CenterWindow(AppWindow appWindow, WindowId windowId)
        {
            try
            {
                DisplayArea displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
                if (displayArea != null)
                {
                    var centerX = displayArea.WorkArea.X + (displayArea.WorkArea.Width - appWindow.Size.Width) / 2;
                    var centerY = displayArea.WorkArea.Y + (displayArea.WorkArea.Height - appWindow.Size.Height) / 2;
                    appWindow.Move(new Windows.Graphics.PointInt32(centerX, centerY));
                }
            }
            catch
            {
                // Silently handle any errors with window positioning
            }
        }

        public void ApplyBackdrop(string backdropType)
        {
            _currentBackdropType = backdropType;

            try
            {
                // Clean up existing backdrop if any
                CleanupBackdrop();

                if (backdropType == "Mica")
                {
                    TryApplyMicaBackdrop();
                }
                else
                {
                    ApplySolidColorBackdrop();
                }
            }
            catch
            {
                // Fallback to solid color if requested backdrop fails
                ApplySolidColorBackdrop();
            }
        }

        private void CleanupBackdrop()
        {
            if (_micaController != null)
            {
                _micaController.Dispose();
                _micaController = null;
            }

            _backdropConfiguration = null;

            // Ensure we have a background in case backdrop is removed
            ApplySolidColorBackdrop();
        }

        private void TryApplyMicaBackdrop()
        {
            try
            {
                // Initialize the Mica controller
                _micaController = new MicaController();
                _backdropConfiguration = new SystemBackdropConfiguration();

                // Configure backdrop
                _micaController.Kind = MicaKind.BaseAlt;
                _backdropConfiguration.IsInputActive = true;
                _backdropConfiguration.Theme = (Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme)App.CurrentTheme;

                // Apply the backdrop
                // Fixed: Use proper COM interface casting with TryAs
                _micaController.AddSystemBackdropTarget(this.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
                _micaController.SetSystemBackdropConfiguration(_backdropConfiguration);

                // Clear background to allow backdrop visibility
                if (RootGrid != null)
                {
                    RootGrid.Background = null;
                }
            }
            catch (Exception)
            {
                // Fallback to solid color if Mica is not supported
                ApplySolidColorBackdrop();
            }
        }

        private void ApplySolidColorBackdrop()
        {
            try
            {
                if (RootGrid != null)
                {
                    RootGrid.Background = App.CurrentTheme == ElementTheme.Dark ?
                        new SolidColorBrush(Colors.Black) :
                        new SolidColorBrush(Colors.White);
                }
            }
            catch
            {
                // Silently handle any errors with applying backdrop
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                NavigateToPage("Settings");
                return;
            }

            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item != null)
            {
                var tag = item.Tag?.ToString();
                NavigateToPage(tag);
            }
        }

        public void NavigateToPage(string tag)
        {
            if (string.IsNullOrEmpty(tag) || _isLoading)
                return;

            Type pageType = null;
            object parameter = null;

            switch (tag)
            {
                case "Home":
                    pageType = typeof(HomePage);
                    break;
                case "About":
                    pageType = typeof(AboutPage);
                    break;
                case "Projects":
                    pageType = typeof(ProjectsPage);
                    break;
                case "Contact":
                    pageType = typeof(ContactPage);
                    break;
                case "Settings":
                case "Tweaks":
                    pageType = typeof(SettingsPage);
                    break;
                case "AllWebApps":
                case "WebApps":
                    pageType = typeof(WebAppsPage);
                    break;
                case "NewAngle":
                case "Feel":
                case "GoalGuru":
                case "Quizzy":
                case "StudySkill":
                case "StudySkillRe":
                    var webApps = WebAppProject.GetWebApps();
                    var project = webApps.FirstOrDefault(p => p.Title.Contains(tag) ||
                                                            p.Title.Replace(" ", "").Contains(tag));
                    if (project != null)
                    {
                        pageType = typeof(WebAppViewPage);
                        parameter = project;
                    }
                    else
                    {
                        pageType = typeof(WebAppsPage);
                    }
                    break;
                default:
                    pageType = typeof(HomePage);
                    break;
            }

            if (pageType != null)
            {
                bool shouldNavigate = false;

                // For normal pages, check if we're navigating to a different page type
                if (parameter == null)
                {
                    shouldNavigate = (ContentFrame.CurrentSourcePageType != pageType || pageType == typeof(HomePage));
                }
                // For WebAppViewPage with a project parameter, always navigate to handle different web apps
                else if (pageType == typeof(WebAppViewPage))
                {
                    shouldNavigate = true;
                }

                if (shouldNavigate)
                {
                    // Show loading indicator
                    ShowLoading(true);

                    // Navigate after a brief delay to allow UI to update
                    Task.Delay(100).ContinueWith(t => {
                        DispatcherQueue.TryEnqueue(() => {
                            if (parameter != null)
                            {
                                ContentFrame.Navigate(pageType, parameter);
                            }
                            else
                            {
                                ContentFrame.Navigate(pageType);
                            }
                            ShowLoading(false);
                        });
                    });

                    // Update selected nav item
                    foreach (var navItem in NavView.MenuItems)
                    {
                        if (navItem is NavigationViewItem item && item.Tag?.ToString() == tag)
                        {
                            NavView.SelectedItem = item;
                            break;
                        }
                    }

                    // Handle settings selection specifically
                    if (tag == "Settings" || tag == "Tweaks")
                    {
                        NavView.SelectedItem = NavView.SettingsItem;
                    }
                }
            }
        }

        private void ShowLoading(bool isLoading)
        {
            if (LoadingOverlay != null)
            {
                LoadingOverlay.Visibility = isLoading ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void OpenSocialLinks()
        {
            // Display a flyout with social links
            var flyout = new TeachingTip
            {
                Title = "Connect With Me",
                PreferredPlacement = TeachingTipPlacementMode.Bottom,
                CloseButtonContent = "Close",
                IsLightDismissEnabled = true
            };

            var panel = new StackPanel { Spacing = 12 };

            // Updated with proper Unicode icons for social platforms
            AddSocialLink(panel, "LinkedIn", "\uE774", "https://linkedin.com/in/anjishnu-nandi");
            AddSocialLink(panel, "Twitter", "\uE8AC", "https://twitter.com/AnjiCroma");
            AddSocialLink(panel, "Instagram", "\uE7AA", "https://instagram.com/its.chroma.anji");
            AddSocialLink(panel, "GitHub", "\uEA0A", "https://github.com/cromaguy");
            AddSocialLink(panel, "Email", "\uE715", "mailto:anjicroma@gmail.com");

            flyout.Content = panel;

            if (NavView.FooterMenuItems.Count > 0 && NavView.FooterMenuItems[0] is NavigationViewItem navItem)
            {
                flyout.Target = navItem;
                flyout.IsOpen = true;
            }
        }

        private void AddSocialLink(StackPanel panel, string name, string icon, string url)
        {
            var button = new Button
            {
                Content = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Spacing = 8,
                    Children =
                    {
                        new FontIcon { Glyph = icon, FontSize = 16 },
                        new TextBlock { Text = name }
                    }
                },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Left
            };

            button.Click += async (s, e) =>
            {
                var uri = new Uri(url);
                await Windows.System.Launcher.LaunchUriAsync(uri);
            };

            panel.Children.Add(button);
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get current theme from RootGrid
            ElementTheme currentTheme = RootGrid.RequestedTheme;

            // If Default, determine from application
            if (currentTheme == ElementTheme.Default)
            {
                currentTheme = Application.Current.RequestedTheme == ApplicationTheme.Light
                    ? ElementTheme.Light
                    : ElementTheme.Dark;
            }

            // Toggle theme
            ElementTheme newTheme = currentTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
            ApplyTheme(newTheme);
            App.SaveThemePreference(newTheme);
        }

        public void ApplyTheme(ElementTheme theme)
        {
            if (RootGrid != null)
            {
                // Apply the theme to the current window first
                RootGrid.RequestedTheme = theme;

                // Update backdrop configuration if using Mica
                if (_backdropConfiguration != null)
                {
                    _backdropConfiguration.Theme = (Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme)theme;
                }
                else
                {
                    // Apply solid color background if not using backdrop
                    RootGrid.Background = theme == ElementTheme.Dark ?
                        new SolidColorBrush(Colors.Black) :
                        new SolidColorBrush(Colors.White);
                }

                UpdateThemeIcon();
            }
        }

        private void UpdateThemeIcon(ElementTheme? currentTheme = null)
        {
            // Update theme icon based on current theme
            if (ThemeIcon != null)
            {
                // Use the passed theme parameter or determine from RootGrid
                ElementTheme theme = currentTheme ?? RootGrid.RequestedTheme;

                // If Default, determine from application
                if (theme == ElementTheme.Default)
                {
                    theme = Application.Current.RequestedTheme == ApplicationTheme.Light
                        ? ElementTheme.Light
                        : ElementTheme.Dark;
                }

                ThemeIcon.Glyph = theme == ElementTheme.Light
                    ? "\uE793"  // Dark mode icon
                    : "\uE706"; // Light mode icon
            }
        }

        // Window control button handlers - FIXED with proper implementations
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_appWindow != null)
            {
                // Use Win32 window handle for minimize operation
                IntPtr hwnd = WindowNative.GetWindowHandle(this);
                PInvoke.User32.ShowWindow(hwnd, PInvoke.User32.WindowShowStyle.SW_MINIMIZE);
            }
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (_appWindow != null)
            {
                IntPtr hwnd = WindowNative.GetWindowHandle(this);
                var windowStyle = PInvoke.User32.GetWindowLong(hwnd, PInvoke.User32.WindowLongIndexFlags.GWL_STYLE);

                if (_isMaximized)
                {
                    // Restore window
                    PInvoke.User32.ShowWindow(hwnd, PInvoke.User32.WindowShowStyle.SW_RESTORE);
                    _isMaximized = false;
                    MaximizeRestoreIcon.Glyph = "\uE922"; // Maximize icon
                }
                else
                {
                    // Maximize window
                    PInvoke.User32.ShowWindow(hwnd, PInvoke.User32.WindowShowStyle.SW_MAXIMIZE);
                    _isMaximized = true;
                    MaximizeRestoreIcon.Glyph = "\uE923"; // Restore icon
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    // Add PInvoke helper for window operations
    internal static class PInvoke
    {
        internal static class User32
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern int GetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex);

            internal enum WindowShowStyle : uint
            {
                SW_HIDE = 0,
                SW_SHOWNORMAL = 1,
                SW_NORMAL = 1,
                SW_SHOWMINIMIZED = 2,
                SW_SHOWMAXIMIZED = 3,
                SW_MAXIMIZE = 3,
                SW_SHOWNOACTIVATE = 4,
                SW_SHOW = 5,
                SW_MINIMIZE = 6,
                SW_SHOWMINNOACTIVE = 7,
                SW_SHOWNA = 8,
                SW_RESTORE = 9
            }

            internal enum WindowLongIndexFlags : int
            {
                GWL_EXSTYLE = -20,
                GWL_STYLE = -16,
                GWL_WNDPROC = -4
            }
        }
    }
}