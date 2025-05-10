using Microsoft.UI.Xaml;
using System;
using Windows.Storage;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace ChromaHub
{
    public partial class App : Application
    {
        private Window m_window;

        public static Window MainWindow { get; private set; }
        public static new App Current => (App)Application.Current;
        public static ElementTheme CurrentTheme { get; set; } = ElementTheme.Default;

        // Sound players
        private static MediaPlayer uiClickPlayer;
        private static MediaPlayer uiHoverPlayer;
        private static MediaPlayer uiNavigatePlayer;
        private static MediaPlayer uiTogglePlayer;

        // Sound settings
        public static bool SoundsEnabled { get; set; } = true;
        public static double SoundVolume { get; set; } = 0.5;

        public App()
        {
            this.InitializeComponent();
            LoadThemePreference();
            LoadSoundSettings();
            InitializeAudio();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            MainWindow = m_window;
            m_window.Activate();
        }

        public static void SaveThemePreference(ElementTheme theme)
        {
            CurrentTheme = theme;
            ApplicationData.Current.LocalSettings.Values["AppTheme"] = theme.ToString();
        }

        private void LoadThemePreference()
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue("AppTheme", out object themeValue) &&
                    themeValue is string themeName)
                {
                    if (Enum.TryParse(typeof(ElementTheme), themeName, out object themeResult) &&
                        themeResult is ElementTheme theme)
                    {
                        CurrentTheme = theme;
                    }
                }
            }
            catch
            {
                CurrentTheme = ElementTheme.Default;
            }
        }

        private void LoadSoundSettings()
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue("SoundsEnabled", out object soundsEnabledValue) &&
                    soundsEnabledValue is bool soundsEnabled)
                {
                    SoundsEnabled = soundsEnabled;
                }

                if (ApplicationData.Current.LocalSettings.Values.TryGetValue("SoundVolume", out object soundVolumeValue) &&
                    soundVolumeValue is double soundVolume)
                {
                    SoundVolume = soundVolume;
                }
            }
            catch
            {
                // Use defaults if settings can't be loaded
                SoundsEnabled = true;
                SoundVolume = 0.5;
            }
        }

        public static void SaveSoundSettings(bool enabled, double volume)
        {
            SoundsEnabled = enabled;
            SoundVolume = volume;
            ApplicationData.Current.LocalSettings.Values["SoundsEnabled"] = enabled;
            ApplicationData.Current.LocalSettings.Values["SoundVolume"] = volume;

            // Update volume for all players
            if (uiClickPlayer != null) uiClickPlayer.Volume = enabled ? volume : 0;
            if (uiHoverPlayer != null) uiHoverPlayer.Volume = enabled ? volume : 0;
            if (uiNavigatePlayer != null) uiNavigatePlayer.Volume = enabled ? volume : 0;
            if (uiTogglePlayer != null) uiTogglePlayer.Volume = enabled ? volume : 0;
        }

        private void InitializeAudio()
        {
            try
            {
                // Create and configure media players for UI sounds
                uiClickPlayer = new MediaPlayer();
                uiClickPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.wav"));
                uiClickPlayer.Volume = SoundsEnabled ? SoundVolume : 0;
                uiClickPlayer.AudioCategory = MediaPlayerAudioCategory.GameMedia;

                uiHoverPlayer = new MediaPlayer();
                uiHoverPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/hover.wav"));
                uiHoverPlayer.Volume = SoundsEnabled ? SoundVolume : 0;
                uiHoverPlayer.AudioCategory = MediaPlayerAudioCategory.GameMedia;

                uiNavigatePlayer = new MediaPlayer();
                uiNavigatePlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/navigate.wav"));
                uiNavigatePlayer.Volume = SoundsEnabled ? SoundVolume : 0;
                uiNavigatePlayer.AudioCategory = MediaPlayerAudioCategory.GameMedia;

                uiTogglePlayer = new MediaPlayer();
                uiTogglePlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/toggle.wav"));
                uiTogglePlayer.Volume = SoundsEnabled ? SoundVolume : 0;
                uiTogglePlayer.AudioCategory = MediaPlayerAudioCategory.GameMedia;
            }
            catch
            {
                // Silently fail if sounds can't be loaded
            }
        }

        // Sound playback methods
        public static void PlayClickSound()
        {
            if (SoundsEnabled && uiClickPlayer != null)
            {
                uiClickPlayer.PlaybackSession.Position = TimeSpan.Zero;
                uiClickPlayer.Play();
            }
        }

        public static void PlayHoverSound()
        {
            if (SoundsEnabled && uiHoverPlayer != null)
            {
                uiHoverPlayer.PlaybackSession.Position = TimeSpan.Zero;
                uiHoverPlayer.Play();
            }
        }

        public static void PlayNavigateSound()
        {
            if (SoundsEnabled && uiNavigatePlayer != null)
            {
                uiNavigatePlayer.PlaybackSession.Position = TimeSpan.Zero;
                uiNavigatePlayer.Play();
            }
        }

        public static void PlayToggleSound()
        {
            if (SoundsEnabled && uiTogglePlayer != null)
            {
                uiTogglePlayer.PlaybackSession.Position = TimeSpan.Zero;
                uiTogglePlayer.Play();
            }
        }
    }
}