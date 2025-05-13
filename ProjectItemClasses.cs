using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaHub
{
    // Define a separate namespace for project items to avoid ambiguity
    namespace ProjectModels
    {
        public class ProjectItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public string ProjectUrl { get; set; }
            public string SourceUrl { get; set; }
            public List<string> Technologies { get; set; } = new List<string>();

            // Add these properties to match the ChromaHub.ProjectItem
            public string ImageUrl => ImagePath;
            public string LiveUrl => ProjectUrl;
            public string GithubUrl => SourceUrl;

            public bool HasLiveUrl => !string.IsNullOrEmpty(LiveUrl);
            public bool HasGithubUrl => !string.IsNullOrEmpty(GithubUrl);
        }
    }
}