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
        private readonly IVaccineRepository _vaccineRepository; 
        private readonly IAnimalVaccineRepository _animalVaccineRepository;

        public AnimalController(IAnimalRepository animalRepository, 
            UserManager<User>  userManager, 
            IAnimalSpeciesRepository animalSpeciesRepository, 
            IWeightRepository weightRepository, 
            IReminderRepository reminderRepository,
            IVaccineRepository vaccineRepository, 
            IAnimalVaccineRepository animalVaccineRepository)
        {
            _animalRepository = animalRepository;
            _userManager = userManager;
            _animalSpeciesRepository = animalSpeciesRepository;
            _weightRepository = weightRepository;
            _reminderRepository = reminderRepository;
            _vaccineRepository = vaccineRepository;
            _animalVaccineRepository = animalVaccineRepository;
        }

        [HttpPut("AddAnimal")]
        public async Task<IActionResult> AddAnimalAsync(AnimalDto model)
        {
            var id = (await _userManager.GetUserAsync(User)).Id;
            var animalSpecies =  _animalSpeciesRepository.TFindExpression(i=>i.Breed==model.Breed);
            if(animalSpecies !=null)
            {
                Animal animal = new Animal()
                {
                    Name = model.Name,
                    Breed = model.Breed,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    IsNeutered = model.IsNeutered,
                    UserId = id,
                    AnimalSpeciesId = animalSpecies.Id
                };
                _animalRepository.TAdd(animal);
                return new Result("Ekleme işlemi başarılı.");
            }
            return new ErrorResult("Ekleme işlemi başarısız.");
        }

        [HttpGet("GetAnimals")]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
           var id = (await _userManager.GetUserAsync(User)).Id;
          return  new Result("Animal List", _animalRepository.TListExpression(i => i.UserId == id)); 
        }

        [HttpPatch("DeleteAnimal")]
        public async Task<IActionResult> DeleteAnimalAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            var animal = _animalRepository.TGet(animalId);
            _animalRepository.TDelete(animal);

            foreach (var item in _weightRepository.TListExpression(i => i.AnimalId == animal.Id).ToList())
            {
                _weightRepository.TDelete(item);
            }

            foreach (var item in _reminderRepository.TListExpression(i => i.AnimalId == animal.Id).ToList())
            {
                _reminderRepository.TDelete(item);
            }

            foreach (var item in _animalVaccineRepository.TListExpression(i => i.AnimalId == animal.Id).ToList())
            {
                _animalVaccineRepository.TDelete(item);
            }

            return new Result("Silme işlemi başarılı.");
        }

        [HttpPatch("UpdateAnimal")]
        public async Task<IActionResult> UpdateAnimalAsync(AnimalDto model)
        {
            var animal = _animalRepository.TGet(model.AnimalId);

            if (animal != null)
            {
                animal.Name = model.Name;
                animal.Breed = model.Breed;
                animal.DateOfBirth = model.DateOfBirth;
                animal.Gender = model.Gender;
                animal.IsNeutered = model.IsNeutered;

                _animalRepository.TUpdate(animal);
                return new Result("Güncellme işlemi başarılı.");
            }
            return new ErrorResult("Güncellme işlemi başarısız.");
        }


        [HttpGet("GetAnimalReminders")]
        public async Task<IActionResult> GetAnimalRemindersAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Animal List", _reminderRepository.TListExpression(i => i.AnimalId == animalId));
        }


        [HttpPatch("DeleteReminder")]
        public async Task<IActionResult> DeleteReminderAsync(int reminderId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            _reminderRepository.TDelete(_reminderRepository.TGet(reminderId));
            return new Result("Hatırlatma başarı ile silindi");
        }

        [HttpPut("AddReminder")]
        public async Task<IActionResult> AddReminderAsync(RemiderDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
            var animal = _animalRepository.TGet(model.AnimalId);
            if (animal != null)
            {
                _reminderRepository.TAdd(new Reminder()
                {
                    AnimalId = model.AnimalId,
                    Date = model.Date,
                    IsPeriodic = model.IsPeriodic,
                    IsUserDefined = model.IsUserDefined,
                    Message = model.Message,
                    Period = model.Period
                });
                return new Result("Hatırlatma başarı ile eklendi");
            }
            return new ErrorResult("İlişkilendirilmiş hayvan bulunmamaktadır.");
        }

        [HttpPost("UpdateReminder")]
        public async Task<IActionResult> UpdateReminderAsync(RemiderDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            var remider = _reminderRepository.TGet(model.RemiderId);

            if (remider != null)
            {
                remider.Date = model.Date;
                remider.IsPeriodic = model.IsPeriodic;
                remider.IsUserDefined = model.IsUserDefined;
                remider.Message = model.Message;
                remider.Period = model.Period;

                _reminderRepository.TUpdate(remider);
                return new Result("Güncellme işlemi başarılı.");
            }
            return new ErrorResult("Güncellme işlemi başarısız.");
        }



        [HttpPut("AddWeight")]
        public async Task<IActionResult> AddWeightAsync(WeightDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            var animal = _animalRepository.TGet(model.AnimalId);

            if (animal != null)
            {
                _weightRepository.TAdd(new Weight()
                {
                    AnimalId = model.AnimalId,
                    Date = model.Date,
                    Value = model.Value

                });
                return new Result("Hatırlatma başarı ile eklendi");
            }
            return new ErrorResult("İlişkilendirilmiş hayvan bulunmamaktadır.");
        }

        [HttpDelete("DeleteWeight")]
        public async Task<IActionResult> DeleteWeight(int WeigthId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            _weightRepository.TDelete(_weightRepository.TGet(WeigthId));
            return new Result("Silme işlemi başarılı");
        }


        [HttpGet("GetWeights")]
        public async Task<IActionResult> GetWeightsAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Animal List", _weightRepository.TListExpression(i => i.AnimalId== animalId));
        }


        [HttpGet("ListAnimalsVaccines")]
        public async Task<IActionResult> ListAnimalsVaccinesAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Animal List", _vaccineRepository.GetVeccineList(animalId));
        }


        //[HttpGet("ListVaccinesAnimal")]
        //public async Task<IActionResult> ListVaccinesAnimalAsync(int vaccineId)
        //{
        //    if (!ModelState.IsValid)
        //        return new ErrorResult("Hatalı işlem");

        //    return new Result("Animal List", _vaccineRepository.GetAnimalList(vaccineId));
        //}
   

        [HttpPut("AddAnimalVaccine")]
        public async Task<IActionResult> AddAnimalVaccineAsync(int animalId,  int vaccineId,DateTime dateTime)
        {
            //var animal =_animalRepository.TGet(animalId);
            //var vaccine =_vecineRepository.TGet(vaccineId);
            var animalVaccine = new AnimalVaccine() { AnimalId = animalId, Date = dateTime, VaccineId = vaccineId };
            _vaccineRepository.AddAnimalVaccine(animalVaccine);
            return new Result("Ekleme işlemi başarılı.");
        }

        [HttpPatch("DeleteAnimalVaccine")]
        public async Task<IActionResult> DeleteAnimalVaccineAsync(int animalId, int vaccineId)
        {
           var animalVaccine = _animalVaccineRepository.TFindExpression(i => i.VaccineId == vaccineId && i.AnimalId == animalId);
            _vaccineRepository.DeleteAnimalVaccine(animalVaccine);
            return new Result("Silma işlemi başarılı.");
        }

        [HttpGet("ListVaccine")]
        public async Task<IActionResult> VaccineListAsync(string breed)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
            var vaccines = _vaccineRepository.TListExpression(i => i.Breed == breed);

            return  new Result("Vaccine List", vaccines);
        }



    }
}
