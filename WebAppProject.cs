using System.Collections.Generic;

namespace ChromaHub
{
    public class WebAppProject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Technologies { get; set; } = new List<string>();

        public static List<WebAppProject> GetWebApps()
        {
            return new List<WebAppProject>
            {
                new WebAppProject
                {
                    Title = "Project NewAngle",
                    Description = "An intelligent chat assistant built with Gemini 1.5 Flash.",
                    ImageUrl = "ms-appx:///Assets/NewAngle.png",
                    Url = "https://new-angle.vercel.app/",
                    Technologies = new List<string> { "JavaScript", "HTML", "CSS", "Gemini 1.5 Flash" }
                },
                new WebAppProject
                {
                    Title = "Project Feel",
                    Description = "A modern, responsive weather app that provides real-time weather updates, a 5-day forecast, and auto-location detection.",
                    ImageUrl = "ms-appx:///Assets/Feel.png",
                    Url = "https://feel-one.vercel.app/",
                    Technologies = new List<string> { "JavaScript", "HTML", "CSS", "Open Weather API" }
                },
                new WebAppProject
                {
                    Title = "Project GoalGuru",
                    Description = "A goal tracking application designed to help users set, track, and achieve their personal and professional goals with intuitive metrics.",
                    ImageUrl = "ms-appx:///Assets/GoalGuru.png",
                    Url = "https://goal-guru-theta.vercel.app/",
                    Technologies = new List<string> { "JavaScript", "HTML", "CSS" }
                },
                new WebAppProject
                {
                    Title = "Project Quizzy",
                    Description = "An interactive quiz platform for students and educators, featuring customizable assessments and real-time feedback mechanisms.",
                    ImageUrl = "ms-appx:///Assets/Quizzy.png",
                    Url = "https://quizzy-dusky.vercel.app/",
                    Technologies = new List<string> { "JavaScript", "HTML", "CSS" }
                },
                new WebAppProject
                {
                    Title = "StudySkill (2024)",
                    Description = "A comprehensive College Management System designed to streamline administrative and academic tasks.",
                    ImageUrl = "ms-appx:///Assets/StudySkill.png",
                    Url = "https://cromaguy.github.io/StudySkill/index.html",
                    Technologies = new List<string> { "JavaScript", "HTML", "CSS", "PHP" }
                },
                new WebAppProject
                {
                    Title = "StudySkill Re",
                    Description = "StudySkill is a comprehensive digital platform designed to streamline academic processes, enhance communication, and provide real-time insights for students, faculty, and administrators.",
                    ImageUrl = "ms-appx:///Assets/StudySkill.png",
                    Url = "https://studyskill.vercel.app/",
                    Technologies = new List<string> { "JavaScript", "HTML", "CSS" }
                }
            };
        }
    }
}