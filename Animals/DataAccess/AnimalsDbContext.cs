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

            modelBuilder.Entity<User>().HasMany(I => I.Animals).
              WithOne(I => I.User).HasForeignKey(I => I.UserId);

            modelBuilder.Entity<Species>().HasMany(I => I.SubSpecies).
                  WithOne(I => I.Species).HasForeignKey(I => I.SpeciesId);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<ReminderType> ReminderTypes { get; set; }
        public virtual DbSet<AnimalVaccine> AnimalVaccines { get; set; }
        public virtual DbSet<Weight> Weights { get; set; }
        public virtual DbSet<SubSpecies> SubSpecies { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }

    }
}
