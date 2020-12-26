using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class AnimalSpecies
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Breed { get; set; }

        [Required]
        public int PregnancyDuration { get; set; }
    }
}
