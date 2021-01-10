using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.GenericRepositories.DbScript
{
    public static class Script
    {
        public static string AnimalList = @"select * from ""Animals"" where ""UserId""=@userid";
        public static string Animalİnsert = @"call sp_animal_insert(@name, @dateofbirth,@gender , @isneutered , @userid , @subspeciesid , @pregnancydate)";
        public static string AnimalDelete = @"call  sp_animal_delete(@id)";
        public static string AnimalUpdate = @"call  sp_animal_update(@id,@name, @dateofbirth,@gender , @isneutered , @userid , @subspeciesid , @pregnancydate)";
        public static string AnimalVaccine = @" select * from ""Vaccines""  where ""Id"" in (select ""VaccineId"" from ""AnimalVaccines"" where  ""AnimalId"" = @animalid)";
        public static string AnimalVaccineDelete = @"call  sp_animal_vaccine_delete(@id)";
        public static string AnimalVaccineInsert = @"call sp_animal_vaccine_insert(@animalid, @vaccineid,@date )";
        public static string ReminderDelete = @"call  sp_reminder_delete(@id)";
        public static string ReminderInsert = @"call  sp_reminder_insert(@animalid,@message,@isperiodic,@period,@date,@remindertypeid)";
        public static string ReminderUpdate = @"call  sp_reminder_update(@id,@animalid,@message,@isperiodic,@period,@date,@remindertypeid)";
        public static string ReminderList = @"select * from ""Reminders"" where ""AnimalId""=@animalId";
        public static string WeightDelete = @"call  sp_weight_delete(@id)";
        public static string WeightInsert = @"call  sp_weight_insert(@animalid,@date,@value)";
        public static string WeightList = @"select * from ""Weights"" where ""AnimalId""=@animalId";

    }
}
