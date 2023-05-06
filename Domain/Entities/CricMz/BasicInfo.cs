using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class BasicInfo : Info
    {
        public string Tags { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
    }

    public class Info
    {
        public string Id { get; set; } = string.Empty; // GUID
        public string Identifier { get; set; } = string.Empty; // Codes / Key_Words ","
        public string QRCode { get; set; } = string.Empty; // need to be encrypted
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Collection { get; set; } = string.Empty; // Collection / Table name
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
