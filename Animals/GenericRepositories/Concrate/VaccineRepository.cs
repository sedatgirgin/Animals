using Animals.GenericRepositories.Abstract;
using Animals.Models;
using Animals.Repositories.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Concrate
{
    public class VaccineRepository : GenericRepository<Vaccine>, IVaccineRepository
    {
        private readonly IAnimalVaccineRepository _animalVaccineRepository;

        public VaccineRepository(IAnimalVaccineRepository animalVaccineRepository)
        {
            _animalVaccineRepository = animalVaccineRepository;
        }

        public void AddAnimalVaccine(AnimalVaccine animalVaccine)
        {
            var animalVaccineResult = _animalVaccineRepository.TFindExpression(I => I.AnimalId == animalVaccine.AnimalId &&
                              I.VaccineId == animalVaccine.VaccineId);
            if (animalVaccineResult == null)
            {
                _animalVaccineRepository.TAdd(animalVaccine);
            }
        }

        public void DeleteAnimalVaccine(AnimalVaccine animalVaccine)
        {
            var animalVaccineResult = _animalVaccineRepository.TFindExpression(I => I.AnimalId == animalVaccine.AnimalId &&
                              I.VaccineId == animalVaccine.VaccineId);
            if (animalVaccineResult != null)
            {
                _animalVaccineRepository.TDelete(animalVaccine);
            }
        }

        public List<Animal> GetAnimalList(int vaccineId)
        {
            return context.Vaccine.Join(context.AnimalVaccine, veccine => veccine.Id,
            animalVaccine => animalVaccine.VaccineId, (u, uc) => new
            {
                vaccine = u,
                animalVaccine = uc
            }).Join(context.Animal, twoTable => twoTable.animalVaccine.AnimalId,
               animal => animal.Id, (uc, k) => new
               {
                   ve = uc.vaccine,
                   animal = k,
                   animalVaccine = uc.animalVaccine
               }
               ).Where(I => I.animal.Id == vaccineId).Select(I => new Animal
               {
                   Id = I.animal.Id,
                   AnimalSpecies = I.animal.AnimalSpecies,
                   Breed = I.animal.Breed,
                   DateOfBirth = I.animal.DateOfBirth,
                   Gender = I.animal.Gender,
                   IsNeutered = I.animal.IsNeutered,
                   Name = I.animal.Name,
                   Weights = I.animal.Weights

               }).ToList();
        }

        public List<Vaccine> GetVeccineList(int animalId)
        {
            return context.Vaccine.Join(context.AnimalVaccine, vaccine => vaccine.Id,
                          animalVaccine => animalVaccine.VaccineId, (vaccine2, animalVaccine2) => new
                          {
                              vaccine3 = vaccine2,
                              animalVaccine3 = animalVaccine2
                          }).Where(I => I.animalVaccine3.AnimalId == animalId).Select(I => new Vaccine
                          {
                              Id = I.vaccine3.Id,
                              Name = I.vaccine3.Name,
                              Period = I.vaccine3.Period
                          }).ToList();
        }
    }
}
