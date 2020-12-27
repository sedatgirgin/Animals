using Animals.Entities;
using Animals.GenericRepositories.DbScript;
using Animals.Models;
using Animals.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Concrate
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {


        public async Task<List<Animal>> AnimalListAsync(string userid)
        {
            var parameters = new NpgsqlParameter[]
            {
                    new NpgsqlParameter { ParameterName="@userid", NpgsqlDbType = NpgsqlDbType.Text, NpgsqlValue = userid },
            };
            return await context.Animals.FromSqlRaw(Script.AnimalList, parameters).ToListAsync();
        }


        public async Task<bool> AnimalDeleteAsync(int id)
        {
            var parameters = new NpgsqlParameter[]
            {
                       new NpgsqlParameter { ParameterName="@id", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = id },
            };
            return await context.Database.ExecuteSqlRawAsync(Script.AnimalDelete, parameters) == -1 ? true : false;
        }

        public async Task<bool> AnimalUpdateAsync(AnimalDto animal)
        {
            var parameters = new NpgsqlParameter[]
           {
                       new NpgsqlParameter { ParameterName="@id", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = animal.Id },
                       new NpgsqlParameter { ParameterName="@name", NpgsqlDbType = NpgsqlDbType.Varchar, NpgsqlValue = animal.Name },
                       new NpgsqlParameter { ParameterName="@dateofbirth", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = animal.DateOfBirth },
                       new NpgsqlParameter { ParameterName="@gender", NpgsqlDbType = NpgsqlDbType.Varchar, NpgsqlValue = animal.Gender },
                       new NpgsqlParameter { ParameterName="@isneutered", NpgsqlDbType = NpgsqlDbType.Boolean, NpgsqlValue = animal.IsNeutered },
                       new NpgsqlParameter { ParameterName="@userid", NpgsqlDbType = NpgsqlDbType.Varchar, NpgsqlValue = animal.UserId },
                       new NpgsqlParameter { ParameterName="@subspeciesid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = animal.SubSpeciesId },
                       new NpgsqlParameter { ParameterName="@pregnancydate", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = animal.PregnancyDate },
           };
            return await context.Database.ExecuteSqlRawAsync(Script.AnimalUpdate, parameters)==-1?true:false;
         }

        public async Task<int> AnimalİnsertAsync(AnimalDtoInsert animal)
        {
            var parameters = new NpgsqlParameter[]
                  {
                       new NpgsqlParameter { ParameterName="@name", NpgsqlDbType = NpgsqlDbType.Varchar, NpgsqlValue = animal.Name },
                       new NpgsqlParameter { ParameterName="@dateofbirth", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = animal.DateOfBirth },
                       new NpgsqlParameter { ParameterName="@gender", NpgsqlDbType = NpgsqlDbType.Varchar, NpgsqlValue = animal.Gender },
                       new NpgsqlParameter { ParameterName="@isneutered", NpgsqlDbType = NpgsqlDbType.Boolean, NpgsqlValue = animal.IsNeutered },
                       new NpgsqlParameter { ParameterName="@userid", NpgsqlDbType = NpgsqlDbType.Varchar, NpgsqlValue = animal.UserId },
                       new NpgsqlParameter { ParameterName="@subspeciesid", NpgsqlDbType = NpgsqlDbType.Integer, NpgsqlValue = animal.SubSpeciesId },
                       new NpgsqlParameter { ParameterName="@pregnancydate", NpgsqlDbType = NpgsqlDbType.Timestamp, NpgsqlValue = animal.PregnancyDate },
                  };
          return await context.Database.ExecuteSqlRawAsync(Script.Animalİnsert, parameters);
        }
    }
}
