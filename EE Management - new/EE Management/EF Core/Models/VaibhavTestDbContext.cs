using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models;

public partial class VaibhavTestDbContext : DbContext
{
    public VaibhavTestDbContext()
    {
    }

    public VaibhavTestDbContext(DbContextOptions<VaibhavTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllDatum> AllData { get; set; }

    public virtual DbSet<AllDetail> AllDetails { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAspNetUser> CustomerAspNetUsers { get; set; }

    public virtual DbSet<DancePartner> DancePartners { get; set; }

    public virtual DbSet<DepartmentTbl> DepartmentTbls { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GroupHaving> GroupHavings { get; set; }

    public virtual DbSet<ImagesPath> ImagesPaths { get; set; }

    public virtual DbSet<InnerJoinEx> InnerJoinExes { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<RegularExp> RegularExps { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Split> Splits { get; set; }

    public virtual DbSet<VideosPath> VideosPaths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=111.118.247.43;database=Vaibhav test db;uid=Vaibhav;password=it@321;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("all_data");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
        });

        modelBuilder.Entity<AllDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("all_details");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.DrivingLicence)
                .HasMaxLength(255)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserId");
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK_dbo.CartItems");

            entity.HasIndex(e => e.ProductId, "IX_ProductId");

            entity.Property(e => e.ItemId).HasMaxLength(128);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_dbo.CartItems_dbo.Products_ProductId");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_dbo.Categories");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Customers");

            entity.HasIndex(e => e.MembershipTypeId, "IX_MembershipTypeId");

            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.MembershipType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.MembershipTypeId)
                .HasConstraintName("FK_dbo.Customers_dbo.MembershipTypes_MembershipTypeId");
        });

        modelBuilder.Entity<CustomerAspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CustomerAspNetUsers");

            entity.HasIndex(e => e.ApplicationUserId, "IX_ApplicationUserId").IsUnique();

            entity.HasIndex(e => e.CustomerId, "IX_CustomerId").IsUnique();

            entity.Property(e => e.ApplicationUserId)
                .HasMaxLength(128)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.ApplicationUser).WithOne(p => p.CustomerAspNetUser)
                .HasForeignKey<CustomerAspNetUser>(d => d.ApplicationUserId)
                .HasConstraintName("FK_dbo.CustomerAspNetUsers_dbo.AspNetUsers_ApplicationUserId");

            entity.HasOne(d => d.Customer).WithOne(p => p.CustomerAspNetUser)
                .HasForeignKey<CustomerAspNetUser>(d => d.CustomerId)
                .HasConstraintName("FK_dbo.CustomerAspNetUsers_dbo.Customers_CustomerId");
        });

        modelBuilder.Entity<DancePartner>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dance Partners");

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.StudentId).HasColumnName("Student Id");
        });

        modelBuilder.Entity<DepartmentTbl>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Department");

            entity.ToTable("Department_tbl");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Emp).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Genres");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<GroupHaving>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("group_having");

            entity.Property(e => e.CountAll).HasColumnName("Count All");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameHello)
                .HasMaxLength(56)
                .IsUnicode(false)
                .HasColumnName("Name HELLO");
            entity.Property(e => e.SumAge).HasColumnName("SUM AGE");
            entity.Property(e => e.SumId).HasColumnName("SUM ID");
        });

        modelBuilder.Entity<ImagesPath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ImagesPaths");
        });

        modelBuilder.Entity<InnerJoinEx>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("inner_join_ex");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Cityname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cityname");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Pname)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MembershipType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.MembershipTypes");

            entity.Property(e => e.Name).HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Movies");

            entity.HasIndex(e => e.GenreId, "IX_GenreId");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_dbo.Movies_dbo.Genres_GenreId");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_dbo.Products");

            entity.HasIndex(e => e.CategoryId, "IX_CategoryID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_dbo.Products_dbo.Categories_CategoryID");
        });

        modelBuilder.Entity<RegularExp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("regularEXp");

            entity.Property(e => e.Pdob)
                .HasColumnType("date")
                .HasColumnName("pdob");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Pname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pname");
            entity.Property(e => e.Pnum).HasColumnName("pnum");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Rentals");

            entity.HasIndex(e => e.CustomerId, "IX_Customer_Id");

            entity.HasIndex(e => e.MovieId, "IX_Movie_Id");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.DateRented).HasColumnType("datetime");
            entity.Property(e => e.MovieId).HasColumnName("Movie_Id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_dbo.Rentals_dbo.Customers_Customer_Id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK_dbo.Rentals_dbo.Movies_Movie_Id");
        });

        modelBuilder.Entity<Split>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("split");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<VideosPath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.VideosPaths");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
