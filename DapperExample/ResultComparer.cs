using DapperExample.LinSqlModels;
using DapperExample.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperObjects = DapperExample.Model;

namespace DapperExample
{
    public static class ResultComparer
    {
        // for L I N Q   A N D   D A P P E R   O B J E C T S
        public static void getCustomerData(List<DapperObjects.Customer> customers, string methodName)
        {
            var result = new StringBuilder();
            result.AppendLine("Q U E R Y  1");
            foreach (var customer in customers)
            {
                result.AppendLine($"Customer ID: {customer.CustomerID} || Customer Name: {customer.ContactName}");
            }
            ResultNLogger.Info(result.ToString(), methodName);
        }
        public static void GetOrdersByCustomer(List<DapperObjects.Order> orders, string methodName)
        {
            var result = new StringBuilder();
            result.AppendLine("Q U E R Y  2");
            foreach (var order in orders)
            {
                result.AppendLine($"Order ID: {order.OrderID} || Customer ID: {order.Customer.CustomerID} || Customer Name: {order.Customer.ContactName}");
            }
            ResultNLogger.Info(result.ToString(), methodName);
        }
        public static void GetCustomerAndOrdersByEmp(List<DapperObjects.Order> orders, string methodName)
        {
            var result = new StringBuilder();
            result.AppendLine("Q U E R Y  3");
            foreach (var order in orders)
            {
                result.AppendLine($"Order ID: {order.OrderID} || Customer ID: {order.Customer.CustomerID} || Customer Name: {order.Customer.ContactName} || Employee ID: {order.Employee.EmployeeID} || Employee Name : {order.Employee.FirstName} {order.Employee.LastName} ");
            }
            ResultNLogger.Info(result.ToString(), methodName);
        }

        // for L I N Q   T O   S Q L   O B J E C T S  
        public static void getCustomerData(List<Customer> customers, string methodName)
        {
            var result = new StringBuilder();
            result.AppendLine("Q U E R Y  1");
            foreach(var customer in customers)
            {
                result.AppendLine($"Customer ID: {customer.CustomerID} || Customer Name: {customer.ContactName}");
            }
            ResultNLogger.Info(result.ToString(), methodName);
        }
        public static void GetOrdersByCustomer(List<Order> orders, string methodName)
        {
            var result = new StringBuilder();
            result.AppendLine("Q U E R Y  2");
            foreach (var order in orders)
            {
                result.AppendLine($"Order ID: {order.OrderID} || Customer ID: {order.Customer.CustomerID} || Customer Name: {order.Customer.ContactName}");
            }
            ResultNLogger.Info(result.ToString(), methodName);
        }
        public static void GetCustomerAndOrdersByEmp(List<Order> orders, string methodName)
        {
            var result = new StringBuilder();
            result.AppendLine("Q U E R Y  3");
            foreach (var order in orders)
            {
                result.AppendLine($"Order ID: {order.OrderID} || Customer ID: {order.Customer.CustomerID} || Customer Name: {order.Customer.ContactName} || Employee ID: {order.Employee.EmployeeID} || Employee Name : {order.Employee.FirstName} {order.Employee.LastName} ");
            }
            ResultNLogger.Info(result.ToString(), methodName);
        }
        

    }
}
