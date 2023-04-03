using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class UserUniverse : IEntity
    {
        public string Id { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;






        public DateTime? DOB { get; set; } = null;

        public string Nationality { get; set; } = string.Empty; //","
        public string Role { get; set; } = string.Empty; //","



        public string RefreshToken { get; set; } = string.Empty;
        public TechnicalInfo? TechnicalInfo { get; set; } = new TechnicalInfo();
    }

    public class BirthInfo
    {
        public string State { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = null;
        public int? Age { get; set; } = null;
    }

    public class PersonalInfo
    {
        public string FirstName { get; set; } = string.Empty; // Mamunuz
        public string MiddleName { get; set; } = string.Empty; // Zaman
        public string LastName { get; set; } = string.Empty; // Sarker
        public string NickName { get; set; } = string.Empty; // Munna
        public string TitleName { get; set; } = string.Empty; // Mzs || Mzsmunna
        public string Gender { get; set; } = string.Empty; // male / female / transgender / other
        public BirthInfo? BirthInfo { get; set; }
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public bool IsLefty { get; set; } = false;
        public string Hobbies { get; set; } = string.Empty; // ","
        public string Interests { get; set; } = string.Empty; // ","
        public string Genres { get; set; } = string.Empty; // ","
        public string Tastes { get; set; } = string.Empty; // ","
        public string Personality { get; set; } = string.Empty; // ","
        public string Attitude { get; set; } = string.Empty; // ","
        public string Behavior { get; set; } = string.Empty; // ","
        public string RecentMood { get; set; } = string.Empty; // ","
        public string CurrentMood { get; set; } = string.Empty; // ","
    }

    public class Career
    {
        
    }

    public class TechnicalInfo
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // need to be encrypted
        
        [BsonIgnore]
        public byte[]? PasswordHash { get; set; }
        
        [BsonIgnore]
        public byte[]? PasswordSalt { get; set; }
        
        [BsonIgnore]
        public DateTime? TokenCreated { get; set; }
        
        [BsonIgnore]
        public DateTime? TokenExpires { get; set; }
        public bool? IsActive { get; set; } = false;
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
