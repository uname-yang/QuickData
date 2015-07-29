using SQLST.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLST.Model
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
             : base("Database")
        {
            //Do something here
        }

        public DbSet<KeyValueST> kvtable { get; set; }
        //public DbSet<Order> order { get; set; }
        //public DbSet<Customer> customer { get; set; }
        //public DbSet<OrderDetail> orderDetail { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new FormContentConfiguration());
            //modelBuilder.Configurations.Add(new CustomerMap());
            //modelBuilder.Configurations.Add(new OrderMap());
            //modelBuilder.Configurations.Add(new OrderDetailMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}
