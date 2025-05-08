using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace ChromaHub
{
    public sealed partial class ProjectsPage : Page
    {
        public List<ProjectItem> Projects { get; } = new List<ProjectItem>
        {
            new ProjectItem
            {
                Title = "Project NewAngle",
                Description = "An intelligent chat assistant built with Gemini 1.5 Flash.",
                ImageUrl = "ms-appx:///Assets/NewAngle.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS", "Gemini 1.5 Flash" },
                LiveUrl = "https://new-angle.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-NewAngle"
            },
            new ProjectItem
            {
                Title = "Project Feel",
                Description = "A modern, responsive weather app that provides real-time weather updates, a 5-day forecast, and auto-location detection.",
                ImageUrl = "ms-appx:///Assets/Feel.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS", "Open Weather API" },
                LiveUrl = "https://feel-one.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-Feel"
            },
            new ProjectItem
            {
                Title = "Project GoalGuru",
                Description = "A goal tracking application designed to help users set, track, and achieve their personal and professional goals with intuitive metrics.",
                ImageUrl = "ms-appx:///Assets/GoalGuru.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS" },
                LiveUrl = "https://goal-guru-theta.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-GoalGuru"
            },
            new ProjectItem
            {
                Title = "Project Quizzy",
                Description = "An interactive quiz platform for students and educators, featuring customizable assessments and real-time feedback mechanisms.",
                ImageUrl = "ms-appx:///Assets/Quizzy.png",
                Technologies = new List<string> { "JavaScript", "HTML", "CSS" },
                LiveUrl = "https://quizzy-dusky.vercel.app/",
                GithubUrl = "https://github.com/cromaguy/Project-Quizzy"
            },
            new ProjectItem
            {
                Title = "StudySkill (2024)",
                Description = "A comprehensive College Management System designed to streamline administrative and academic tasks.",
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

        public ProjectsPage()
        {
            this.InitializeComponent();
        }

        private async void ViewLiveButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var url = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(url))
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
            }
        }

        private async void ViewSourceButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var url = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(url))
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
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