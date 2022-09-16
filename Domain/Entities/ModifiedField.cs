using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ModifiedField
    {
        [BsonIgnore]
        public PropertyInfo PropertyInfo { get; set; }
        public string PropertyType { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string CustomPropertyName { get; set; }
        public string CurrentValue { get; set; }
        public string PreviousValue { get; set; }
        public string CustomCurrentValue { get; set; }
        public string CustomPreviousValue { get; set; }
    }
}
