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

        public AnimalController(IAnimalRepository animalRepository, 
            UserManager<User>  userManager, 
            ISubSpeciesRepository animalSpeciesRepository, 
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


        [HttpGet("WeightDelete")]
        public async Task<IActionResult> WeightDeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Weight Delete: ", _weightRepository.WeightDeleteAsync(id));
        }


        [HttpPatch("WeightList")]
        public async Task<IActionResult> WeightListAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Weight List:", _weightRepository.WeightListAsync(animalId));
        }

        [HttpPatch("Weightİnsert")]
        public async Task<IActionResult> WeightİnsertAsync(WeightDto weightDto)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");

            return new Result("Weight İnsert:", _weightRepository.WeightİnsertAsync(weightDto));
        }



        [HttpPut("ReminderDelete")]
        public async Task<IActionResult> ReminderDeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
       
            return new Result("Reminder Delete:",_reminderRepository.ReminderDeleteAsync(id));
        }

        [HttpPost("ReminderInsert")]
        public async Task<IActionResult> ReminderInsertAsync(RemiderDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
         
            return new ErrorResult("Reminder Insert",_reminderRepository.ReminderUpdateAsync(model));
        }

        [HttpPost("ReminderList")]
        public async Task<IActionResult> ReminderListAsync(int animalId)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
         
            return new ErrorResult("Reminder Insert",_reminderRepository.ReminderListAsync(animalId));
        }

        [HttpPost("ReminderUpdate")]
        public async Task<IActionResult> ReminderUpdateAsync(RemiderDto model)
        {
            if (!ModelState.IsValid)
                return new ErrorResult("Hatalı işlem");
         
            return new ErrorResult("Reminder Update", _reminderRepository.ReminderUpdateAsync(model));
        }



        //[HttpPut("AddWeight")]
        //public async Task<IActionResult> AddWeightAsync(WeightDto model)
        //{
        //    if (!ModelState.IsValid)
        //        return new ErrorResult("Hatalı işlem");

        //    var animal = _animalRepository.TGet(model.AnimalId);

        //    if (animal != null)
        //    {
        //        _weightRepository.TAdd(new Weight()
        //        {
        //            AnimalId = model.AnimalId,
        //            Date = model.Date,
        //            Value = model.Value

        //        });
        //        return new Result("Hatırlatma başarı ile eklendi");
        //    }
        //    return new ErrorResult("İlişkilendirilmiş hayvan bulunmamaktadır.");
        //}

        //[HttpDelete("DeleteWeight")]
        //public async Task<IActionResult> DeleteWeight(int WeigthId)
        //{
        //    if (!ModelState.IsValid)
        //        return new ErrorResult("Hatalı işlem");

        //    _weightRepository.TDelete(_weightRepository.TGet(WeigthId));
        //    return new Result("Silme işlemi başarılı");
        //}


        //[HttpGet("GetWeights")]
        //public async Task<IActionResult> GetWeightsAsync(int animalId)
        //{
        //    if (!ModelState.IsValid)
        //        return new ErrorResult("Hatalı işlem");

        //    return new Result("Animal List", _weightRepository.TListExpression(i => i.AnimalId== animalId));
        //}


        //[HttpGet("ListAnimalsVaccines")]
        //public async Task<IActionResult> ListAnimalsVaccinesAsync(int animalId)
        //{
        //    if (!ModelState.IsValid)
        //        return new ErrorResult("Hatalı işlem");

        //    return new Result("Animal List", _vaccineRepository.GetVeccineList(animalId));
        //}


        ////[HttpGet("ListVaccinesAnimal")]
        ////public async Task<IActionResult> ListVaccinesAnimalAsync(int vaccineId)
        ////{
        ////    if (!ModelState.IsValid)
        ////        return new ErrorResult("Hatalı işlem");

        ////    return new Result("Animal List", _vaccineRepository.GetAnimalList(vaccineId));
        ////}


        //[HttpPut("AddAnimalVaccine")]
        //public async Task<IActionResult> AddAnimalVaccineAsync(int animalId,  int vaccineId,DateTime dateTime)
        //{
        //    //var animal =_animalRepository.TGet(animalId);
        //    //var vaccine =_vecineRepository.TGet(vaccineId);
        //    var animalVaccine = new AnimalVaccine() { AnimalId = animalId, Date = dateTime, VaccineId = vaccineId };
        //    _vaccineRepository.AddAnimalVaccine(animalVaccine);
        //    return new Result("Ekleme işlemi başarılı.");
        //}

        //[HttpPatch("DeleteAnimalVaccine")]
        //public async Task<IActionResult> DeleteAnimalVaccineAsync(int animalId, int vaccineId)
        //{
        //   var animalVaccine = _animalVaccineRepository.TFindExpression(i => i.VaccineId == vaccineId && i.AnimalId == animalId);
        //    _vaccineRepository.DeleteAnimalVaccine(animalVaccine);
        //    return new Result("Silma işlemi başarılı.");
        //}

        //[HttpGet("ListVaccine")]
        //public async Task<IActionResult> VaccineListAsync(string breed)
        //{
        //    if (!ModelState.IsValid)
        //        return new ErrorResult("Hatalı işlem");
        //    var vaccines = _vaccineRepository.TListExpression(i => i.Breed == breed);

        //    return  new Result("Vaccine List", vaccines);
        //}



    }
}
