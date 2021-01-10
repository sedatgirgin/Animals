using Animals.Entities;
using Animals.GenericRepositories.Abstract;
using Animals.GenericRepositories.DbScript;
using Animals.Models;
using Animals.Repositories.Concrate;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.Concrate
{
    public class ReminderRepository : GenericRepository<Reminder>, IReminderRepository
    {
        public async Task<bool> ReminderDeleteAsync(int id)
        {
            var parameters = new NpgsqlParameter[]
                                  {
                                     new NpgsqlParameter { ParameterName="@id", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = id },
                                  };
            return await context.Database.ExecuteSqlRawAsync(Script.ReminderDelete, parameters) == -1 ? true : false;
        }

        public async Task<int> ReminderInsertAsync(RemiderDto remiderDto)
        {
            var parameters = new NpgsqlParameter[]
                                     {
                       new NpgsqlParameter { ParameterName="@animalid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.AnimalId },
                       new NpgsqlParameter { ParameterName="@message", NpgsqlDbType = NpgsqlDbType.Text, NpgsqlValue = remiderDto.Message },
                       new NpgsqlParameter { ParameterName="@isperiodic", NpgsqlDbType = NpgsqlDbType.Boolean, NpgsqlValue = remiderDto.IsPeriodic },
                       new NpgsqlParameter { ParameterName="@period", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.Period },
                       new NpgsqlParameter { ParameterName="@date", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = remiderDto.Date },
                       new NpgsqlParameter { ParameterName="@remindertypeid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.ReminderTypeId }
                                     };
            return await context.Database.ExecuteSqlRawAsync(Script.ReminderInsert, parameters);
        }

        public async Task<List<Reminder>> ReminderListAsync(int animalId)
        {
            var parameters = new NpgsqlParameter[]
                           {
                    new NpgsqlParameter { ParameterName="@animalId", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = animalId },
                           };
            return await context.Reminders.FromSqlRaw(Script.ReminderList, parameters).ToListAsync();
        }

        public async Task<bool> ReminderUpdateAsync(RemiderDto remiderDto)
        {
            var parameters = new NpgsqlParameter[]
      {
                       new NpgsqlParameter { ParameterName="@id", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.Id },
                      new NpgsqlParameter { ParameterName="@animalid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.AnimalId },
                       new NpgsqlParameter { ParameterName="@message", NpgsqlDbType = NpgsqlDbType.Text, NpgsqlValue = remiderDto.Message },
                       new NpgsqlParameter { ParameterName="@isperiodic", NpgsqlDbType = NpgsqlDbType.Boolean, NpgsqlValue = remiderDto.IsPeriodic },
                       new NpgsqlParameter { ParameterName="@period", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.Period },
                       new NpgsqlParameter { ParameterName="@date", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = remiderDto.Date },
                       new NpgsqlParameter { ParameterName="@remindertypeid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = remiderDto.ReminderTypeId }
      };
            return await context.Database.ExecuteSqlRawAsync(Script.ReminderUpdate, parameters) == -1 ? true : false;
        }
    }
}
