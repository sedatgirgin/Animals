using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Entities
{
    public class AnimalSpeciesDto
    {
        public string Breed { get; set; }
        public string Genus { get; set; }
        public int PregnancyDuration { get; set; }
    }
}
