using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Frameworks
{
    public interface ITestSignature
    {
        long GetCustomersByCountry(string countryName);
        long GetOrdersByCustomer(string customerId);
        long GetCustomerAndOrdersByEmp(int empId);
    }
}
