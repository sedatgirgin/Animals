using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Animals.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class, new()
    {
        List<T> TListExpression(Expression<Func<T, bool>> where);
        T TFindExpression(Expression<Func<T, bool>> where);
        List<T> TList();
        void TAdd(T data);

        void TDelete(T data);

        void TUpdate(T data);
        T TGet(int id);
        void Save();

    }
}
