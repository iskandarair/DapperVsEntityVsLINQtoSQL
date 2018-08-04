using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DapperExample
{
    public static class Constants
    {
        private static readonly string CONN_STRING_NAME = "NorthWind";

        public static string GET_CUSTOMERS_BY_COUNTRY = "SELECT * FROM Customers WHERE Country = @Country";

        public static string GET_CUSTOMERS_ORDER = @"SELECT o.OrderID, o.CustomerID, o.EmployeeID, o.OrderDate,o.RequiredDate,o.ShippedDate,o.ShipVia, o.Freight,o.ShipName, o.ShipAddress, o.ShipCity, o.ShipRegion, o.ShipPostalCode, o.ShipCountry, c.CustomerID as CustomerID,c.CompanyName, c.ContactName, c.ContactTitle, c.Address, c.City, c.Region, c.PostalCode, c.Country, c.Phone, c.Fax FROM Orders o
          INNER JOIN Customers c ON c.CustomerID = o.CustomerID
          WHERE o.CustomerID = @CustomerID";

        public static string GET_ENTIRE_ORDER = @"SELECT o.OrderID, o.CustomerID, o.EmployeeID, o.OrderDate,o.RequiredDate,o.ShippedDate,o.ShipVia, o.Freight,o.ShipName, o.ShipAddress, o.ShipCity, o.ShipRegion, o.ShipPostalCode, o.ShipCountry, e.EmployeeID as EmployeeID, e.LastName, e.FirstName, e.Title, e.TitleOfCourtesy, e.BirthDate, e.HireDate, e.Address, e.City, e.Region, e.PostalCode, e.Country, e.HomePhone, e.Extension, e.Photo, e.Notes, e.ReportsTo, e.PhotoPath, c.CustomerID as CustomerID,c.CompanyName, c.ContactName, c.ContactTitle, c.Address, c.City, c.Region, c.PostalCode, c.Country, c.Phone, c.Fax FROM Orders o
          INNER JOIN Customers c ON c.CustomerID = o.CustomerID
          INNER JOIN Employees e ON e.EmployeeID = o.EmployeeID
          WHERE e.EmployeeID = @EmployeeID";

        public static string GetConnString()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings[CONN_STRING_NAME].ConnectionString;
            return connString;
        }


    }
}
