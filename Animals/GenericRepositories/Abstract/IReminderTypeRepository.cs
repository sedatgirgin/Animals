using Animals.Models;
using Animals.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Abstract
{
    public interface IReminderTypeRepository : IGenericRepository<ReminderType>
    {
    }
}
