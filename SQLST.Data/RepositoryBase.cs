using SQLST.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Data
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private DatabaseContext database;
        private readonly IDbSet<T> dbset;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = Database.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected DatabaseContext Database
        {
            get { return database ?? (database = DatabaseFactory.Get()); }
        }

        public virtual void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<T> entitys)
        {
            foreach (T entity in entitys)
            {
                dbset.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            database.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            var query = dbset.Where<T>(where);
            if (query.Count() > 0)
                return query.First();
            return null;
        }

        public virtual int Count()
        {
            return dbset.Count();
        }

        public virtual void Excute(string sql, object[] param)
        {
            database.Database.ExecuteSqlCommand(sql, param);
        }

        public virtual IQueryable<T> Query(string sql, object[] param)
        {
            return database.Database.SqlQuery<T>(sql, param).AsQueryable();
        }

        //GET ALL
        public virtual IQueryable<T> Queryable()
        {
            return dbset;
        }

        public virtual IQueryable<T> Queryable(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where);
        }

        public virtual T Find(params object[] keyValues)
        {
            return dbset.Find(keyValues);
        }

        //public IRepository<T> GetRepository<T>() where T : class
        //{
        //    return new RepositoryBase<T>();// database.Set<T>();
        //}


    }
}
