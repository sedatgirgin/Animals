﻿using Animals.GenericRepositories.Abstract;
using Animals.Models;
using Animals.Repositories.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Concrate
{
    public class ReminderRepository : GenericRepository<Reminder>, IReminderRepository
    {
    }
}
