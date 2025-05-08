using System;

namespace App1.ProjectModels
{
    // Add the missing ProjectItem class that's referenced in HomePage.xaml.cs
    public class ProjectItem1
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ProjectUrl { get; set; }
        public string SourceUrl { get; set; }
    }
}