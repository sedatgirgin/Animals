using Animals.Entities;
using Animals.Models;
using Animals.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Abstract
{
    public interface IWeightRepository : IGenericRepository<Weight>
    {
        Task<bool> WeightDeleteAsync(int id);
        Task<int> WeightİnsertAsync(WeightDto weightDto);
        Task<List<Weight>> WeightListAsync(int animalId);
    }
}
