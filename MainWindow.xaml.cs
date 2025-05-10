using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Composition.SystemBackdrops;
using System;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using Microsoft.UI;
using System.Threading.Tasks;
using WinRT;
using Windows.Storage;
using ChromaHub;
using System.Linq;
using Microsoft.UI.Xaml.Media.Animation;
using System.Collections.Generic;
using Microsoft.UI.Composition;

namespace ChromaHub
{
    public sealed partial class MainWindow : Window
    {
        public Frame AppFrame => ContentFrame;
        private MicaController _micaController;
        private SystemBackdropConfiguration _backdropConfiguration;
        private bool _isLoading = true;
        private AppWindow _appWindow;
        private bool _isMaximized = false;
        private WindowId _windowId;
        private string _currentBackdropType = "Mica";
        private bool _isClosing = false;
        private Storyboard _pulseAnimation;
        private Storyboard _fadeInAnimation;
        private Storyboard _fadeOutAnimation;
        private Storyboard _buttonClickAnimation;
        private Storyboard _loadingSpinnerAnimation;

        public MainWindow()
        {
            this.InitializeComponent();
            InitializeAnimations();
            Title = "Anjishnu Nandi | ChromaHub";
            SetupWindow();
            NavView.ItemInvoked += NavView_ItemInvoked;
            SetupSoundEffects();
            LoadBackdropSetting();
            ApplyTheme(App.CurrentTheme);
            UpdateThemeIcon(App.CurrentTheme);
            ContentFrame.Navigate(typeof(SplashScreen));
            _isLoading = false;
        }

        private void InitializeAnimations()
        {
            try
            {
                // Load animations from resources dictionary
                var resourceDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d =>
                    d.Source?.OriginalString.Contains("AnimationResources.xaml") == true);

                if (resourceDictionary != null)
                {
                    _pulseAnimation = resourceDictionary["PulseAnimation"] as Storyboard;
                    _fadeInAnimation = resourceDictionary["FadeInAnimation"] as Storyboard;
                    _fadeOutAnimation = resourceDictionary["FadeOutAnimation"] as Storyboard;
                    _buttonClickAnimation = resourceDictionary["ButtonClickAnimation"] as Storyboard;
                    _loadingSpinnerAnimation = resourceDictionary["LoadingSpinnerAnimation"] as Storyboard;
                }
                else
                {
                    // Fallback to application resources
                    _pulseAnimation = Application.Current.Resources["PulseAnimation"] as Storyboard;
                    _fadeInAnimation = Application.Current.Resources["FadeInAnimation"] as Storyboard;
                    _fadeOutAnimation = Application.Current.Resources["FadeOutAnimation"] as Storyboard;
                    _buttonClickAnimation = Application.Current.Resources["ButtonClickAnimation"] as Storyboard;
                    _loadingSpinnerAnimation = Application.Current.Resources["LoadingSpinnerAnimation"] as Storyboard;
                }

                if (RootGrid != null && RootGrid.RenderTransform == null)
                {
                    RootGrid.RenderTransform = new ScaleTransform();
                    RootGrid.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
                }

                foreach (var button in FindVisualChildren<Button>(RootGrid))
                {
                    if (button.RenderTransform == null)
                    {
                        button.RenderTransform = new ScaleTransform();
                        button.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error initializing animations: {ex.Message}");
            }
        }

        private void SetupSoundEffects()
        {
            if (NavView != null)
            {
                SoundEffectsHelper.AddSoundEffects(NavView);

                foreach (var item in NavView.MenuItems)
                {
                    if (item is NavigationViewItem navItem)
                    {
                        SoundEffectsHelper.AddSoundEffects(navItem);
                    }
                }

                foreach (var item in NavView.FooterMenuItems)
                {
                    if (item is NavigationViewItem navItem)
                    {
                        SoundEffectsHelper.AddSoundEffects(navItem);
                    }
                }
            }
            SoundEffectsHelper.AddSoundEffects(MinimizeButton);
            SoundEffectsHelper.AddSoundEffects(MaximizeRestoreButton);
            SoundEffectsHelper.AddSoundEffects(CloseButton);
            SoundEffectsHelper.AddSoundEffects(ThemeButton);
            SoundEffectsHelper.AddSoundEffects(NotificationsButton);
            SoundEffectsHelper.AddHoverEffect(ThemeButton);
            SoundEffectsHelper.AddHoverEffect(NotificationsButton);
            SoundEffectsHelper.AddHoverEffect(MinimizeButton);
            SoundEffectsHelper.AddHoverEffect(MaximizeRestoreButton);
            SoundEffectsHelper.AddHoverEffect(CloseButton);
        }

        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) yield break;

            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T t)
                {
                    yield return t;
                }

