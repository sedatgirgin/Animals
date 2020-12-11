using Animals.Repositories.Abstract;
using Animals.ResultMessages;
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
        private readonly IAnimalRepository _animalRepository;

        public HomeController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> CreateStoreAsync()
        {
            if (!ModelState.IsValid) return new ErrorResult("Hatalı istek", BadRequest(ModelState).Value);
            return new Result("Available", _animalRepository.TList());
        }
    }
}
