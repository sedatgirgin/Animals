using Animals.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.ResultMessages
{
    public class Result : IActionResult, IResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Result(string message)
        {
            Message = message;
            Succeeded = true;
        }

        public Result(string message, object data)
        {
            Message = message;
            Data = data;
            Succeeded = true;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this);

            await objectResult.ExecuteResultAsync(context);
        }

    }
}
