using Animals.Models;
using Animals.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Abstract
{
   public interface IVaccineRepository : IGenericRepository<Vaccine>
    {
        List<Animal> GetAnimalList(int vaccineId);
        void AddAnimalVaccine(AnimalVaccine animalVaccine);
        void DeleteAnimalVaccine(AnimalVaccine animalVaccine);
        List<Vaccine> GetVeccineList(int animalId);

    }
}
