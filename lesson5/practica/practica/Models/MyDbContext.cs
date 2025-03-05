using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practica.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<Publishment> Publishments { get; set; }

    public virtual DbSet<SCard> SCards { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TCard> TCards { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3213E83FB050A18E");

            entity.ToTable("Author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3213E83F47B37243");

            entity.ToTable("Book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("comment");
            entity.Property(e => e.IdAuthor)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_author");
            entity.Property(e => e.IdCategory)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_category");
            entity.Property(e => e.IdPublishment)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_publishment");
            entity.Property(e => e.IdTheme)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_theme");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");
            entity.Property(e => e.Pages)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("pages");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("quantity");
            entity.Property(e => e.YearPress)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("year_press");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Authors");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Categories");

            entity.HasOne(d => d.IdPublishmentNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublishment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Press");

            entity.HasOne(d => d.IdThemeNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdTheme)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Themes");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F6CB94F4A");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3213E83F71C95102");

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3213E83FD538E9C2");

            entity.ToTable("Group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDepartment)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_department");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdDepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_Departments");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libs__3213E83F3EB3017D");

            entity.ToTable("Librarian");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Publishment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Press__3213E83F769C9C60");

            entity.ToTable("Publishment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<SCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__S_Cards__3213E83F7E21590D");

            entity.ToTable("S_Cards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateIn)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("date_in");
            entity.Property(e => e.DateOut)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("date_out");
            entity.Property(e => e.IdBook)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_book");
            entity.Property(e => e.IdLibrarian)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_librarian");
            entity.Property(e => e.IdStudent)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_student");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Books");

            entity.HasOne(d => d.IdLibrarianNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdLibrarian)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Libs");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3213E83FE3F27931");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("first_name");
            entity.Property(e => e.IdGroup)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_group");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("last_name");
            entity.Property(e => e.Term)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("term");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Groups");
        });

        modelBuilder.Entity<TCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__T_Cards__3213E83F4446C1D5");

            entity.ToTable("T_Cards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateIn)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("date_in");
            entity.Property(e => e.DateOut)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("date_out");
            entity.Property(e => e.IdBook)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_book");
            entity.Property(e => e.IdLibrarian)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_librarian");
            entity.Property(e => e.IdTeacher)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_teacher");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("FK_T_Cards_Books");

            entity.HasOne(d => d.IdLibrarianNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdLibrarian)
                .HasConstraintName("FK_T_Cards_Libs");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdTeacher)
                .HasConstraintName("FK_T_Cards_Teachers");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3213E83F986F87EF");

            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("first_name");
            entity.Property(e => e.IdDepartment)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("id_department");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("last_name");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK_Teachers_Departments");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Themes__3213E83FDD8BA9E4");

            entity.ToTable("Theme");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
