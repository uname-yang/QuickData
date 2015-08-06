using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Model.Models.Mapping
{
    public class KeyValueSTMap : EntityTypeConfiguration<KeyValueST>
    {
        public KeyValueSTMap()
        {
            HasKey(p => p.ID);
            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
