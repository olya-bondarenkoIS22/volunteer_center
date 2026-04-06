using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volunteer_Center.models;

namespace Volunteer_Center;

public partial class VolunteerCenterContext : DbContext
{
    public VolunteerCenterContext()
    {
    }

    public VolunteerCenterContext(DbContextOptions<VolunteerCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<RegistrationStatus> RegistrationStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerRegistration> VolunteerRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=volunteer_center;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.VolunteersNeeded).HasColumnName("volunteers_needed");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categories_events");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_statuse_events");
        });

        modelBuilder.Entity<RegistrationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_statuses_pkey");

            entity.ToTable("registration_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RegistrationStatusName).HasColumnName("registration_status_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_roles_users");
        });

        modelBuilder.Entity<VolunteerRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("volunteer_registration_pkey");

            entity.ToTable("volunteer_registration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdRegistrationStatus).HasColumnName("id_registration_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_events_volunteer_registration");

            entity.HasOne(d => d.IdRegistrationStatusNavigation).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdRegistrationStatus)
                .HasConstraintName("fk_registration_status_volunteer_registration");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_volunteer_registration");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
