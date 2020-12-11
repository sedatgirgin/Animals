using Animals.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Repositories.Concrate
{
    public  class RepositoryBase
    {
        protected static AnimalsDbContext context;
        private static object obj = new object();
        public RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (context == null)
            {
                //lock = eger 2 request geldiyse biri bitmeden diğerine devam etmiyor.
                lock (obj)
                {
                    context = new AnimalsDbContext();
                }
            }
        }
    }
}
