using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoAuroraServerlessBeanstalkNetCore.DataModels
{
    public partial class AuroraContext : DbContext
    {
        public AuroraContext()
        {
        }

        public AuroraContext(DbContextOptions<AuroraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Composer> Composer { get; set; }
        public virtual DbSet<Music> Music { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Composer>(entity =>
            {
                entity.ToTable("Composer", "Aurora");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("fullname")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.ToTable("Music", "Aurora");

                entity.HasIndex(e => e.ComposerId)
                    .HasName("fk_Music_Composer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComposerId)
                    .HasColumnName("composerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Composer)
                    .WithMany(p => p.Music)
                    .HasForeignKey(d => d.ComposerId)
                    .HasConstraintName("Music_ibfk_1");
            });
        }
    }
}
