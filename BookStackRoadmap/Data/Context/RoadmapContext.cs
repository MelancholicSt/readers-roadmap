using System;
using System.Collections.Generic;
using BookStackRoadmap.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BookStackRoadmap.Data.Context;

public partial class RoadmapContext : DbContext
{
    public RoadmapContext()
    {
    }

    public RoadmapContext(DbContextOptions<RoadmapContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookPage> BookPages { get; set; }

    public virtual DbSet<Entities.File> Files { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Entities.Task> Tasks { get; set; }

    public virtual DbSet<Entities.TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<UrlLink> UrlLinks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=books_roadmap;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.Name, "book_name_idx");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .HasColumnName("author");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BookPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("book_pages");

            entity.HasIndex(e => e.BookId, "book_id");

            entity.HasIndex(e => e.FileId, "file_id");

            entity.HasIndex(e => e.PageNumber, "page_number_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.PageNumber).HasColumnName("page_number");

            entity.HasOne(d => d.Book).WithMany(p => p.BookPages)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("book_pages_ibfk_1");

            entity.HasOne(d => d.File).WithMany(p => p.BookPages)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("book_pages_ibfk_2");
        });

        modelBuilder.Entity<Entities.File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("files");

            entity.HasIndex(e => e.BookPageId, "book_page_id").IsUnique();

            entity.HasIndex(e => e.Path, "path_idx").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BookPageId).HasColumnName("book_page_id");
            entity.Property(e => e.Path)
                .HasMaxLength(400)
                .HasColumnName("path");

            entity.HasOne(d => d.BookPage).WithOne(p => p.FileNavigation)
                .HasForeignKey<Entities.File>(d => d.BookPageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("files_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Entities.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Entities.TaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task_statuses");

            entity.HasIndex(e => e.StatusName, "IX_task_statuses_name");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.HasIndex(e => e.TaskId, "task_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(15)
                .HasDefaultValueSql("_utf8mb4\\'created\\'")
                .HasColumnName("status_name");
            entity.Property(e => e.TaskId).HasColumnName("task_id");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskStatuses)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("task_statuses_ibfk_1");
        });

        modelBuilder.Entity<UrlLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("url_links");

            entity.HasIndex(e => new { e.Name, e.Url }, "name_url_idx");

            entity.HasIndex(e => e.Url, "url_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(120)
                .HasColumnName("url");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.AuthHash, "auth_hash_idx");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => new { e.Email, e.PhoneNumber }, "personal_data_idx").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phone_number").IsUnique();

            entity.HasIndex(e => e.UserLinkId, "user_link_id");

            entity.HasIndex(e => e.IsVerified, "verified_user_idx");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AuthHash)
                .HasMaxLength(128)
                .IsFixedLength()
                .HasColumnName("auth_hash");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .HasColumnName("email");
            entity.Property(e => e.IsVerified)
                .HasColumnType("bit(1)")
                .HasColumnName("is_verified");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .HasDefaultValueSql("'user'")
                .HasColumnName("nickname");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.UserLinkId).HasColumnName("user_link_id");

            entity.HasOne(d => d.UserLink).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserLinkId)
                .HasConstraintName("users_ibfk_1");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_roles_ibfk_2"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_roles_ibfk_1"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("user_roles");
                        j.HasIndex(new[] { "RoleId" }, "role_id");
                        j.HasIndex(new[] { "UserId" }, "user_id");
                        j.IndexerProperty<string>("UserId")
                            .HasMaxLength(36)
                            .HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
