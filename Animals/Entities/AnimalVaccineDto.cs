using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Entities
{
    public class AnimalVaccineDto
    {
        public int AnimalId { get; set; }
        public int VaccineId { get; set; }
        public DateTime Date { get; set; }

    }
}
