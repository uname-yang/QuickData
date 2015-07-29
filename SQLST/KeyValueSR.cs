using SQLST.Data;
using SQLST.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLST
{
    public class KeyValueSR : RepositoryBase<KeyValueST>, IKeyValueSR
    {
        public KeyValueSR(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

    }
}
