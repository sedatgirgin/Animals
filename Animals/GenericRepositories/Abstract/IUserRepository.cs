﻿using Animals.Entities;
using Animals.Models;
using Animals.Repositories.Abstract;
using Animals.Repositories.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
