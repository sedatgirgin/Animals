using Animals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Abstract
{
    interface IAnimalRepository : IGenericRepository<Animal>
    {
        //eklemek istediğimiz bütün methodlar buraya
    }
}
