using DapperExample.DbContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using DapperExample.Model;

namespace DapperExample.Frameworks
{
    class EntityTest : ITestSignature
    {

        private NwEntityContext model;
        private static readonly string method = "entity";

        public EntityTest()
        {
            model = new NwEntityContext();
         }

        public long GetCustomersByCountry(string countryName)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            List<Customer> result;
            using (NwEntityContext context = new NwEntityContext())
            {
                result = context.Customers.Where(x => x.Country == countryName).ToList();
            }
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.getCustomerData(result, method);

            return elapsedTime;
        }

        public long GetOrdersByCustomer(string customerId)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            List<Order> result;
            using (NwEntityContext context = new NwEntityContext())
            {
                result = context.Orders.Include(x => x.Customer).Include(x => x.Customer).Where(x => x.Customer.CustomerID == customerId).ToList();
            }
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.GetOrdersByCustomer(result, method);

            return elapsedTime;
        }

        public long GetCustomerAndOrdersByEmp(int empId)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            List<Order> result;
            using (NwEntityContext context = new NwEntityContext())
            {
                result = context.Orders.Include(x => x.Customer).Include(x => x.Customer).Include(x => x.Employee).Where(x => x.Employee.EmployeeID == empId).ToList();
            }
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.GetCustomerAndOrdersByEmp(result, method);

            return elapsedTime;
        }
    }
}
