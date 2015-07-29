using FastDB.Service;
using SQLST;
using SQLST.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.AOF
{
    public  class AOFAdapter : IAOF
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKeyValueSR _keyValue;
        public AOFAdapter(IUnitOfWork unitOfWork, IKeyValueSR KeyValue)
        {
            _unitOfWork = unitOfWork;
            _keyValue = KeyValue;
        }

        public void sb(string customerId, int year)
        {
            // add business logic here
            //_keyValue.
        }
    }
}
