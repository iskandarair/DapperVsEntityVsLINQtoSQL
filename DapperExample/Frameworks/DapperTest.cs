using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Dapper;
using DapperExample.Model;

namespace DapperExample.Frameworks
{
    public class DapperTest : ITestSignature
    {
        private string connString = null;
        private static readonly string method = "dapper";
        public DapperTest()
        {
            connString = Constants.GetConnString();
        }
        public long GetCustomersByCountry(string countryName)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            List<Customer> result;
            using (IDbConnection db = new SqlConnection(connString))
            {
                result = db.Query<Customer>(Constants.GET_CUSTOMERS_BY_COUNTRY, new {Country = countryName }).ToList();
            }
            clock.Stop();
            ResultComparer.getCustomerData(result, method);
            var elapsedTime = clock.ElapsedMilliseconds;

            return elapsedTime;
        }

        public long GetOrdersByCustomer(string id)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            List<Order> customerOrders;
            using (IDbConnection db = new SqlConnection(connString))
            {
                customerOrders = db.Query<Order, Customer, Order>(Constants.GET_CUSTOMERS_ORDER,
                     (order, customer) =>
                     {
                         order.Customer = customer;
                         return order;
                     },
                     new { CustomerID = id},
                     splitOn: "CustomerID").ToList();
            }
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.GetOrdersByCustomer(customerOrders, method);

            return elapsedTime;
        }

        public long GetCustomerAndOrdersByEmp(int empID)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            List<Order> result;
            using (IDbConnection db = new SqlConnection(connString))
            {
                result = db.Query<Order, Employee, Customer, Order>(Constants.GET_ENTIRE_ORDER,
                     (order, employee, customer) =>
                     {
                         order.Employee = employee;
                         order.Customer = customer;
                         return order;
                     },
                     new { EmployeeID = empID},
                     splitOn: "EmployeeID, CustomerID").ToList();
            }
            clock.Stop();
            var elapsedTime = clock.ElapsedMilliseconds;
            ResultComparer.GetCustomerAndOrdersByEmp(result, method);

            return elapsedTime;
        }
    }
}
