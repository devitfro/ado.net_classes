using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practica_2.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnketaRate> AnketaRates { get; set; }

    public virtual DbSet<AnketaView> AnketaViews { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Datingtarget> Datingtargets { get; set; }

    public virtual DbSet<Drinking> Drinkings { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Eyescolor> Eyescolors { get; set; }

    public virtual DbSet<Fashion> Fashions { get; set; }

    public virtual DbSet<Figure> Figures { get; set; }

    public virtual DbSet<Framework> Frameworks { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<GiftService> GiftServices { get; set; }

    public virtual DbSet<Goroskop> Goroskops { get; set; }

    public virtual DbSet<Haircolor> Haircolors { get; set; }

    public virtual DbSet<Intere> Interes { get; set; }

    public virtual DbSet<Kitchen> Kitchens { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Lifetarget> Lifetargets { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Mole> Moles { get; set; }

    public virtual DbSet<Orientation> Orientations { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Residence> Residences { get; set; }

    public virtual DbSet<Richness> Richnesses { get; set; }

    public virtual DbSet<Skincolor> Skincolors { get; set; }

    public virtual DbSet<Smoking> Smokings { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersDatingtarget> UsersDatingtargets { get; set; }

    public virtual DbSet<UsersIntere> UsersInteres { get; set; }

    public virtual DbSet<UsersLanguage> UsersLanguages { get; set; }

    public virtual DbSet<UsersLifetarget> UsersLifetargets { get; set; }

    public virtual DbSet<UsersLookfigure> UsersLookfigures { get; set; }

    public virtual DbSet<UsersMole> UsersMoles { get; set; }

    public virtual DbSet<UsersPlace> UsersPlaces { get; set; }

    public virtual DbSet<UsersSport> UsersSports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Dating;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnketaRate>(entity =>
        {
            entity.ToTable("anketa_rate");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdKogo).HasColumnName("id_kogo");
            entity.Property(e => e.IdKto).HasColumnName("id_kto");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdKogoNavigation).WithMany(p => p.AnketaRateIdKogoNavigations)
                .HasForeignKey(d => d.IdKogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_anketa_rate_users1");

            entity.HasOne(d => d.IdKtoNavigation).WithMany(p => p.AnketaRateIdKtoNavigations)
                .HasForeignKey(d => d.IdKto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_anketa_rate_users");
        });

        modelBuilder.Entity<AnketaView>(entity =>
        {
            entity.ToTable("anketa_view");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdKogo).HasColumnName("id_kogo");
            entity.Property(e => e.IdKto).HasColumnName("id_kto");
            entity.Property(e => e.TimeCode)
                .HasColumnType("datetime")
                .HasColumnName("time_code");

            entity.HasOne(d => d.IdKogoNavigation).WithMany(p => p.AnketaViewIdKogoNavigations)
                .HasForeignKey(d => d.IdKogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_anketa_view_users1");

            entity.HasOne(d => d.IdKtoNavigation).WithMany(p => p.AnketaViewIdKtoNavigations)
                .HasForeignKey(d => d.IdKto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_anketa_view_users");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdRegion).HasColumnName("id_region");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdRegion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_city_region");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Flag)
                .HasMaxLength(50)
                .HasColumnName("flag");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Datingtarget>(entity =>
        {
            entity.ToTable("datingtarget");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Drinking>(entity =>
        {
            entity.ToTable("drinking");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.ToTable("drugs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.ToTable("education");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Eyescolor>(entity =>
        {
            entity.ToTable("eyescolor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Fashion>(entity =>
        {
            entity.ToTable("fashion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Figure>(entity =>
        {
            entity.ToTable("figure");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.NameRod)
                .HasMaxLength(30)
                .HasColumnName("name_rod");
        });

        modelBuilder.Entity<Framework>(entity =>
        {
            entity.ToTable("framework");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("gender");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GiftService>(entity =>
        {
            entity.ToTable("gift_service");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdFrom).HasColumnName("id_from");
            entity.Property(e => e.IdTo).HasColumnName("id_to");
            entity.Property(e => e.Message)
                .HasMaxLength(200)
                .HasColumnName("message");
            entity.Property(e => e.TimeCode)
                .HasColumnType("datetime")
                .HasColumnName("time_code");

            entity.HasOne(d => d.IdFromNavigation).WithMany(p => p.GiftServiceIdFromNavigations)
                .HasForeignKey(d => d.IdFrom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gift_service_users");

            entity.HasOne(d => d.IdToNavigation).WithMany(p => p.GiftServiceIdToNavigations)
                .HasForeignKey(d => d.IdTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gift_service_users1");
        });

        modelBuilder.Entity<Goroskop>(entity =>
        {
            entity.ToTable("goroskop");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Do)
                .HasMaxLength(4)
                .HasColumnName("do");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Ot)
                .HasMaxLength(4)
                .HasColumnName("ot");
        });

        modelBuilder.Entity<Haircolor>(entity =>
        {
            entity.ToTable("haircolor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Intere>(entity =>
        {
            entity.ToTable("interes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Kitchen>(entity =>
        {
            entity.ToTable("kitchen");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("languages");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Predlog)
                .HasMaxLength(30)
                .HasColumnName("predlog");
        });

        modelBuilder.Entity<Lifetarget>(entity =>
        {
            entity.ToTable("lifetargets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("messages");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateSent)
                .HasColumnType("datetime")
                .HasColumnName("date_sent");
            entity.Property(e => e.IdFrom).HasColumnName("id_from");
            entity.Property(e => e.IdTo).HasColumnName("id_to");
            entity.Property(e => e.Mess).HasColumnName("mess");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdFromNavigation).WithMany(p => p.MessageIdFromNavigations)
                .HasForeignKey(d => d.IdFrom)
                .HasConstraintName("FK_messages_users");

            entity.HasOne(d => d.IdToNavigation).WithMany(p => p.MessageIdToNavigations)
                .HasForeignKey(d => d.IdTo)
                .HasConstraintName("FK_messages_users1");
        });

        modelBuilder.Entity<Mole>(entity =>
        {
            entity.ToTable("moles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Orientation>(entity =>
        {
            entity.ToTable("orientation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("region");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_region_country");
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.ToTable("religion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Residence>(entity =>
        {
            entity.ToTable("residence");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Richness>(entity =>
        {
            entity.ToTable("richness");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Skincolor>(entity =>
        {
            entity.ToTable("skincolor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Smoking>(entity =>
        {
            entity.ToTable("smoking");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.ToTable("sport");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.AnkAbout)
                .HasMaxLength(200)
                .HasColumnName("ank_about");
            entity.Property(e => e.AnkIdontlike)
                .HasMaxLength(200)
                .HasColumnName("ank_idontlike");
            entity.Property(e => e.AnkIlike)
                .HasMaxLength(200)
                .HasColumnName("ank_ilike");
            entity.Property(e => e.AnkTargets)
                .HasMaxLength(200)
                .HasColumnName("ank_targets");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.Branch)
                .HasMaxLength(100)
                .HasColumnName("branch");
            entity.Property(e => e.CatBax).HasColumnName("cat_bax");
            entity.Property(e => e.CatCent).HasColumnName("cat_cent");
            entity.Property(e => e.CheckPoint)
                .HasColumnType("datetime")
                .HasColumnName("check_point");
            entity.Property(e => e.DatingTarget)
                .HasMaxLength(250)
                .HasColumnName("dating_target");
            entity.Property(e => e.Deviz)
                .HasMaxLength(200)
                .HasColumnName("deviz");
            entity.Property(e => e.Domtel)
                .HasMaxLength(100)
                .HasColumnName("domtel");
            entity.Property(e => e.EyesColor).HasColumnName("eyes_color");
            entity.Property(e => e.HairColor).HasColumnName("hair_color");
            entity.Property(e => e.Icq)
                .HasMaxLength(100)
                .HasColumnName("icq");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEducation).HasColumnName("id_education");
            entity.Property(e => e.IdFramework).HasColumnName("id_framework");
            entity.Property(e => e.IdZodiak).HasColumnName("id_zodiak");
            entity.Property(e => e.InteresMore)
                .HasMaxLength(100)
                .HasColumnName("interes_more");
            entity.Property(e => e.Ip)
                .HasMaxLength(150)
                .HasColumnName("ip");
            entity.Property(e => e.Job)
                .HasMaxLength(100)
                .HasColumnName("job");
            entity.Property(e => e.LastIp)
                .HasMaxLength(150)
                .HasColumnName("last_ip");
            entity.Property(e => e.LikeBeverages)
                .HasMaxLength(100)
                .HasColumnName("like_beverages");
            entity.Property(e => e.LikeBooks)
                .HasMaxLength(100)
                .HasColumnName("like_books");
            entity.Property(e => e.LikeCars)
                .HasMaxLength(100)
                .HasColumnName("like_cars");
            entity.Property(e => e.LikeCloth)
                .HasMaxLength(100)
                .HasColumnName("like_cloth");
            entity.Property(e => e.LikeColors)
                .HasMaxLength(100)
                .HasColumnName("like_colors");
            entity.Property(e => e.LikeDishes)
                .HasMaxLength(100)
                .HasColumnName("like_dishes");
            entity.Property(e => e.LikeDream)
                .HasMaxLength(100)
                .HasColumnName("like_dream");
            entity.Property(e => e.LikeFilms)
                .HasMaxLength(100)
                .HasColumnName("like_films");
            entity.Property(e => e.LikeGames)
                .HasMaxLength(100)
                .HasColumnName("like_games");
            entity.Property(e => e.LikeGroups)
                .HasMaxLength(100)
                .HasColumnName("like_groups");
            entity.Property(e => e.LikeKitchen).HasColumnName("like_kitchen");
            entity.Property(e => e.LikeLearn)
                .HasMaxLength(100)
                .HasColumnName("like_learn");
            entity.Property(e => e.LikeMobiles)
                .HasMaxLength(100)
                .HasColumnName("like_mobiles");
            entity.Property(e => e.LikeParfum)
                .HasMaxLength(100)
                .HasColumnName("like_parfum");
            entity.Property(e => e.LikeShoes)
                .HasMaxLength(100)
                .HasColumnName("like_shoes");
            entity.Property(e => e.Lj)
                .HasMaxLength(100)
                .HasColumnName("lj");
            entity.Property(e => e.LookSponsor).HasColumnName("look_sponsor");
            entity.Property(e => e.LookingAge).HasColumnName("looking_age");
            entity.Property(e => e.LookingMan).HasColumnName("looking_man");
            entity.Property(e => e.LookingMore)
                .HasMaxLength(100)
                .HasColumnName("looking_more");
            entity.Property(e => e.LookingWoman).HasColumnName("looking_woman");
            entity.Property(e => e.Mobtel)
                .HasMaxLength(100)
                .HasColumnName("mobtel");
            entity.Property(e => e.MyBuild).HasColumnName("my_build");
            entity.Property(e => e.MyDrink).HasColumnName("my_drink");
            entity.Property(e => e.MyDrugs).HasColumnName("my_drugs");
            entity.Property(e => e.MyHome).HasColumnName("my_home");
            entity.Property(e => e.MyRich).HasColumnName("my_rich");
            entity.Property(e => e.MySmoke).HasColumnName("my_smoke");
            entity.Property(e => e.MyStyle).HasColumnName("my_style");
            entity.Property(e => e.Mysites)
                .HasMaxLength(100)
                .HasColumnName("mysites");
            entity.Property(e => e.Nick)
                .HasMaxLength(50)
                .HasColumnName("nick");
            entity.Property(e => e.Orient).HasColumnName("orient");
            entity.Property(e => e.Post)
                .HasMaxLength(100)
                .HasColumnName("post");
            entity.Property(e => e.RecMess).HasColumnName("rec_mess");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Rost).HasColumnName("rost");
            entity.Property(e => e.SendedMess).HasColumnName("sended_mess");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.SkinColor).HasColumnName("skin_color");
            entity.Property(e => e.Skype)
                .HasMaxLength(100)
                .HasColumnName("skype");
            entity.Property(e => e.SocialActivity)
                .HasMaxLength(100)
                .HasColumnName("social_activity");
            entity.Property(e => e.SportMore)
                .HasMaxLength(100)
                .HasColumnName("sport_more");
            entity.Property(e => e.TimeInGame).HasColumnName("time_in_game");
            entity.Property(e => e.TimeRegistration)
                .HasColumnType("datetime")
                .HasColumnName("time_registration");
            entity.Property(e => e.Ves).HasColumnName("ves");
            entity.Property(e => e.WantedBuild)
                .HasMaxLength(100)
                .HasColumnName("wanted_build");
            entity.Property(e => e.WasInGame).HasColumnName("was_in_game");

            entity.HasOne(d => d.EyesColorNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.EyesColor)
                .HasConstraintName("FK_users_eyescolor");

            entity.HasOne(d => d.HairColorNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.HairColor)
                .HasConstraintName("FK_users_haircolor");

            entity.HasOne(d => d.IdEducationNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdEducation)
                .HasConstraintName("FK_users_education");

            entity.HasOne(d => d.IdFrameworkNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdFramework)
                .HasConstraintName("FK_users_framework");

            entity.HasOne(d => d.IdZodiakNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdZodiak)
                .HasConstraintName("FK_users_goroskop");

            entity.HasOne(d => d.LikeKitchenNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.LikeKitchen)
                .HasConstraintName("FK_users_kitchen");

            entity.HasOne(d => d.MyBuildNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MyBuild)
                .HasConstraintName("FK_users_figure");

            entity.HasOne(d => d.MyDrinkNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MyDrink)
                .HasConstraintName("FK_users_drinking");

            entity.HasOne(d => d.MyDrugsNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MyDrugs)
                .HasConstraintName("FK_users_drugs");

            entity.HasOne(d => d.MyHomeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MyHome)
                .HasConstraintName("FK_users_residence");

            entity.HasOne(d => d.MyRichNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MyRich)
                .HasConstraintName("FK_users_richness");

            entity.HasOne(d => d.MySmokeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MySmoke)
                .HasConstraintName("FK_users_smoking");

            entity.HasOne(d => d.MyStyleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MyStyle)
                .HasConstraintName("FK_users_fashion");

            entity.HasOne(d => d.OrientNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Orient)
                .HasConstraintName("FK_users_orientation");

            entity.HasOne(d => d.ReligionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Religion)
                .HasConstraintName("FK_users_religion");

            entity.HasOne(d => d.SexNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Sex)
                .HasConstraintName("FK_users_gender");

            entity.HasOne(d => d.SkinColorNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.SkinColor)
                .HasConstraintName("FK_users_skincolor");
        });

        modelBuilder.Entity<UsersDatingtarget>(entity =>
        {
            entity.ToTable("users_datingtarget");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DatingtargetId).HasColumnName("datingtarget_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Datingtarget).WithMany(p => p.UsersDatingtargets)
                .HasForeignKey(d => d.DatingtargetId)
                .HasConstraintName("FK_users_datingtarget_datingtarget");

            entity.HasOne(d => d.User).WithMany(p => p.UsersDatingtargets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_users_datingtarget_users");
        });

        modelBuilder.Entity<UsersIntere>(entity =>
        {
            entity.ToTable("users_interes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.InteresId).HasColumnName("interes_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Interes).WithMany(p => p.UsersInteres)
                .HasForeignKey(d => d.InteresId)
                .HasConstraintName("FK_users_interes_interes");

            entity.HasOne(d => d.User).WithMany(p => p.UsersInteres)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_users_interes_users");
        });

        modelBuilder.Entity<UsersLanguage>(entity =>
        {
            entity.ToTable("users_languages");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LanguagesId).HasColumnName("languages_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Languages).WithMany(p => p.UsersLanguages)
                .HasForeignKey(d => d.LanguagesId)
                .HasConstraintName("FK_users_languages_languages");

            entity.HasOne(d => d.User).WithMany(p => p.UsersLanguages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_users_languages_users");
        });

        modelBuilder.Entity<UsersLifetarget>(entity =>
        {
            entity.ToTable("users_lifetargets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LifetargetsId).HasColumnName("lifetargets_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Lifetargets).WithMany(p => p.UsersLifetargets)
                .HasForeignKey(d => d.LifetargetsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_lifetargets_lifetargets");

            entity.HasOne(d => d.User).WithMany(p => p.UsersLifetargets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_lifetargets_users");
        });

        modelBuilder.Entity<UsersLookfigure>(entity =>
        {
            entity.ToTable("users_lookfigures");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FigureId).HasColumnName("figure_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Figure).WithMany(p => p.UsersLookfigures)
                .HasForeignKey(d => d.FigureId)
                .HasConstraintName("FK_users_lookfigures_figure");

            entity.HasOne(d => d.User).WithMany(p => p.UsersLookfigures)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_users_lookfigures_users");
        });

        modelBuilder.Entity<UsersMole>(entity =>
        {
            entity.ToTable("users_moles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MolesId).HasColumnName("moles_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Moles).WithMany(p => p.UsersMoles)
                .HasForeignKey(d => d.MolesId)
                .HasConstraintName("FK_users_moles_moles");

            entity.HasOne(d => d.User).WithMany(p => p.UsersMoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_users_moles_users");
        });

        modelBuilder.Entity<UsersPlace>(entity =>
        {
            entity.ToTable("users_place");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.City).WithMany(p => p.UsersPlaces)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_place_city");

            entity.HasOne(d => d.Country).WithMany(p => p.UsersPlaces)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_place_country");

            entity.HasOne(d => d.Region).WithMany(p => p.UsersPlaces)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_place_region");

            entity.HasOne(d => d.User).WithMany(p => p.UsersPlaces)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_place_users");
        });

        modelBuilder.Entity<UsersSport>(entity =>
        {
            entity.ToTable("users_sport");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.SportId).HasColumnName("sport_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Sport).WithMany(p => p.UsersSports)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK_users_sport_sport");

            entity.HasOne(d => d.User).WithMany(p => p.UsersSports)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_users_sport_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
