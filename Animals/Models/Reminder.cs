using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Reminder
    {
        public int Id { get; set; }

        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        [Required]
        public string Message { get; set; }
        [Required]
        public bool IsPeriodic { get; set; }
        [MaybeNull]
        public int Period { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool IsUserDefined { get; set; }

    }
}
