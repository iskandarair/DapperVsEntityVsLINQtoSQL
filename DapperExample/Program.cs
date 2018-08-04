using DapperExample.Frameworks;
using DapperExample.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeCountLogger.Initialize();
            ResultNLogger.Initialize();

            ITestSignature test = new DapperTest();
            TestMethod(test,"Dapper");
            test = new EntityTest();
            TestMethod(test, "Entity");
            test = new LinqTest();
            TestMethod(test, "Linq");

            Console.ReadKey();
        }

        public static void TestMethod(ITestSignature test, string method)
        {
            var iterations = 10;
            for (int i = 1; i <= iterations; i++)
            {
                var customerByCountryTime = test.GetCustomersByCountry("Germany");
                TimeCountLogger.Info($"Query 1: || Iteration: {i}: || Elapsed Time: {customerByCountryTime}", method);
            }
            for (int i = 1; i <= iterations; i++)
            {
                var orerByCustomerTime = test.GetOrdersByCustomer("ANTON");
                TimeCountLogger.Info($"Query 2: || Iteration: {i}: || Elapsed Time: {orerByCustomerTime}", method);
            }
            for (int i = 1; i <= iterations; i++)
            {
                var custAndOrdByEmpTime = test.GetCustomerAndOrdersByEmp(3);
                TimeCountLogger.Info($"Query 3: || Iteration: {i}: || Elapsed Time: {custAndOrdByEmpTime}", method);
            }
        }

    }
}
