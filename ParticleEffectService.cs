using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Windows.UI;

namespace ChromaHub
{
    /// <summary>
    /// Service to create and manage particle effects
    /// </summary>
    public class ParticleEffectService
    {
        private Canvas _particleCanvas;
        private Random _random = new Random();
        private ElementTheme _currentTheme;
        private bool _isEnabled = true;
        private double _particleDensity = 1.0; // Multiplier for particle count

        // Cached brushes for better performance
        private SolidColorBrush _lightThemeParticleBrush;
        private SolidColorBrush _darkThemeParticleBrush;
        private SolidColorBrush _accentParticleBrush;

        public ParticleEffectService(Canvas particleCanvas)
        {
            _particleCanvas = particleCanvas;
            _currentTheme = App.CurrentTheme;

            // Initialize brushes
            _lightThemeParticleBrush = new SolidColorBrush(Microsoft.UI.Colors.SkyBlue);
            _darkThemeParticleBrush = new SolidColorBrush(Microsoft.UI.Colors.DeepSkyBlue);
            _accentParticleBrush = new SolidColorBrush(Microsoft.UI.Colors.DodgerBlue);

            // Start background particles
            if (_isEnabled)
            {
                StartBackgroundParticles();
            }
        }

        public void UpdateTheme(ElementTheme theme)
        {
            _currentTheme = theme;
        }

        public void SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
            _particleCanvas.Visibility = isEnabled ? Visibility.Visible : Visibility.Collapsed;

            if (isEnabled && !_backgroundParticlesActive)
            {
                StartBackgroundParticles();
            }
        }

        public void SetParticleDensity(double density)
        {
            _particleDensity = Math.Clamp(density, 0.1, 3.0);
        }

