using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Media.Animation;

namespace ChromaHub
{
    /// <summary>
    /// Helper class to add sound effects and animations to UI elements
    /// </summary>
    public static class SoundEffectsHelper
    {
        // Cache for elements that already have effects added
        private static HashSet<UIElement> _elementsWithEffects = new HashSet<UIElement>();

        /// <summary>
        /// Adds hover and click sound effects to a UIElement
        /// </summary>
        public static void AddSoundEffects(UIElement element)
        {
            if (element == null || _elementsWithEffects.Contains(element)) return;

            // Mark this element as processed
            _elementsWithEffects.Add(element);

            // Add hover sound
            element.PointerEntered += (s, e) => App.PlayHoverSound();

            // Add click sound for buttons and similar controls
            if (element is ButtonBase buttonElement)
            {
                buttonElement.Click += (s, e) => App.PlayClickSound();
            }
            else if (element is ToggleSwitch toggleSwitch)
            {
                toggleSwitch.Toggled += (s, e) => App.PlayToggleSound();
            }
            else if (element is ComboBox comboBox)
            {
                comboBox.SelectionChanged += (s, e) => App.PlayClickSound();
            }
            else if (element is ListViewBase listView)
            {
                listView.ItemClick += (s, e) => App.PlayClickSound();
            }
            else if (element is NavigationView navView)
            {
                navView.ItemInvoked += (s, e) => App.PlayNavigateSound();
            }
            else if (element is HyperlinkButton hyperlink)
            {
                hyperlink.Click += (s, e) => App.PlayNavigateSound();
            }
            else
            {
                // For any other element, try to add tap sound
                element.Tapped += (s, e) => App.PlayClickSound();
            }
        }

        /// <summary>
        /// Recursively adds sound effects to all elements in a container
        /// </summary>
        public static void AddSoundEffectsToChildren(DependencyObject container)
        {
            if (container == null) return;

            int childCount = VisualTreeHelper.GetChildrenCount(container);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(container, i);

                if (child is UIElement element)
                {
                    AddSoundEffects(element);
                }

                // Recursively process children
                AddSoundEffectsToChildren(child);
            }
        }

        /// <summary>
        /// Adds modern hover effect to an element with optional sound
        /// </summary>
        public static void AddHoverEffect(UIElement element, double scaleAmount = 1.05, bool playSound = true, TimeSpan? duration = null)
        {
            if (element == null) return;

            // Default duration if not specified
            var animDuration = duration ?? TimeSpan.FromMilliseconds(150);

            // Create scale animations
            var scaleUpAnimation = new Storyboard();
            var scaleXAnimation = new DoubleAnimation
            {
                To = scaleAmount,
                Duration = animDuration,
                EnableDependentAnimation = true,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            var scaleYAnimation = new DoubleAnimation
            {
                To = scaleAmount,
                Duration = animDuration,
                EnableDependentAnimation = true,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            var scaleDownAnimation = new Storyboard();
            var resetScaleXAnimation = new DoubleAnimation
            {
                To = 1.0,
                Duration = animDuration,
                EnableDependentAnimation = true,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            var resetScaleYAnimation = new DoubleAnimation
            {
                To = 1.0,
                Duration = animDuration,
                EnableDependentAnimation = true,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            // Configure the animation targets
            Storyboard.SetTarget(scaleXAnimation, element);
            Storyboard.SetTarget(scaleYAnimation, element);
            Storyboard.SetTarget(resetScaleXAnimation, element);
            Storyboard.SetTarget(resetScaleYAnimation, element);

            // Set target properties
            Storyboard.SetTargetProperty(scaleXAnimation, "(UIElement.RenderTransform).(ScaleTransform.ScaleX)");
            Storyboard.SetTargetProperty(scaleYAnimation, "(UIElement.RenderTransform).(ScaleTransform.ScaleY)");
            Storyboard.SetTargetProperty(resetScaleXAnimation, "(UIElement.RenderTransform).(ScaleTransform.ScaleX)");
            Storyboard.SetTargetProperty(resetScaleYAnimation, "(UIElement.RenderTransform).(ScaleTransform.ScaleY)");

            // Add animations to storyboards
            scaleUpAnimation.Children.Add(scaleXAnimation);
            scaleUpAnimation.Children.Add(scaleYAnimation);
            scaleDownAnimation.Children.Add(resetScaleXAnimation);
            scaleDownAnimation.Children.Add(resetScaleYAnimation);

            // Ensure the element has a ScaleTransform
            if (element.RenderTransform == null || !(element.RenderTransform is ScaleTransform))
            {
                element.RenderTransform = new ScaleTransform { ScaleX = 1, ScaleY = 1 };
                element.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
            }

            // Add event handlers
            element.PointerEntered += (s, e) =>
            {
                scaleUpAnimation.Begin();
                if (playSound)
                {
                    App.PlayHoverSound();
                }
            };

            element.PointerExited += (s, e) =>
            {
                scaleDownAnimation.Begin();
            };
        }

        /// <summary>
        /// Adds a modern ripple effect to a button or similar control
        /// </summary>
        public static void AddRippleEffect(ButtonBase button)
        {
            if (button == null) return;

            // Ensure button has proper style for ripple
            button.Style = Application.Current.Resources["EnhancedButtonStyle"] as Style ?? button.Style;
        }

        /// <summary>
        /// Adds a gentle opacity pulse animation to an element
        /// </summary>
        public static void AddPulseEffect(UIElement element, double minOpacity = 0.8, double maxOpacity = 1.0,
                                         TimeSpan? pulseDuration = null)
        {
            if (element == null) return;

            var duration = pulseDuration ?? TimeSpan.FromSeconds(2);

            var pulseStoryboard = new Storyboard { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };

            var opacityAnimation = new DoubleAnimation
            {
                From = maxOpacity,
                To = minOpacity,
                Duration = duration,
                EnableDependentAnimation = true,
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            Storyboard.SetTarget(opacityAnimation, element);
            Storyboard.SetTargetProperty(opacityAnimation, "Opacity");

            pulseStoryboard.Children.Add(opacityAnimation);
            pulseStoryboard.Begin();
        }
    }
}