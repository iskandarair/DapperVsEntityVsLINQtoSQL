using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Configuration;
using DapperExample.DbContext;
using System.Diagnostics;

namespace DapperExample.Frameworks
{
    public class LinqTest : ITestSignature
    {
        private NwLinqContext db = null;
        private static readonly string method = "linq";

        public LinqTest()
        {
            var connString = Constants.GetConnString();
            db = new NwLinqContext(connString);
        }
        public long GetCustomersByCountry(string countryName)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            var query = from c in db.Customers
                         where c.Country == countryName
                        select c;
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.getCustomerData(query.ToList(), method);

            return elapsedTime;
        }

        public long GetOrdersByCustomer(string customerId)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            var query = from order in db.Orders
                        join customer in db.Customers on order.CustomerID equals customer.CustomerID
                        where customer.CustomerID == customerId
                        select order;
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.GetOrdersByCustomer(query.ToList(), method);
            return elapsedTime;
        }

        public long GetCustomerAndOrdersByEmp(int empId)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            var query = from order in db.Orders
                            join customer in db.Customers on order.CustomerID equals customer.CustomerID
                            join employee in db.Employees on order.EmployeeID equals employee.EmployeeID
                            where employee.EmployeeID == empId
                            select order;
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.GetCustomerAndOrdersByEmp(query.ToList(), method);


            return elapsedTime;
        }
    }
}
