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
    public class WeightRepository : GenericRepository<Weight>, IWeightRepository
    {
        public async Task<bool> WeightDeleteAsync(int id)
        {
            var parameters = new NpgsqlParameter[]
                       {
                       new NpgsqlParameter { ParameterName="@id", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = id },
                       };
            return await context.Database.ExecuteSqlRawAsync(Script.WeightDelete, parameters) == -1 ? true : false;
        }

        public async Task<List<Weight>> WeightListAsync(int animalId)
        {
            var parameters = new NpgsqlParameter[]
                   {
                    new NpgsqlParameter { ParameterName="@animalId", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = animalId },
                   };
            return await context.Weights.FromSqlRaw(Script.WeightList, parameters).ToListAsync();
        }

        public async Task<int> WeightİnsertAsync(WeightDto weightDto)
        {
            var parameters = new NpgsqlParameter[]
                           {
                       new NpgsqlParameter { ParameterName="@animalid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = weightDto.AnimalId },
                       new NpgsqlParameter { ParameterName="@date", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = weightDto.Date },
                       new NpgsqlParameter { ParameterName="@value", NpgsqlDbType = NpgsqlDbType.Double, NpgsqlValue = weightDto.Value }
                           };
            return await context.Database.ExecuteSqlRawAsync(Script.WeightInsert, parameters);
        }

    }
}
