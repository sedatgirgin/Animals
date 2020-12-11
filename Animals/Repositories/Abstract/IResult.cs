using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Abstract
{
    interface IResult
    {
        string Message { get; set; }
        bool Succeeded { get; set; }
    }
}
