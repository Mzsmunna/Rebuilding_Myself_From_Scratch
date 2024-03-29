﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [BsonIgnore]
        public byte[]? PasswordHash { get; set; }

        [BsonIgnore]
        public byte[]? PasswordSalt { get; set; }

        [BsonIgnore]
        public DateTime? TokenCreated { get; set; }

        [BsonIgnore]
        public DateTime? TokenExpires { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool? IsActive { get; set; } = false;
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
