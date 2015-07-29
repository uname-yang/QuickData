using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Data
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T Find(params object[] keyValues);

        IQueryable<T> Queryable();
        IQueryable<T> Queryable(Expression<Func<T, bool>> where);
        IQueryable<T> Query(string sql, object[] param);
        void Excute(string sql, object[] param);
        /*#######################################################*/
        T Get(Expression<Func<T, bool>> where);
        int Count();
    }
}
