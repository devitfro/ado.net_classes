using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class User
{
    public int? Id { get; set; }

    public int UserId { get; set; }

    public string? Nick { get; set; }

    public int? Age { get; set; }

    public DateTime? TimeRegistration { get; set; }

    public int? Sex { get; set; }

    public int? Orient { get; set; }

    public DateTime? Birthday { get; set; }

    public int? IdZodiak { get; set; }

    public string? DatingTarget { get; set; }

    public string? LookingMore { get; set; }

    public string? WantedBuild { get; set; }

    public int? LookingAge { get; set; }

    public int? LookingMan { get; set; }

    public int? LookingWoman { get; set; }

    public int? LookSponsor { get; set; }

    public DateTime? CheckPoint { get; set; }

    public double? CatBax { get; set; }

    public int? CatCent { get; set; }

    public string? Ip { get; set; }

    public string? LastIp { get; set; }

    public string? Deviz { get; set; }

    public string? AnkAbout { get; set; }

    public string? AnkTargets { get; set; }

    public string? AnkIlike { get; set; }

    public string? AnkIdontlike { get; set; }

    public int? Rost { get; set; }

    public int? Ves { get; set; }

    public int? EyesColor { get; set; }

    public int? HairColor { get; set; }

    public int? SkinColor { get; set; }

    public int? MyBuild { get; set; }

    public int? MyHome { get; set; }

    public int? MyRich { get; set; }

    public int? MyStyle { get; set; }

    public int? MySmoke { get; set; }

    public int? MyDrink { get; set; }

    public int? MyDrugs { get; set; }

    public int? Religion { get; set; }

    public string? InteresMore { get; set; }

    public string? SportMore { get; set; }

    public string? LikeDishes { get; set; }

    public string? LikeBeverages { get; set; }

    public int? LikeKitchen { get; set; }

    public string? LikeColors { get; set; }

    public string? LikeGroups { get; set; }

    public string? LikeShoes { get; set; }

    public string? LikeCloth { get; set; }

    public string? LikeParfum { get; set; }

    public string? LikeMobiles { get; set; }

    public string? LikeCars { get; set; }

    public string? LikeGames { get; set; }

    public string? LikeBooks { get; set; }

    public string? LikeFilms { get; set; }

    public string? LikeLearn { get; set; }

    public string? LikeDream { get; set; }

    public int? IdFramework { get; set; }

    public int? IdEducation { get; set; }

    public string? Branch { get; set; }

    public string? Job { get; set; }

    public string? Post { get; set; }

    public string? SocialActivity { get; set; }

    public string? Mobtel { get; set; }

    public string? Domtel { get; set; }

    public string? Icq { get; set; }

    public string? Skype { get; set; }

    public string? Lj { get; set; }

    public string? Mysites { get; set; }

    public string? Avatar { get; set; }

    public int? TimeInGame { get; set; }

    public int? SendedMess { get; set; }

    public int? RecMess { get; set; }

    public int? WasInGame { get; set; }

    public virtual ICollection<AnketaRate> AnketaRateIdKogoNavigations { get; set; } = new List<AnketaRate>();

    public virtual ICollection<AnketaRate> AnketaRateIdKtoNavigations { get; set; } = new List<AnketaRate>();

    public virtual ICollection<AnketaView> AnketaViewIdKogoNavigations { get; set; } = new List<AnketaView>();

    public virtual ICollection<AnketaView> AnketaViewIdKtoNavigations { get; set; } = new List<AnketaView>();

    public virtual Eyescolor? EyesColorNavigation { get; set; }

    public virtual ICollection<GiftService> GiftServiceIdFromNavigations { get; set; } = new List<GiftService>();

    public virtual ICollection<GiftService> GiftServiceIdToNavigations { get; set; } = new List<GiftService>();

    public virtual Haircolor? HairColorNavigation { get; set; }

    public virtual Education? IdEducationNavigation { get; set; }

    public virtual Framework? IdFrameworkNavigation { get; set; }

    public virtual Goroskop? IdZodiakNavigation { get; set; }

    public virtual Kitchen? LikeKitchenNavigation { get; set; }

    public virtual ICollection<Message> MessageIdFromNavigations { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageIdToNavigations { get; set; } = new List<Message>();

    public virtual Figure? MyBuildNavigation { get; set; }

    public virtual Drinking? MyDrinkNavigation { get; set; }

    public virtual Drug? MyDrugsNavigation { get; set; }

    public virtual Residence? MyHomeNavigation { get; set; }

    public virtual Richness? MyRichNavigation { get; set; }

    public virtual Smoking? MySmokeNavigation { get; set; }

    public virtual Fashion? MyStyleNavigation { get; set; }

    public virtual Orientation? OrientNavigation { get; set; }

    public virtual Religion? ReligionNavigation { get; set; }

    public virtual Gender? SexNavigation { get; set; }

    public virtual Skincolor? SkinColorNavigation { get; set; }

    public virtual ICollection<UsersDatingtarget> UsersDatingtargets { get; set; } = new List<UsersDatingtarget>();

    public virtual ICollection<UsersIntere> UsersInteres { get; set; } = new List<UsersIntere>();

    public virtual ICollection<UsersLanguage> UsersLanguages { get; set; } = new List<UsersLanguage>();

    public virtual ICollection<UsersLifetarget> UsersLifetargets { get; set; } = new List<UsersLifetarget>();

    public virtual ICollection<UsersLookfigure> UsersLookfigures { get; set; } = new List<UsersLookfigure>();

    public virtual ICollection<UsersMole> UsersMoles { get; set; } = new List<UsersMole>();

    public virtual ICollection<UsersPlace> UsersPlaces { get; set; } = new List<UsersPlace>();

    public virtual ICollection<UsersSport> UsersSports { get; set; } = new List<UsersSport>();
}
