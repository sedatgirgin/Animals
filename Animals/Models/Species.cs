using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Species
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       public  ICollection<SubSpecies> SubSpecies { get; set; }
    }
}
