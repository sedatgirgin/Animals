using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Weight
    {
        public int Id { get; set; }

        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Value { get; set; }

    }
}
