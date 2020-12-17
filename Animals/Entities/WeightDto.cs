using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Entities
{
    public class WeightDto
    {
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}
