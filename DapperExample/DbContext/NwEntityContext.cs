using System.Data.Entity;
using DapperExample.Model;

namespace DapperExample.DbContext
{
    public class NwEntityContext : System.Data.Entity.DbContext
    {
        public NwEntityContext()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
