﻿using Animals.Entities;
using Animals.Models;
using Animals.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Abstract
{
    public interface IReminderRepository : IGenericRepository<Reminder>
    {
        Task<bool> ReminderDeleteAsync(int id);
        Task<int> ReminderInsertAsync(RemiderDto remiderDto);
        Task<bool> ReminderUpdateAsync(RemiderDto remiderDto);
        Task<List<Reminder>> ReminderListAsync(int animalId);
    }
}
