using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Breed { get; set; }
        [MaybeNull]
        public string Gender { get; set; }
        [MaybeNull]
        public bool IsNeutered { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public AnimalSpecies AnimalSpecies { get; set; }
        [MaybeNull]
        public List<Weight> Weights { get; set; }
        [MaybeNull]
        public List<AnimalVaccine> AnimalVaccines { get; set; }

    }
}
