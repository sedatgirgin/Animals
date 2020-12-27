using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaybeNull]
        public DateTime DateOfBirth { get; set; }
        [MaybeNull]
        public string Gender { get; set; }
        [MaybeNull]
        public bool IsNeutered { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("SubSpeciesId")]
        public int SubSpeciesId { get; set; }
        public SubSpecies SubSpecies { get; set; }
        [MaybeNull]
        public List<Weight> Weights { get; set; }
        public DateTime PregnancyDate { get; set; }
        [MaybeNull]
        public List<AnimalVaccine> AnimalVaccines { get; set; }

    }
}
