using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Abstract
{
    interface IErrorResult : IResult
    {
        object Errors { get; set; }
    }
}
