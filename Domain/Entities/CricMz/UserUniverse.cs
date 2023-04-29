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
        public string Name { get; set; } = string.Empty; // Mamunuz zaman sarker
        public string Gender { get; set; } = string.Empty; // male / female / transgender / other
        public int Age { get; set; } = 0;
        public DateTime? BirthDate { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // need to be encrypted
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string CurrentRole { get; set; } = string.Empty; // ","
        public AdditionalInfo? AdditionalInfo { get; set; } = null;
        public SocialInfo? SocialInfo { get; set; } = null;
        public PaymentCardInfo? PaymentCardInfo { get; set; } = null;
        public BillingInfo? BillingInfo { get; set; } = null;
        public List<Nationality>? Nationalities { get; set; } = null;
        public Career? Career { get; set; } = null;
        public List<Permission> Permissions { get; set; } = new List<Permission>();
        public TechnicalInfo? TechnicalInfo { get; set; } = new TechnicalInfo();
    }

    public class BirthPlace
    {
        public string Location { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }

    public class Nationality
    {
        public string Visa { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public DateTime? IssuedDate { get; set; } = null;
        public DateTime? ExpirationDate { get; set; } = null;
        public bool IsByBorn { get; set; } = false;
        public bool IsPermanent { get; set; } = false;
    }

    public class PaymentCardInfo
    {
        // Credit card details
        public string CardNumber { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }

    public class BillingInfo
    {
        // Billing address
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
    }

    public class AdditionalInfo
    {
        public string FirstName { get; set; } = string.Empty; // Mamunuz
        public string MiddleName { get; set; } = string.Empty; // Zaman
        public string LastName { get; set; } = string.Empty; // Sarker
        public string NickName { get; set; } = string.Empty; // Munna
        public string TitleName { get; set; } = string.Empty; // Mzs || Mzsmunna
        public List<ContractInfo>? Contracts { get; set; } = null;
        public List<AddressInfo>? Addresses { get; set; } = null;
        public BirthPlace? BirthPlace { get; set; } = null;
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public bool IsLefty { get; set; } = false;
        public string Hobbies { get; set; } = string.Empty; // ","
        public string Interests { get; set; } = string.Empty; // ","
        public string Genres { get; set; } = string.Empty; // ","
        public string Tastes { get; set; } = string.Empty; // ","
        public string Personalities { get; set; } = string.Empty; // ","
        public string Attitude { get; set; } = string.Empty; // ","
        public string Behavior { get; set; } = string.Empty; // ","
        public string RecentMood { get; set; } = string.Empty; // ","
        public string CurrentMood { get; set; } = string.Empty; // ","
    }

    public class AddressInfo
    {
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }

    public class ContractInfo
    {
        public string Category { get; set; } = string.Empty; // "home" / "office" / "personal" / "other"
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }

    public class SocialInfo
    {
        public string LinkedInProfile { get; set; } = string.Empty;
        public string GitHubProfile { get; set; } = string.Empty;
        public string GitLabProfile { get; set; } = string.Empty;
        public string FacebookProfile { get; set; } = string.Empty;
        public string InstagramProfile { get; set; } = string.Empty;
        public string TwitterProfile { get; set; } = string.Empty;
        public string GoogleProfile { get; set; } = string.Empty;
        public string YoutubeProfile { get; set; } = string.Empty;
        public string MicrosoftProfile { get; set; } = string.Empty;
        public string DiscordProfile { get; set; } = string.Empty;
        public string TwitchProfile { get; set; } = string.Empty;
        public string SlackProfile { get; set; } = string.Empty;
        public string ZoomProfile { get; set; } = string.Empty;
        public List<Link>? Others { get; set; } = null;
    }

    public class Link
    {
        public string Id { get; set; } = string.Empty;
        public string ParentID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Actions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public string BaseUrl { get; set; } = string.Empty;
        public string DomainUrl { get; set; } = string.Empty;
        public string SubUrl { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsDefaultRedirectUrl { get; set; } = false;
        public bool IsOpenInNewTab { get; set; } = true;
        public int Order { get; set; } = 0;
    }

    public class Profession
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "Job", "Business", "Entrepreneur", "Intrapreneur", "Sports", "Music", "Film", "Tourist" etc
        public string OrganizationID { get; set; } = string.Empty;
        public string OrganizationName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AsInternship { get; set; } = false;
        public bool AsHobby { get; set; } = false;
        public bool AsPartTime { get; set; } = false;
        public bool IsRetired { get; set; } = false;
        public bool IsSelfEmployed { get; set; } = false;
    }

    public class Education
    {
        public string Institution { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;     
        public string Description { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Certification
    {
        public string CredentialID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string IssuerID { get; set; } = string.Empty;
        public string IssuerName { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool IsSideProject { get; set; } = false;
        public bool IsOpenSourced { get; set; } = false;
        public bool IsContributor { get; set; } = false;
        public string OrganizationId { get; set; } = string.Empty;
        public string OrganizationName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Career
    {
        //public List<string>? TimeLineIDs { get; set; } = null; // Should be new Entity collection with user ID
        public string CurrentStatus { get; set; } = string.Empty;
        public List<Profession>? AllProfessions { get; set; } = null;
        public List<Education>? Educations { get; set; } = null;
        public List<Certification>? Certifications { get; set; } = null;
        public List<Project>? Projects { get; set; } = null;
    }

    public class Permission
    {
        public Role AppRole { get; set; } = new Role();
        public List<Organization>? Organizations { get; set; } = null; // pages, groups, shops, stores, groceries etc
    }

    public class Organization
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsFounder { get; set; } = false;
        public bool IsSharedOwner { get; set; } = false;
        public int Ownerships { get; set; } = 0; // 0 - 100%
        public List<Role> Roles { get; set; } = new List<Role>();
    }

    public class Role
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; // "admin", "moderator", "agent", "manager", "user"
        public string Category { get; set; } = string.Empty; // "paid", "subscribed", "in_app_purchase" etc
        public string Title { get; set; } = string.Empty;
        public List<Link> AuthorizedUrls { get; set; } = new List<Link>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = false;
    }

    public class TechnicalInfo
    {
        public string RefreshToken { get; set; } = string.Empty;
        public string ConfirmationCode { get; set; } = string.Empty;
        public bool IsConfirmed { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

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
