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
        public string Identifier { get; set; } = string.Empty; // ","
        public string Platforms { get; set; } = string.Empty; // App / Web App name ","
        public string FirstName { get; set; } = string.Empty; // Mamunuz
        public string MiddleName { get; set; } = string.Empty; // Zaman
        public string LastName { get; set; } = string.Empty; // Sarker
        public string NickName { get; set; } = string.Empty; // Munna
        public string SurName { get; set; } = string.Empty; // Mamun
        public string TitleName { get; set; } = string.Empty; // Mzs || Mzsmunna
        public string Name { get; set; } = string.Empty; // Mamunuz zaman sarker
        public string Gender { get; set; } = string.Empty; // male / female / transgender / other
        public int Age { get; set; } = 0;
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public bool IsLeftie { get; set; } = false;
        public string LifeGoals { get; set; } = string.Empty; // ","
        public string Hobbies { get; set; } = string.Empty; // ","
        public string Interests { get; set; } = string.Empty; // ","
        public string Genres { get; set; } = string.Empty; // ","
        public string Tastes { get; set; } = string.Empty; // ","
        public string Personalities { get; set; } = string.Empty; // ","
        public string Attitudes { get; set; } = string.Empty; // ","
        public string Behaviors { get; set; } = string.Empty; // ","
        public string RecentMoods { get; set; } = string.Empty; // ","
        public string CurrentMoods { get; set; } = string.Empty; // ",
        public DateTime? BirthDate { get; set; } = null;
        public DateTime? DeathDate { get; set; } = null;
        public string Nationality { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // need to be encrypted
        public string FingerPrint { get; set; } = string.Empty; // need to be encrypted
        public string QRCode { get; set; } = string.Empty; // need to be encrypted
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string PresentAddress { get; set; } = string.Empty;
        public string HomeTownAddress { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Permissions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public UserLife? Life { get; set; } = null;
        public UserSocialInfo? SocialInfo { get; set; } = null;
        public UserAdditionalInfo? AdditionalInfo { get; set; } = null;
        public UserTechnicalInfo? TechnicalInfo { get; set; } = null;
        public List<UserAuthorization>? Authorizations { get; set; } = null;     
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

    public class UserIdentity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string CountryID { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string IssuingAuthorityID { get; set; } = string.Empty;
        public string IssuingAuthorityName { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; }
        public bool IsByBorn { get; set; } = false;
    }

    public class UserAccount
    {
        public string Id { get; set; } = string.Empty;
        public string IssuingOrgID { get; set; } = string.Empty;
        public string IssuingOrgName { get; set; } = string.Empty;
        public string OrgType { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string HolderName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
        public string ESignature { get; set; } = string.Empty;
        public bool IsAppOrWebsite { get; set; } = false;
        public UserCredential? Credential { get; set; } = null;
        public DateTime OpenDate { get; set; } = DateTime.UtcNow;
        public DateTime? CloseDate { get; set; }
    }

    public class UserWallet // might need to be encrypted
    {
        // Credit card details
        public string Id { get; set; } = string.Empty;
        public string IssuingOrgID { get; set; } = string.Empty;
        public string IssuingOrgName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string HolderName { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
    }

    public class UserVisa
    {
        public string Id { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string VisaType { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        public string PassportID { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class UserPassport
    {
        public string Id { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string NationalID { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string PlaceOfIssue { get; set; } = string.Empty;
    }

    public class UserAdditionalInfo
    {
        public List<UserContract>? Contracts { get; set; } = null;
        public List<UserAddress>? Addresses { get; set; } = null;
        public UserPlace? BirthPlace { get; set; } = null;
        public UserPlace? DeathPlace { get; set; } = null;
        public List<UserIdentity>? Identities { get; set; } = null;
        public List<UserAccount>? Accounts { get; set; } = null;
        public List<UserVisa>? Visas { get; set; } = null;
        public List<UserPassport>? Passports { get; set; } = null;
        public List<UserWallet>? Wallets { get; set; } = null;
        public List<UserItem>? Goods { get; set; } = null;
        public List<UserFood>? Foods { get; set; } = null;
        public List<UserContent>? Contents { get; set; } = null;
    }

    public class UserAddress // might need to be encrypted
    {
        public Info? Owner { get; set; } = new Info();
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Flat { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Fare { get; set; } = 0; // Amount
        public string Currency { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty; // Monthly / Weekly / Yearly
        public bool IsRental { get; set; } = false;       
        public bool IsPresentAddress { get; set; } = false;
        public bool IsHomeAddress { get; set; } = false;
        public DateTime Since { get; set; } = DateTime.UtcNow;
        public DateTime? Till { get; set; } = DateTime.UtcNow;
    }

    public class UserContract
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
        public List<UserAccessLink>? OtherProfiles { get; set; } = null;
    }

    public class UserAccessLink
    {
        public string Id { get; set; } = string.Empty;
        public string ParentID { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Sections { get; set; } = string.Empty; // ","
        public string Modules { get; set; } = string.Empty; // ","
        public string Permissions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public string SiteUrl { get; set; } = string.Empty;
        public string SubUrl { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool AsDefaultRedirectUrl { get; set; } = false;
        public bool AsOpenInNewTab { get; set; } = true;
        public int Ordering { get; set; } = 0;
    }

    public class UserBookmark
    {
        public string Id { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Folder { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Attachment { get; set; } = string.Empty;
        public bool IsArcived { get; set; } = false;
        public bool IsFavourite { get; set; } = false;
        public bool IsStarred { get; set; } = false;
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
    }

    public class UserContent
    {
        public string Id { get; set; } = string.Empty;
        public string LinkedId { get; set; } = string.Empty;
        public string LinkedType { get; set; } = string.Empty; // "related-to, blocked-by, caused-by, sub-task, list-item, shared"
        public string QRCode { get; set; } = string.Empty;
        public Info? Manufacturer { get; set; } = null;
        public Info? Owner { get; set; } = null;
        public Info? Vendor { get; set; } = null;
        public Info? Responsible { get; set; } = null; // Assigned to     
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty; // memes, funny, facts, critcs, reality ","
        public string Type { get; set; } = string.Empty; // article, news, post, blog, vlog, issue, poll, course, product, food
        public string Category { get; set; } = string.Empty; // Sports, Business, Politics, Movie, Music, issue => [Story, Task, To-Do, Reminder, Bug, Feature, Concern], poll => [Yes, No, A, B, x, Y, Z, Other]
        public string Folder { get; set; } = string.Empty; // Album
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Privacy { get; set; } = string.Empty; // Private, Personal, Public, Friends&Family, FriendsOfFriends
        public string Priority { get; set; } = string.Empty; // Lowest, Low, Medium, High, Highest
        public string Status { get; set; } = string.Empty; // Pending, In-Progress, Testing, Done, Completed, Released, Resolved, Closed
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null; // formatted html text or xml or json or others file link     
        public List<Specification>? Specifications { get; set; } = null;
        public int Views { get; set; } = 0; // Reach
        public int Comments { get; set; } = 0;
        public int Shares { get; set; } = 0;
        public React? Reacts { get; set; } = null;
        //public List<UserReact>? Reacts { get; set; } = null;
        //public List<UserEngagement>? Engagements { get; set; } = null;
        //public List<ItemAvailability>? AvailableItems { get; set; } = null;
        public List<ContentOption>? Options { get; set; } = null; // Polls
        public bool IsContainer { get; set; } = false;
        public bool IsShortStory { get; set; } = false;
        public bool IsVendorMerged { get; set; } = false;
        public bool IsInStock { get; set; } = false;
        public bool IsVirtualItem { get; set; } = false;
        public bool IsAnAdvertise { get; set; } = false;
        public bool IsAnIssue { get; set; } = false;       
        public bool IsShareable { get; set; } = false;
        public List<Info>? SharedWiths { get; set; } = null;
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
        public DateTime? StartedOn { get; set; } = null;
        public DateTime? TestedOn { get; set; } = null;
        public DateTime? CompletedOn { get; set; } = null;
        public DateTime? ReopenedOn { get; set; } = null;
        public DateTime? ResolvedOn { get; set; } = null;
        public DateTime? ReminderOn { get; set; } = null;
        public string ReminderDuration { get; set; } = string.Empty; // Once, Daily, Weekly, Monday, Friday, etc
    }

    public class StockItem
    {
        public string Id { get; set; } = string.Empty;
        public string QRCode { get; set; } = string.Empty;
        public Info? Vendor { get; set; } = null;
        public Info? Content { get; set; } = null;
        public ItemIdentity? Identity { get; set; } = null;
        public int Available { get; set; } = 0;
        public string MassUnit { get; set; } = string.Empty; // kg, g, pound, etc
        public double UnitPrice { get; set; } = 0;
        public double ManufacturerCost { get; set; } = 0;
        public double ShippingCost { get; set; } = 0;
        public double TotalCost { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
    }

    public class ItemAvailability
    {
        public int Available { get; set; } = 0;
        public bool IsUncountable { get; set; } = false;
        public string MassUnit { get; set; } = string.Empty; // kg, g, pound, etc
        public double PerUnitCost { get; set; } = 0;
        public double ManufacturerCost { get; set; } = 0;
        public double ShippingCost { get; set; } = 0;
        public double DelivaryCost { get; set; } = 0;
        public double TotalCost { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
    }

    public class UserEngagement
    {
        public string Id { get; set; } = string.Empty;
        public string ContentId { get; set; } = string.Empty;
        public string MasterCommentId { get; set; } = string.Empty;
        public string ParentCommentId { get; set; } = string.Empty;
        public Info Commenter { get; set; } = new Info();
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Comment { get; set; } = string.Empty;
        public string Privacy { get; set; } = string.Empty; // Private, Personal, Public, Friends&Family, FriendsOfFriends
        public string Attachment { get; set; } = string.Empty; // formatted html text or xml or json or image or video or others file link
        public React? Reacts { get; set; } = null;
        public Field? OptionPicked { get; set; } = null;
        //public List<UserReact>? Reacts { get; set; } = null;
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
    }

    public class UserItem
    {
        public string Id { get; set; } = string.Empty;
        public ItemIdentity? Identity { get; set; } = null;
        public Info ReceiverInfo { get; set; } = new Info();
        public string ReceivedTransactionID { get; set; } = string.Empty;
        public string ReturnedTransactionID { get; set; } = string.Empty;
        public string SoldTransactionID { get; set; } = string.Empty;
        public string SupplyChainID { get; set; } = string.Empty;
        public Info? ContentInfo { get; set; } = null;
        public Info? ProviderInfo { get; set; } = null;
        public Info? Manufacturer { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Accessory, Gadget, Jwelary, Vehicle, Software etc
        public string Category { get; set; } = string.Empty; // Mobile, Headphone, Bracelet, Car, Bike, Mobile App, Website etc
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null;
        public int Quantity { get; set; } = 0;
        public string MassUnit { get; set; } = string.Empty; // kg, g, pound, etc
        public double UnitPrice { get; set; } = 0;
        public double ManufacturerCost { get; set; } = 0;
        public double ShippingCost { get; set; } = 0;
        public double TotalCost { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
        public double AverageRating { get; set; } = 0;
        public bool IsOwnMade { get; set; } = false;
        public bool IsCustomMade { get; set; } = false;
        public bool IsRequested { get; set; } = false;
        public bool IsPurchased { get; set; } = true;
        public bool IsBrandNew { get; set; } = true;
        public bool IsBorrowed { get; set; } = false;
        public bool IsGifted { get; set; } = false;
        public bool IsFromOnline { get; set; } = false;
        public bool IsVirtualProduct { get; set; } = false;
        public bool IsAvailable { get; set; } = true;
        public bool IsEndUser { get; set; } = true;
        public bool IsShared { get; set; } = false;
        public List<Info>? SharedWiths { get; set; } = null;
        public DateTime AvailableOn { get; set; } = DateTime.UtcNow;
        public DateTime? RequestedOn { get; set; } = null;
        public DateTime? CartedOn { get; set; } = null;
        public DateTime? ReturnedOn { get; set; } = null;
        public DateTime? SoldOn { get; set; } = null;
        public DateTime? PaidOn { get; set; } = null;
        public DateTime? CashReceivedOn { get; set; } = null;
    }

    public class VendorItem // => pre added / existing user add well known Product collection / dictionary to search & include product in your site / shop / business without any new entries
    {
        public string Id { get; set; } = string.Empty;
        public string QRCode { get; set; } = string.Empty;
        public Info? Manufacturer { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Accessory, Gadget, Jwelary, Vehicle, Software etc
        public string Category { get; set; } = string.Empty; // Mobile, Headphone, Bracelet, Car, Bike, Mobile App, Website etc
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Specification>? Specifications { get; set; } = null;
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null;
        //public List<UserReview>? Reviews { get; set; } = null;
        public double AverageRating { get; set; } = 0;
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }

    public class ItemIdentity
    {
        public string QRCode { get; set; } = string.Empty;
        /// <summary>
        /// IMEI (International Mobile Equipment Identity) is a unique identifier assigned to mobile phones and other wireless devices. 
        /// It is a 15-digit number that is used to identify the device on a cellular network. 
        /// The IMEI is typically printed on the back of the phone or can be found by dialing *#06# on the device.
        /// </summary>
        public string IMEI { get; set; } = string.Empty;
        /// <summary>
        /// A serial number is a unique identifier assigned by the manufacturer to a specific product. 
        /// It is often used for electronics, appliances, and other products that require warranty or repair services.
        /// </summary>
        public string SerialNumber { get; set; } = string.Empty;
        /// <summary>
        /// UPC code - A UPC (Universal Product Code) is a barcode that is used to identify a specific product. 
        /// It is typically found on food and beverage products, but can be used for other products as well.
        /// </summary>
        public string UPC { get; set; } = string.Empty;
        /// <summary>
        /// ISBN - An ISBN (International Standard Book Number) is a unique identifier assigned to books and other publications. 
        /// It is used to identify the specific edition of a book and can be helpful for libraries and other organizations that need to keep track of multiple copies of the same title.
        /// </summary>
        public string ISBN { get; set; } = string.Empty;
        /// <summary>
        /// VIN - A VIN (Vehicle Identification Number) is a unique identifier assigned to motor vehicles. 
        /// It is used to track ownership, service records, and other information about a specific vehicle.
        /// </summary>
        public string VIN { get; set; } = string.Empty;
        /// <summary>
        /// MAC address - A MAC (Media Access Control) address is a unique identifier assigned to network interface controllers for use as a network address in communications within a network segment.
        /// </summary>
        public string MACAddress { get; set; } = string.Empty;
    }

    public class Specification
    {
        public string Title { get; set; } = string.Empty;
        public string TitleIcon { get; set; } = string.Empty;
        public string TitleLink { get; set; } = string.Empty;
        public List<Caption> Caption { get; set; } = new List<Caption>();
    }

    public class UserFood
    {
        public string Id { get; set; } = string.Empty;    
        public string DelivaryID { get; set; } = string.Empty;
        public string ReturnedDelivaryID { get; set; } = string.Empty;
        public string SupplyChainID { get; set; } = string.Empty;
        public Info? ContentInfo { get; set; } = null;
        public Info? ProviderInfo { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Accessory, Gadget, Jwelary, Vehicle, Software etc
        public string Category { get; set; } = string.Empty; // Mobile, Headphone, Bracelet, Car, Bike, Mobile App, Website etc
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string>? Images { get; set; } = null;
        public List<string>? Videos { get; set; } = null;
        public List<string>? Attachments { get; set; } = null;
        public int Quantity { get; set; } = 0;
        public string MassUnit { get; set; } = string.Empty; // kg, g, pound, etc
        public double UnitPrice { get; set; } = 0;
        public double TotalCost { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
        public double AverageRating { get; set; } = 0;
        public bool IsHomeMade { get; set; } = false;
        public bool IsRequested { get; set; } = false;
        public bool IsPurchased { get; set; } = true;
        public bool IsCelebrated { get; set; } = false; // Treat
        public bool IsFromOnline { get; set; } = false;
        public bool IsAvailable { get; set; } = true;
        public bool IsEndUser { get; set; } = true;
        public bool IsShared { get; set; } = false;
        public List<Info>? SharedWiths { get; set; } = null;
        public List<Specification>? Ingredients { get; set; } = null;
        public List<UserReview>? Reviews { get; set; } = null;
        public DateTime AvailableOn { get; set; } = DateTime.UtcNow;
        public DateTime? RequestedOn { get; set; } = null;
        public DateTime? CartedOn { get; set; } = null;
        public DateTime? SoldOn { get; set; } = null;
        public DateTime? PaidOn { get; set; } = null;
        public DateTime? CashReceivedOn { get; set; } = null;
    }

    public class ContentRevenue
    {
        public Info Revenuer { get; set; } = new Info();
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string PromoCode { get; set; } = string.Empty; // Might need to be encrypted
        public bool IsPaid { get; set; } = false;
        public bool IsBundled { get; set; } = false;
        public bool IsAddFree { get; set; } = false;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public int RateLimit { get; set; } = 5;
    }

    public class UserReview
    {
        public string VendorID { get; set; } = string.Empty;
        public Info Commenter { get; set; } = new Info();
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public int RateLimit { get; set; } = 5;
    }

    public class UserReact
    {
        public Info Reacter { get; set; } = new Info();
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Type { get; set; } = string.Empty; // Up, Down, Funny, Clap, Love, Report
        public string ReportReason { get; set; } = string.Empty;
    }

    public class React
    {
        public int Total { get; set; } = 0;
        public int UpReacts { get; set; } = 0;
        public int DownReacts { get; set; } = 0;
        public int FunnyReacts { get; set; } = 0;
        public int ClapReacts { get; set; } = 0;
        public int LoveReacts { get; set; } = 0;
        public int ReportReacts { get; set; } = 0;
    }

    public class ContentOption
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Status { get; set; } = string.Empty; // Pending, In-Progress, Testing, Done, Completed, Released, Resolved, Closed
        public int Votes { get; set; } = 0;
        public DateTime? ModifiedOn { get; set; } = null;
        public DateTime? StartedOn { get; set; } = null;
        public DateTime? TestedOn { get; set; } = null;
        public DateTime? CompletedOn { get; set; } = null;
        public DateTime? ReopenedOn { get; set; } = null;
        public DateTime? ResolvedOn { get; set; } = null;
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
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
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
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
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
        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; }
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
        public DateTime LearnedDate { get; set; } = DateTime.UtcNow;
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
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
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
        public DateTime AchievedDate { get; set; } = DateTime.UtcNow;
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
        public DateTime MomentDate { get; set; } = DateTime.UtcNow;
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
        public DateTime Since { get; set; } = DateTime.UtcNow;
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
        public DateTime Since { get; set; } = DateTime.UtcNow;
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
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string QRCode { get; set; } = string.Empty;
        public bool IsFounder { get; set; } = false;
        public bool IsOwner { get; set; } = false;
        public bool IsSharedOwner { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public int Ownerships { get; set; } = 0; // 0 - 100%
        public List<string>? LegalDocuments { get; set; } = null;
        public List<UserRole> Roles { get; set; } = new List<UserRole>();
    }

    public class UserRole
    {
        public string Id { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty; // App / Web App name
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "admin", "moderator", "agent", "manager", "user", "employee"
        public string Category { get; set; } = string.Empty; // "paid", "subscribed", "in_app_purchase" etc        
        public string Permissions { get; set; } = "R"; // "CRUDS", "C", "R", "U", "D", "S", "CR", "UD", "CRU", "RU", "RD", "CD", etc
        public List<UserAccessLink> AuthorizedUrls { get; set; } = new List<UserAccessLink>();
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = false;
    }

    public class UserCredential // need to be encrypted
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SiteName { get; set; } = string.Empty;
        public string SiteUrl { get; set; } = string.Empty;
        public string SiteCategory { get; set; } = string.Empty;
        public string SiteType { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RecoveryEmail { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string RecoveryPhone { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SecurityQuestion { get; set; } = string.Empty;
        public string SecurityAnswer { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool IsTwoFactorAuth { get; set; } = false;
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    }

    public class UserTechnicalInfo
    {
        public string RefreshToken { get; set; } = string.Empty;
        public string ConfirmationCode { get; set; } = string.Empty;
        public bool IsConfirmed { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsTwoFactorAuth { get; set; } = false;

        [BsonIgnore]
        public byte[]? PasswordHash { get; set; }
        
        [BsonIgnore]
        public byte[]? PasswordSalt { get; set; }
        
        [BsonIgnore]
        public DateTime? TokenCreated { get; set; }
        
        [BsonIgnore]
        public DateTime? TokenExpires { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