        /// <summary>
        /// Creates a particle burst effect at the specified position
        /// </summary>
        public void CreateParticleBurst(double x, double y, int count = 10, double size = 5)
        {
            if (!_isEnabled) return;

            count = (int)(count * _particleDensity);

            for (int i = 0; i < count; i++)
            {
                var particle = new Ellipse
                {
                    Width = _random.NextDouble() * size + 1,
                    Height = _random.NextDouble() * size + 1,
                    Fill = GetRandomParticleBrush()
                };

                // Initial position
                Canvas.SetLeft(particle, x - particle.Width / 2);
                Canvas.SetTop(particle, y - particle.Height / 2);

                // Setup transform for animation
                var translateTransform = new TranslateTransform();
                particle.RenderTransform = translateTransform;

                _particleCanvas.Children.Add(particle);

                // Create animation
                var storyboard = new Storyboard();

                // Opacity animation
                var opacityAnimation = new DoubleAnimationUsingKeyFrames();
                opacityAnimation.KeyFrames.Add(new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 0.8 });
                opacityAnimation.KeyFrames.Add(new EasingDoubleKeyFrame
                {
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1 + _random.NextDouble())),
                    Value = 0,
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                });
                Storyboard.SetTarget(opacityAnimation, particle);
                Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
                storyboard.Children.Add(opacityAnimation);

                // Movement animation
                var angle = _random.NextDouble() * Math.PI * 2;
                var distance = _random.NextDouble() * 100 + 20;
                var duration = TimeSpan.FromSeconds(_random.NextDouble() + 0.5);

                var moveX = Math.Cos(angle) * distance;
                var moveY = Math.Sin(angle) * distance;

                // X movement
                var xAnimation = new DoubleAnimation
                {
                    To = moveX,
                    Duration = duration,
                    EnableDependentAnimation = true,
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                Storyboard.SetTarget(xAnimation, translateTransform);
                Storyboard.SetTargetProperty(xAnimation, "X");
                storyboard.Children.Add(xAnimation);

                // Y movement
                var yAnimation = new DoubleAnimation
                {
                    To = moveY,
                    Duration = duration,
                    EnableDependentAnimation = true,
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                Storyboard.SetTarget(yAnimation, translateTransform);
                Storyboard.SetTargetProperty(yAnimation, "Y");
                storyboard.Children.Add(yAnimation);

                // Start animation
                storyboard.Completed += (s, e) =>
                {
                    _particleCanvas.Children.Remove(particle);
                };
                storyboard.Begin();
            }
        }

        private bool _backgroundParticlesActive = false;

        /// <summary>
        /// Starts a continuous background particle effect
        /// </summary>
        public async void StartBackgroundParticles()
        {
            if (!_isEnabled || _backgroundParticlesActive) return;

            _backgroundParticlesActive = true;

            // Create a set of initial background particles
            var initialCount = (int)(20 * _particleDensity);
            for (int i = 0; i < initialCount; i++)
            {
                CreateBackgroundParticle(true);
            }

            // Continue creating particles
            while (_isEnabled && _backgroundParticlesActive)
            {
                CreateBackgroundParticle();
                await Task.Delay(500); // Add new particles periodically
            }
        }

        public void StopBackgroundParticles()
        {
            _backgroundParticlesActive = false;
        }

        private void CreateBackgroundParticle(bool initialPlacement = false)
        {
            if (_particleCanvas == null || !_isEnabled) return;

            var canvasWidth = _particleCanvas.ActualWidth;
            var canvasHeight = _particleCanvas.ActualHeight;

            if (canvasWidth <= 0 || canvasHeight <= 0) return;

            var particle = new Ellipse
            {
                Width = _random.NextDouble() * 3 + 1,
                Height = _random.NextDouble() * 3 + 1,
                Fill = GetRandomParticleBrush(0.5),
                Opacity = _random.NextDouble() * 0.5 + 0.2
            };

            // Initial position
            double x, y;

            if (initialPlacement)
            {
                // Place anywhere on the canvas for initial setup
                x = _random.NextDouble() * canvasWidth;
                y = _random.NextDouble() * canvasHeight;
            }
            else
            {
                // New particles come from edges
                bool fromHorizontalEdge = _random.NextDouble() > 0.5;
                if (fromHorizontalEdge)
                {
                    x = _random.NextDouble() * canvasWidth;
                    y = _random.NextDouble() > 0.5 ? -5 : canvasHeight + 5;
                }
                else
                {
                    x = _random.NextDouble() > 0.5 ? -5 : canvasWidth + 5;
                    y = _random.NextDouble() * canvasHeight;
                }
            }

            Canvas.SetLeft(particle, x);
            Canvas.SetTop(particle, y);

            // Setup transform
            var translateTransform = new TranslateTransform();
            particle.RenderTransform = translateTransform;

            _particleCanvas.Children.Add(particle);

            // Create animation
            var storyboard = new Storyboard();

            // Movement animation
            double targetX = _random.NextDouble() * canvasWidth;
            double targetY = _random.NextDouble() * canvasHeight;

            // Calculate vector from current to target
            double vectorX = targetX - x;
            double vectorY = targetY - y;

            // Calculate duration based on distance and a base speed
            double distance = Math.Sqrt(vectorX * vectorX + vectorY * vectorY);
            var duration = TimeSpan.FromSeconds(distance / (20 + _random.NextDouble() * 10));

            // X movement
            var xAnimation = new DoubleAnimation
            {
                From = 0,
                To = vectorX,
                Duration = duration,
                EnableDependentAnimation = true,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(xAnimation, translateTransform);
            Storyboard.SetTargetProperty(xAnimation, "X");
            storyboard.Children.Add(xAnimation);

            // Y movement
            var yAnimation = new DoubleAnimation
            {
                From = 0,
                To = vectorY,
                Duration = duration,
                EnableDependentAnimation = true,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
            Storyboard.SetTarget(yAnimation, translateTransform);
            Storyboard.SetTargetProperty(yAnimation, "Y");
            storyboard.Children.Add(yAnimation);

            // Opacity animation for fade out at the end
            var opacityAnimation = new DoubleAnimation
            {
                From = particle.Opacity,
                To = 0,
                BeginTime = duration - TimeSpan.FromSeconds(1), // Start fading out 1 second before end
                Duration = TimeSpan.FromSeconds(1),
                EnableDependentAnimation = true
            };
            Storyboard.SetTarget(opacityAnimation, particle);
            Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
            storyboard.Children.Add(opacityAnimation);

            // Start animation
            storyboard.Completed += (s, e) =>
            {
                _particleCanvas.Children.Remove(particle);
            };
            storyboard.Begin();
        }

        /// <summary>
        /// Gets a random particle brush based on the current theme
        /// </summary>
        private SolidColorBrush GetRandomParticleBrush(double opacity = 1.0)
        {
            SolidColorBrush brush;

            switch (_currentTheme)
            {
                case ElementTheme.Light:
                    brush = _lightThemeParticleBrush;
                    break;
                case ElementTheme.Dark:
                    brush = _darkThemeParticleBrush;
                    break;
                default:
                    brush = _accentParticleBrush;
                    break;
            }

            // Adjust opacity
            brush.Opacity = opacity;
            return brush;
        }
    }
}
