using Animals.Caching;
using Animals.Caching.Abstract;
using Animals.Models;
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
        private readonly ICache _cache;

        public HomeController(IAnimalRepository animalRepository,ICache cache)
        {
            _animalRepository = animalRepository;
            _cache = cache;
        }

        [HttpGet("GetAnimal")]
        public async Task<IActionResult> GetAnimalAsync()
        {
            if (!ModelState.IsValid) return new ErrorResult("Hatalı istek", BadRequest(ModelState).Value);


            //cache set - get ForExample
             await _cache.SetCacheAsync(_animalRepository.TList(),CacheKeys.CallbackEntry);
            var data = await _cache.GetCacheAsync(CacheKeys.CallbackEntry);

            return new Result("Available", data);
        }
    }
}