                foreach (var childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
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
                _currentBackdropType = "Mica";
            }
        }

        private void SetupWindow()
        {
            try
            {
                IntPtr hWnd = WindowNative.GetWindowHandle(this);
                _windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
                _appWindow = AppWindow.GetFromWindowId(_windowId);
                ExtendsContentIntoTitleBar = true;
                SetTitleBar(AppTitleBar);
                var titleBar = _appWindow.TitleBar;
                titleBar.ExtendsContentIntoTitleBar = true;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                titleBar.ButtonForegroundColor = Colors.Transparent;
                titleBar.ButtonInactiveForegroundColor = Colors.Transparent;
                var presenter = _appWindow.Presenter as OverlappedPresenter;
                presenter.SetBorderAndTitleBar(true, false);
                _appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 1200, Height = 800 });
                CenterWindow(_appWindow, _windowId);
                ApplyBackdrop(_currentBackdropType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in SetupWindow: {ex.Message}");
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in CenterWindow: {ex.Message}");
            }
        }

        public void ApplyBackdrop(string backdropType)
        {
            _currentBackdropType = backdropType;

            try
            {
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ApplyBackdrop: {ex.Message}");
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

            ApplySolidColorBackdrop();
        }

        private void TryApplyMicaBackdrop()
        {
            try
            {
                _micaController = new MicaController();
                _backdropConfiguration = new SystemBackdropConfiguration();
                _micaController.Kind = MicaKind.BaseAlt;
                _backdropConfiguration.IsInputActive = true;
                _backdropConfiguration.Theme = (SystemBackdropTheme)App.CurrentTheme;
                _micaController.AddSystemBackdropTarget(this.As<ICompositionSupportsSystemBackdrop>());
                _micaController.SetSystemBackdropConfiguration(_backdropConfiguration);
                if (RootGrid != null)
                {
                    RootGrid.Background = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in TryApplyMicaBackdrop: {ex.Message}");
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ApplySolidColorBackdrop: {ex.Message}");
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

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            // Call App's PlayNavigateSound method
            PlayNavigateSound();

            if (args.SelectedItem is NavigationViewItem item && item.Tag != null)
            {
                NavigateToPage(item.Tag.ToString());
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

                if (parameter == null)
                {
                    shouldNavigate = (ContentFrame.CurrentSourcePageType != pageType || pageType == typeof(HomePage));
                }
                else if (pageType == typeof(WebAppViewPage))
                {
                    shouldNavigate = true;
                }

                if (shouldNavigate)
                {
                    ShowLoading(true);

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

                    foreach (var navItem in NavView.MenuItems)
                    {
                        if (navItem is NavigationViewItem item && item.Tag?.ToString() == tag)
                        {
                            NavView.SelectedItem = item;
                            break;
                        }
                    }

                    if (tag == "Settings" || tag == "Tweaks")
                    {
                        NavView.SelectedItem = NavView.FooterMenuItems.FirstOrDefault(
                            item => item is NavigationViewItem navItem &&
                            (navItem.Tag?.ToString() == "Settings" || navItem.Tag?.ToString() == "Tweaks"));
                    }
                }
            }
        }

        private void ShowLoading(bool isLoading)
        {
            if (LoadingOverlay != null)
            {
                if (isLoading)
                {
                    LoadingOverlay.Visibility = Visibility.Visible;

                    if (_fadeInAnimation != null)
                    {
                        Storyboard.SetTarget(_fadeInAnimation, LoadingOverlay);
                        _fadeInAnimation.Begin();
                    }

                    // Use LoadingProgress instead of LoadingSpinner
                    if (LoadingProgress != null && _loadingSpinnerAnimation != null)
                    {
                        if (LoadingProgress.RenderTransform == null)
                        {
                            LoadingProgress.RenderTransform = new RotateTransform();
                        }

                        Storyboard.SetTarget(_loadingSpinnerAnimation, LoadingProgress);
                        _loadingSpinnerAnimation.Begin();
                    }
                }
                else
                {
                    if (_fadeOutAnimation != null)
                    {
                        Storyboard.SetTarget(_fadeOutAnimation, LoadingOverlay);
                        _fadeOutAnimation.Begin();

                        _fadeOutAnimation.Completed += (s, e) =>
                        {
                            LoadingOverlay.Visibility = Visibility.Collapsed;

                            // Use LoadingProgress instead of LoadingSpinner
                            if (LoadingProgress != null && _loadingSpinnerAnimation != null)
                            {
                                _loadingSpinnerAnimation.Stop();
                            }
                        };
                    }
                    else
                    {
                        LoadingOverlay.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }


        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotificationPanel != null)
            {
                if (NotificationPanel.Visibility == Visibility.Collapsed)
                {
                    NotificationPanel.Visibility = Visibility.Visible;

                    if (_fadeInAnimation != null)
                    {
                        Storyboard.SetTarget(_fadeInAnimation, NotificationPanel);
                        _fadeInAnimation.Begin();
                    }

                    PlayNotificationSound();
                }
                else
                {
                    if (_fadeOutAnimation != null)
                    {
                        Storyboard.SetTarget(_fadeOutAnimation, NotificationPanel);
                        _fadeOutAnimation.Begin();

                        _fadeOutAnimation.Completed += (s, args) =>
                        {
                            NotificationPanel.Visibility = Visibility.Collapsed;
                        };
                    }
                    else
                    {
                        NotificationPanel.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void MusicPlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MusicPlayIcon.Glyph == "\xE769") // Play icon
            {
                MusicPlayIcon.Glyph = "\xE768"; // Pause icon
                PlayMusicStartSound();
                SoundEffectsHelper.AddPulseEffect(MusicPlayerMini);
            }
            else
            {
                MusicPlayIcon.Glyph = "\xE769"; // Play icon
                PlayMusicStopSound();
                SoundEffectsHelper.AddPulseEffect(MusicPlayerMini, 1.0, 1.0);
            }
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            PlayToggleSound();
            ElementTheme currentTheme = RootGrid.RequestedTheme;
            if (currentTheme == ElementTheme.Default)
            {
                currentTheme = Application.Current.RequestedTheme == ApplicationTheme.Light
                    ? ElementTheme.Light
                    : ElementTheme.Dark;
            }
            ElementTheme newTheme = currentTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;

            if (_pulseAnimation != null)
            {
                Storyboard.SetTarget(_pulseAnimation, RootGrid);
                _pulseAnimation.Begin();
            }

            ApplyTheme(newTheme);
            App.SaveThemePreference(newTheme);
        }

        public void ApplyTheme(ElementTheme theme)
        {
            if (RootGrid != null)
            {
                RootGrid.RequestedTheme = theme;
                if (_backdropConfiguration != null)
                {
                    _backdropConfiguration.Theme = (Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme)theme;
                }
                else
                {
                    RootGrid.Background = theme == ElementTheme.Dark ?
                        new SolidColorBrush(Colors.Black) :
                        new SolidColorBrush(Colors.White);
                }

                UpdateThemeIcon();
            }
        }

        private void UpdateThemeIcon(ElementTheme? currentTheme = null)
        {
            if (ThemeIcon != null)
            {
                ElementTheme theme = currentTheme ?? RootGrid.RequestedTheme;

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

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();

            if (_appWindow != null)
            {
                IntPtr hwnd = WindowNative.GetWindowHandle(this);
                PInvoke.User32.ShowWindow(hwnd, PInvoke.User32.WindowShowStyle.SW_MINIMIZE);
            }
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();

            if (_appWindow != null)
            {
                IntPtr hwnd = WindowNative.GetWindowHandle(this);
                var windowStyle = PInvoke.User32.GetWindowLong(hwnd, PInvoke.User32.WindowLongIndexFlags.GWL_STYLE);

                if (_isMaximized)
                {
                    PInvoke.User32.ShowWindow(hwnd, PInvoke.User32.WindowShowStyle.SW_RESTORE);
                    _isMaximized = false;
                    MaximizeRestoreIcon.Glyph = "\uE922"; // Maximize icon
                }
                else
                {
                    PInvoke.User32.ShowWindow(hwnd, PInvoke.User32.WindowShowStyle.SW_MAXIMIZE);
                    _isMaximized = true;
                    MaximizeRestoreIcon.Glyph = "\uE923"; // Restore icon
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();
            Close();
        }

        // Sound methods
        public void PlayNavigateSound()
        {
            App.PlayNavigateSound();
        }

        public void PlayClickSound()
        {
            App.PlayClickSound();
        }

        public void PlayToggleSound()
        {
            App.PlayToggleSound();
        }

        public void PlayMusicStartSound()
        {
            // Implement music start sound playback
            // This should eventually be implemented in the App class
            System.Diagnostics.Debug.WriteLine("Playing music start sound");
        }

        public void PlayMusicStopSound()
        {
            // Implement music stop sound playback
            // This should eventually be implemented in the App class
            System.Diagnostics.Debug.WriteLine("Playing music stop sound");
        }

        public void PlayNotificationSound()
        {
            // Implement notification sound playback
            // This should eventually be implemented in the App class
            System.Diagnostics.Debug.WriteLine("Playing notification sound");
        }
    }

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