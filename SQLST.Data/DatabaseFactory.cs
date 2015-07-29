using SQLST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Data
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DatabaseContext database;

        public DatabaseContext Get()
        {
            return database ?? (database = new DatabaseContext());
        }

        protected override void DisposeCore()
        {
            if (database != null)
                database.Dispose();
        }
    }
}
