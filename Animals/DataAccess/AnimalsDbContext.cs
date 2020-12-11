using Animals.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.DataAccess
{
    public class AnimalsDbContext:DbContext
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
                optionsBuilder.UseNpgsql("User ID=postgres;Password=Strong2020.;Server=localhost;Port=5432;Database=AnimalDb;Integrated Security=true;Pooling=true");
            }
        }

        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Animal> Animal { get; set; }


    }
}
