using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Model.Models
{
    public class KeyValueST
    {
        public int ID { get; set; }
        public int type { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public bool isShare { get; set; }
        public bool readOnly { get; set; }

        public virtual Authorize AuthorizedID { get; set; }
    }
}
