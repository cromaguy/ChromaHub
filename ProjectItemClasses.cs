using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
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
        }
    }
}