using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Team : IEntity
    {
        public string ID { get; set; } = string.Empty;
        public string Identity { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // BAN, ENG, CSK, MI, etc
        public string Type { get; set; } = string.Empty; // International, National, Domestic, Franchise, Local, Street, Gully, Indoor
        public string BoardName { get; set; } = string.Empty;
        public string OrganizationName { get; set; } = string.Empty;
        public string OwnersName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
