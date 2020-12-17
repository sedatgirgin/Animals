using Animals.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.DataAccess
{
    public class AnimalsDbContext: IdentityDbContext
    {
        public AnimalsDbContext()
        {
        }

        public AnimalsDbContext(DbContextOptions<AnimalsDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=Strong2020.;Server=localhost;Port=5432;Database=MyPetDb;Integrated Security=true;Pooling=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasMany(I => I.AnimalVaccines).
                WithOne(I => I.Animal).HasForeignKey(I => I.AnimalId);
            modelBuilder.Entity<Vaccine>().HasMany(I => I.AnimalVaccines).
              WithOne(I => I.Vaccine).HasForeignKey(I => I.VaccineId);
            modelBuilder.Entity<AnimalVaccine>().HasIndex(I => new
            {
                I.AnimalId,
                I.VaccineId
            }).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Vaccine> Vaccine { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<AnimalVaccine> AnimalVaccine { get; set; }
        public virtual DbSet<Weight> Weight { get; set; }
        public virtual DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }

    }
}
