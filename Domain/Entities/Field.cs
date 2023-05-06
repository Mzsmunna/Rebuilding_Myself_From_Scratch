using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Field
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class Caption : Field
    {
        public string KeyIcon { get; set; } = string.Empty;
        public string KeyLink { get; set; } = string.Empty;
        public string ValueIcon { get; set; } = string.Empty;
        public string ValueLink { get; set; } = string.Empty;
    }
}
