using System.Data.Linq;
using DapperExample.LinSqlModels;

namespace DapperExample.DbContext
{
    public class NwLinqContext : DataContext
    {
        public NwLinqContext(string connection) : base(connection)
        {
        }

        public Table<Order> Orders;
        public Table<Customer> Customers;
        public Table<Employee> Employees;
    }
}
