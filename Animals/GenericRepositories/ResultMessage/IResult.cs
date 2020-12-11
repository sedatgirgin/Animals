using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.ResultMessage
{
    interface IResult
    {
        string Message { get; set; }
        bool Succeeded { get; set; }
    }
}
