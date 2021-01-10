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
        private readonly ISubSpeciesRepository _animalSpeciesRepository;
        private readonly IWeightRepository _weightRepository;
        private readonly IReminderRepository _reminderRepository; 
        private readonly IVaccineRepository _vaccineRepository; 
        private readonly IAnimalVaccineRepository _animalVaccineRepository;
        private readonly IReminderTypeRepository _reminderTypeRepository;
        private readonly ISpeciesRepository _speciesRepository;


        public AnimalController(IAnimalRepository animalRepository, 
            UserManager<User>  userManager, 
            ISubSpeciesRepository animalSpeciesRepository, 
            IWeightRepository weightRepository, 
            IReminderRepository reminderRepository,
            IVaccineRepository vaccineRepository, 
            IAnimalVaccineRepository animalVaccineRepository,
            IReminderTypeRepository reminderTypeRepository,
             ISpeciesRepository speciesRepository)
        {
            _animalRepository = animalRepository;
            _userManager = userManager;
            _animalSpeciesRepository = animalSpeciesRepository;
            _weightRepository = weightRepository;
            _reminderRepository = reminderRepository;
            _vaccineRepository = vaccineRepository;
            _animalVaccineRepository = animalVaccineRepository;
            _reminderTypeRepository = reminderTypeRepository;
            _speciesRepository = speciesRepository;
        }

        [HttpPut("AddAnimal")]
        public async Task<IActionResult> AddAnimalAsync(AnimalDtoInsert model)
        {
             if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
            
            return new Result("Ekleme  başarılı. ",_animalRepository.AnimalİnsertAsync(model));
        }

        [HttpGet("AnimalList")]
        public async Task<IActionResult> AnimalListAsync()
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            var id = (await _userManager.GetUserAsync(User)).Id;
            return new Result("Hayvan listesi", _animalRepository.AnimalListAsync(id).Result);
        }

        [HttpPatch("AnimalDelete")]
        public async Task<IActionResult> AnimalDeleteAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Silme işlemi ", _animalRepository.AnimalDeleteAsync(animalId));
        }


        [HttpPatch("AnimalUpdate")]
        public async Task<IActionResult> AnimalUpdateAsync(AnimalDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Güncellme işlemi " ,_animalRepository.AnimalUpdateAsync(model));
        }


        [HttpPatch("WeightDelete")]
        public async Task<IActionResult> WeightDeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
            await _weightRepository.WeightDeleteAsync(id);
            return new Result("Weight Delete: ");
        }


        [HttpGet("WeightList")]
        public async Task<IActionResult> WeightListAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Weight List:", _weightRepository.WeightListAsync(animalId).Result);
        }

        [HttpPut("Weightİnsert")]
        public async Task<IActionResult> WeightİnsertAsync(WeightDto weightDto)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

             await  _weightRepository.WeightİnsertAsync(weightDto);
            return new Result("Weight İnsert:");
        }



        [HttpPatch("ReminderDelete")]
        public async Task<IActionResult> ReminderDeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
            await  _reminderRepository.ReminderDeleteAsync(id);
            return new Result("Reminder Delete:");
        }

        [HttpPut("ReminderInsert")]
        public async Task<IActionResult> ReminderInsertAsync(RemiderDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
           await _reminderRepository.ReminderUpdateAsync(model);
            return new ErrorResult("Reminder Insert");
        }

        [HttpGet("ReminderList")]
        public async Task<IActionResult> ReminderListAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
         
            return new ErrorResult("Reminder Insert",_reminderRepository.ReminderListAsync(animalId).Result);
        }

        [HttpPatch("ReminderUpdate")]
        public async Task<IActionResult> ReminderUpdateAsync(RemiderDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
            await _reminderRepository.ReminderUpdateAsync(model);
            return new ErrorResult("Reminder Update");
        }


        [HttpGet("ListAnimalsVaccines")]
        public async Task<IActionResult> ListAnimalsVaccinesAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Animal List", _vaccineRepository.GetVeccineList(animalId));
        }

        [HttpPut("AddAnimalVaccine")]
        public async Task<IActionResult> AddAnimalVaccineAsync(int animalId, int vaccineId, DateTime dateTime)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            var animalVaccine = new AnimalVaccine() { AnimalId = animalId, Date = dateTime, VaccineId = vaccineId };
            _vaccineRepository.AddAnimalVaccine(animalVaccine);
            return new Result("Ekleme işlemi başarılı.");
        }

        [HttpPatch("DeleteAnimalVaccine")]
        public async Task<IActionResult> DeleteAnimalVaccineAsync(int animalId, int vaccineId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            var animalVaccine = _animalVaccineRepository.TFindExpression(i => i.VaccineId == vaccineId && i.AnimalId == animalId);
            _vaccineRepository.DeleteAnimalVaccine(animalVaccine);
            return new Result("Silma işlemi başarılı.");
        }

        [HttpGet("VaccineList")]
        public async Task<IActionResult> VaccineListAsync()
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Vaccine List", _vaccineRepository.TList());
        }    
        
        [HttpGet("ReminderTypeList")]
        public async Task<IActionResult> ReminderTypeListAsync()
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Vaccine List", _reminderTypeRepository.TList());
        }

        [HttpGet("SpecieList")]
        public async Task<IActionResult> SpecieListAsync()
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Vaccine List", _speciesRepository.TList());
        }
    }
}
