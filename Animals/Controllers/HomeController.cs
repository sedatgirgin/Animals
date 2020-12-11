using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("Get")]
        public async Task<ActionResult<bool>> CreateStoreAsync()
        {
            return Ok ();
        }

    }
}
