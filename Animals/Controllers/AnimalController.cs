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

        [HttpGet("GetAnimalsVaccination")]
        public async Task<IActionResult> GetAnimalsVaccinationAsync(int animalId)
        {
           return new Result("Animal List", _vecineRepository.GetVeccineList(animalId));
        }

        [HttpGet("GetVaccinasAnimal")]
        public async Task<IActionResult> GetVaccinasAnimalAsync(int vaccineId)
        {
            return new Result("Animal List", _vecineRepository.GetAnimalList(vaccineId));
        }

        [HttpPut("AddAnimalVaccine")]
        public async Task<IActionResult> AddAnimalVaccineAsync(int animalId,  int vaccineId,DateTime dateTime)
        {
            //var animal =_animalRepository.TGet(animalId);
            //var vaccine =_vecineRepository.TGet(vaccineId);
            var animalVaccine = new AnimalVaccine() { AnimalId = animalId, Date = dateTime, VaccineId = vaccineId };
           _vecineRepository.AddAnimalVaccine(animalVaccine);
            return new Result("Ekleme işlemi başarılı.");
        }

        [HttpPatch("DeleteAnimalVaccine")]
        public async Task<IActionResult> DeleteAnimalVaccineAsync(int animalId, int vaccineId)
        {
           var animalVaccine = _animalVaccineRepository.TFindExpression(i => i.VaccineId == vaccineId && i.AnimalId == animalId);
           _vecineRepository.DeleteAnimalVaccine(animalVaccine);
            return new Result("Silma işlemi başarılı.");
        }

        [HttpGet("VaccineList")]
        public async Task<IActionResult> VaccineListAsync()
        {
            return new Result("Vaccine List",_vecineRepository.TList());
        }

        [HttpGet("GetAnimalsReminders")]
        public async Task<IActionResult> GetAnimalsRemindersAsync(int animalId)
        {
            return new Result("Animal List", _reminderRepository.TListExpression(i=>i.Animal.Id==animalId));
        }

        [HttpPatch("DeleteReminder")]
        public async Task<IActionResult> DeleteReminderAsync(int reminderId)
        {
            _reminderRepository.TDelete(_reminderRepository.TGet(reminderId));
            return new Result("Hatırlatma başarı ile silindi");
        }

        [HttpPut("AddReminder")]
        public async Task<IActionResult> AddReminderAsync(RemiderDto reminder)
        {
            _reminderRepository.TAdd(new Reminder() { Animal = _animalRepository.TGet(reminder.AnimalId), Date = reminder.Date, IsPeriodic = reminder.IsPeriodic, IsUserDefined = reminder.IsUserDefined, Message = reminder.Message, Period = reminder.Period });
            return new Result("Hatırlatma başarı ile eklendi");
        }
    }
}
