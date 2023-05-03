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
        public DateTime? DeathDate { get; set; } = null;
        public string Nationality { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // need to be encrypted
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Permissions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public UserAdditionalInfo? AdditionalInfo { get; set; } = null;
        public UserSocialInfo? SocialInfo { get; set; } = null;
        public UserPaymentCardInfo? PaymentCardInfo { get; set; } = null;
        public UserBillingInfo? BillingInfo { get; set; } = null;
        public List<UserNationality>? Nationalities { get; set; } = null;
        public UserLife? Life { get; set; } = null;
        public List<UserAuthorization> Authorizations { get; set; } = new List<UserAuthorization>();
        public UserTechnicalInfo? TechnicalInfo { get; set; } = new UserTechnicalInfo();
    }

    public class UserPlace
    {
        public string Location { get; set; } = string.Empty;
        public string Lat { get; set; } = string.Empty;
        public string Long { get; set; } = string.Empty;
        public string In { get; set; } = string.Empty;
        public string At { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }

    public class UserNationality
    {
        public string Visa { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public DateTime? IssuedDate { get; set; } = null;
        public DateTime? ExpirationDate { get; set; } = null;
        public bool IsByBorn { get; set; } = false;
        public bool IsPermanent { get; set; } = false;
    }

    public class UserPaymentCardInfo
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

    public class UserBillingInfo
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

    public class UserAdditionalInfo
    {
        public string FirstName { get; set; } = string.Empty; // Mamunuz
        public string MiddleName { get; set; } = string.Empty; // Zaman
        public string LastName { get; set; } = string.Empty; // Sarker
        public string NickName { get; set; } = string.Empty; // Munna
        public string TitleName { get; set; } = string.Empty; // Mzs || Mzsmunna
        public List<UserContractInfo>? Contracts { get; set; } = null;
        public List<UserAddressInfo>? Addresses { get; set; } = null;
        public UserPlace? BirthPlace { get; set; } = null;
        public UserPlace? DeathPlace { get; set; } = null;
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public bool IsLeftie { get; set; } = false;
        public string LifeGoals { get; set; } = string.Empty; // ","
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

    public class UserAddressInfo
    {
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }

    public class UserContractInfo
    {
        public string Category { get; set; } = string.Empty; // "home" / "office" / "personal" / "other"
        public string Email { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

    public class UserSocialInfo
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
        public List<UserAccessLink>? Others { get; set; } = null;
    }

    public class UserAccessLink
    {
        public string Id { get; set; } = string.Empty;
        public string ParentID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Sections { get; set; } = string.Empty; // ","
        public string Permissions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public string BaseUrl { get; set; } = string.Empty;
        public string DomainUrl { get; set; } = string.Empty;
        public string SubUrl { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool AsDefaultRedirectUrl { get; set; } = false;
        public bool AsOpenInNewTab { get; set; } = true;
        public int OrderNo { get; set; } = 0;
    }

    public class UserProfession
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "Job", "Business", "Entrepreneur", "Intrapreneur", "Sports", "Music", "Film", "Tourist" etc
        public string LogisticID { get; set; } = string.Empty;
        public string LogisticName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool AsInternship { get; set; } = false;
        public bool AsHobby { get; set; } = false;
        public bool AsPartTime { get; set; } = false;
        public bool IsRetired { get; set; } = false;
        public bool IsSelfEmployed { get; set; } = false;
    }

    public class UserEducation
    {
        public string InstitutionID { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public string InstitutionType { get; set; } = string.Empty;
        public string InstitutionFrom { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UserCertification
    {
        public string Id { get; set; } = string.Empty;
        public string CredentialID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty; // Institution, Logistic, User, etc
        public string IssuerID { get; set; } = string.Empty;
        public string IssuerName { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class UserSkill
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string LearnedFrom { get; set; } = string.Empty; // Institution, Logistic, User, etc    
        public string LearnedFromName { get; set; } = string.Empty;
        public string LearnedFromID { get; set; } = string.Empty;
        public string CertificationID { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSelfLearned { get; set; } = false;
        public DateTime LearnedDate { get; set; }
    }

    public class UserProject
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ToolAndTechs { get; set; } = string.Empty; // "C#, Asp.net Core, MongoDB, Reddis, SignalR, RabbitMQ, TypeScript" etc
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new List<string>();
        public string Location { get; set; } = string.Empty;
        public bool IsSideProject { get; set; } = false;
        public bool IsOpenSourced { get; set; } = false;
        public bool IsContributor { get; set; } = false;
        public string LogisticId { get; set; } = string.Empty;
        public string LogisticName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UserAchievement
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null;
        public string Icon { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMilestone { get; set; } = false;
        public DateTime AchievedDate { get; set; }
    }

    public class UserMemoryAndMoment
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Memorable, Funny, Epic, Weird, Awkward, Confusing, Incredible, Amaizing, Awesome, Remarkable, Lovely, Happy, Exciting, Horrifying, Terrific, Scary
        public string Category { get; set; } = string.Empty;
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null;
        public List<string>? Withs { get; set; } = null;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime MomentDate { get; set; }
    }

    public class UserFriendAndFamily
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
        public string UserCover { get; set; } = string.Empty;
        public string Relation { get; set; } = string.Empty; // Friend, Family, Colleague, Wife, Husband, Mom, Dad, Brother, Sister, Uncle, Aunties,  etc
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null;
        public bool IsBloodRelated { get; set; } = false;
        public bool IsClose { get; set; } = false;
        public bool IsBestie { get; set; } = false;
        public bool IsInspiration { get; set; } = false;
        public bool IsGuider { get; set; } = false;
        public DateTime Since { get; set; }
        public DateTime? Till { get; set; }
    }

    public class UserFollow
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // user, logistic, etc
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public bool IsFavourite { get; set; } = false;
        public bool IsInspiration { get; set; } = false;
        public bool IsFamus { get; set; } = false;
        public bool IsCelebrity { get; set; } = false;
        public bool IsSubscribed { get; set; } = false;
        public int Rank { get; set; } = 0;
        public DateTime Since { get; set; }
        public DateTime? Till { get; set; }
    }

    public class UserCareer
    {
        public List<UserProfession>? Professions { get; set; } = null;
        public List<UserEducation>? Educations { get; set; } = null;
        public List<UserCertification>? Certifications { get; set; } = null;
        public List<UserSkill>? Skills { get; set; } = null;
        public List<UserProject>? Projects { get; set; } = null;
        public List<UserAchievement>? Achievements { get; set; } = null;
    }

    public class UserLife
    {
        //public List<string>? TimeLineIDs { get; set; } = null; // Should be new Entity collection with user ID
        public UserCareer? Career { get; set; } = null;
        public List<UserFriendAndFamily>? FriendAndFamilies { get; set; } = null;
        public List<UserMemoryAndMoment>? MemoryAndMoments { get; set; } = null;
        public List<UserFollow>? Followers { get; set; } = null;
        public List<UserFollow>? Followings { get; set; } = null;
    }

    public class UserAuthorization
    {
        public UserRole AppRole { get; set; } = new UserRole();
        public List<UserLogistic>? Logistics { get; set; } = null; // pages, groups, shops, stores, groceries etc
    }

    public class UserLogistic
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsFounder { get; set; } = false;
        public bool IsOwner { get; set; } = false;
        public bool IsSharedOwner { get; set; } = false;
        public int Ownerships { get; set; } = 0; // 0 - 100%
        public List<UserRole> Roles { get; set; } = new List<UserRole>();
    }

    public class UserRole
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; // "admin", "moderator", "agent", "manager", "user"
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // "paid", "subscribed", "in_app_purchase" etc        
        public string Permissions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public List<UserAccessLink> AuthorizedUrls { get; set; } = new List<UserAccessLink>();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = false;
    }

    public class UserTechnicalInfo
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
