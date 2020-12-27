using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Entities
{
    public class AnimalDtoInsert
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsNeutered { get; set; }
        public string UserId { get; set; }
        public int SubSpeciesId { get; set; }
        public DateTime PregnancyDate { get; set; }
    }
}
