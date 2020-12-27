using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class SubSpecies
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("SpeciesIId")]
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
        [Required]
        public int PregnancyDuration { get; set; }
    }
}
