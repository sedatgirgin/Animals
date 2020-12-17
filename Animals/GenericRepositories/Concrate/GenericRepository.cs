using Animals.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Animals.Repositories.Concrate
{
    public class GenericRepository<T> : RepositoryBase, IGenericRepository<T> where T : class, new()
    {
        DbSet<T> dbSet;
        public GenericRepository()
        {
            dbSet = context.Set<T>();
        }
        public List<T> TListExpression(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T TFindExpression(Expression<Func<T, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }
        public List<T> TList()
        {
            return dbSet.ToList();
        }
        public void TAdd(T data)
        {
           dbSet.Add(data);
            Save();
        }

        public void TDelete(T data)
        {
            dbSet.Remove(data);
            Save();
        }

        public void TUpdate(T data)
        {
            dbSet.Update(data);
            Save();
        }
        public T TGet(int id)
        {
            return dbSet.Find(id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
