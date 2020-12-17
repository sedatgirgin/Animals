using Animals.Entities;
using Animals.GenericRepositories.Abstract;
using Animals.Models;
using Animals.Repositories.Abstract;
using Animals.ResultMessages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalSpeciesRepository _animalSpeciesRepository;
        

        public AnimalController(IAnimalRepository animalRepository, UserManager<User>  userManager, IAnimalSpeciesRepository animalSpeciesRepository)
        {
            _animalRepository = animalRepository;
            _userManager = userManager;
            _animalSpeciesRepository = animalSpeciesRepository;

        }

        [HttpPut("AnimalAdd")]
        public async Task<IActionResult> AddAnimalAsync(AnimalDto model)
        {
            var user = await _userManager.GetUserAsync(User);
            var animalSpecies =  _animalSpeciesRepository.TGet(model.AnimalSpeciesId);

            Animal animal = new Animal()
            {
                Name = model.Name,
                Breed = model.Breed,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                IsNeutered = model.IsNeutered,
                User = user,
                AnimalSpecies = animalSpecies
            };
            _animalRepository.TAdd(animal);
            return new Result("Ekleme işlemi başarılı.");
        }




     }
}
