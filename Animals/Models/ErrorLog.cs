using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string StackTrace { get; set; }
    }
}
