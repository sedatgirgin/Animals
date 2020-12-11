using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.ResultMessages
{
    public class RestException : Exception
    {
        public object Errors { get; set; }

        public RestException(object errors)
        {
            Errors = errors;
        }
    }
}
