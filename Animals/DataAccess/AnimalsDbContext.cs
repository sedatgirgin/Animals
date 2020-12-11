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
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }

    }
}
