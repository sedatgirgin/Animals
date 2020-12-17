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
        private readonly IWeightRepository _weightRepository;
        private readonly IReminderRepository _reminderRepository; 
        private readonly IVaccineRepository _vecineRepository; 
        private readonly IAnimalVaccineRepository _animalVaccineRepository;

        public AnimalController(IAnimalRepository animalRepository, 
            UserManager<User>  userManager, 
            IAnimalSpeciesRepository animalSpeciesRepository, 
            IWeightRepository weightRepository, 
            IReminderRepository reminderRepository,
            IVaccineRepository vecineRepository, 
            IAnimalVaccineRepository animalVaccineRepository)
        {
            _animalRepository = animalRepository;
            _userManager = userManager;
            _animalSpeciesRepository = animalSpeciesRepository;
            _weightRepository = weightRepository;
            _reminderRepository = reminderRepository;
            _vecineRepository = vecineRepository;
            _animalVaccineRepository = animalVaccineRepository;
        }

        [HttpGet("GetAnimalList")]
        public async Task<IActionResult> GetAnimalListAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return new Result("Animal List",_animalRepository.TListExpression(i => i.User == user).ToList());
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

        [HttpPatch("AnimalDelete")]
        public async Task<IActionResult> DeleteAnimalAsync(int animalId)
        {
            var animal = _animalRepository.TGet(animalId);
            _animalRepository.TDelete(animal);
            foreach (var item in _weightRepository.TListExpression(i => i.Animal == animal).ToList())
            {
                _weightRepository.TDelete(item);
            }

            foreach (var item in _reminderRepository.TListExpression(i => i.Animal == animal).ToList())
            {
                _reminderRepository.TDelete(item);
            }

            foreach (var item in _animalVaccineRepository.TListExpression(i => i.Animal == animal).ToList())
            {
                _animalVaccineRepository.TDelete(item);
            }

            return new Result("Silme işlemi başarılı.");
        }




    }
}
