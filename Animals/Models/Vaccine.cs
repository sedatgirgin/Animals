using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Breed { get; set; }

        [MaybeNull]
        public int Period { get; set; }
        public List<AnimalVaccine> AnimalVaccines { get; set; }

    }
}
