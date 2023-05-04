using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class BasicInfo : Info
    {
        public string Title { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;      
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string Urls { get; set; } = string.Empty;
    }

    public class Info
    {
        public string ID { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty; // Code
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
