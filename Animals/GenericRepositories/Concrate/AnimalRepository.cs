using Animals.Models;
using Animals.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Concrate
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {


    }
}
