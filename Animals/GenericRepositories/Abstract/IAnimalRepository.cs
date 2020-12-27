using Animals.Entities;
using Animals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Abstract
{
   public  interface IAnimalRepository : IGenericRepository<Animal>
    {
        Task<bool> AnimalDeleteAsync(int id);
        Task<int> AnimalİnsertAsync(AnimalDtoInsert animal);
        Task<bool> AnimalUpdateAsync(AnimalDto animal);
        Task<List<Animal>> AnimalListAsync(string userid);
    }
}
