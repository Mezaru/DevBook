using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevBook.Models.Entities
{
    public partial class DevBookContext : DbContext
    {
        public virtual DbSet<ConnTable> ConnTable { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DevBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<ConnTable>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.Property(e => e.SkillId).HasColumnName("Skill_Id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ConnTable)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnTable_Person");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ConnTable)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnTable_Skill");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Skill1)
                    .IsRequired()
                    .HasColumnName("Skill")
                    .HasMaxLength(50);
            });
        }
    }
}
