using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace ChromaHub
{
    public sealed partial class AboutPage : Page
    {
        public List<SkillItem> ProgrammingLanguages { get; } = new List<SkillItem>
        {
            // Updated with proper Unicode icons for each language
            new SkillItem { Name = "Python", Icon = "\uE917" },  // Python snake icon
            new SkillItem { Name = "Java", Icon = "\uE738" },    // Coffee cup icon for Java
            new SkillItem { Name = "C++", Icon = "\uF152" },     // Code icon for C++
            new SkillItem { Name = "JavaScript", Icon = "\uECF0" }  // JS icon
        };

        public List<SkillItem> FrameworksAndTools { get; } = new List<SkillItem>
        {
            // Updated with proper Unicode icons for frameworks and tools
            new SkillItem { Name = "React", Icon = "\uF1A8" },   // React logo icon
            new SkillItem { Name = "Django", Icon = "\uF111" },  // Web framework icon
            new SkillItem { Name = "Docker", Icon = "\uE7B5" },  // Container icon
            new SkillItem { Name = "AWS", Icon = "\uEB52" }      // Cloud icon
        };

        public AboutPage()
        {
            this.InitializeComponent();
        }
    }

    public class SkillItem
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}