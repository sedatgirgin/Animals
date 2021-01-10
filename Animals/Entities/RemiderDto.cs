using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Entities
{
    public class RemiderDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string Message { get; set; }
        public bool IsPeriodic { get; set; }
        public int Period { get; set; }
        public DateTime Date { get; set; }
        public int ReminderTypeId { get; set; }
    }
}
