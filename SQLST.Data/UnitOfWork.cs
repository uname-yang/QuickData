using SQLST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private DatabaseContext database;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected DatabaseContext Database
        {
            get { return database ?? (database = databaseFactory.Get()); }
        }

        public void Commit()
        {
            Database.Commit();
        }
    }
}
