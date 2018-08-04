using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace DapperExample.LinSqlModels
{
    [Table(Name = "Orders")]
    public class Order
    {
        //  [Column(Storage ="OrderID", IsPrimaryKey =true)]
        [Column(Name = "OrderID", IsPrimaryKey = true)]
        public int OrderID { get; set; }

        private EntityRef<Customer> _Customer;
        [Column(Name = "CustomerID", DbType = "NChar(5)")]
        public string CustomerID { get; set; }
        [Column(Name = "EmployeeID", DbType = "Int")]
        public int EmployeeID { get; set; }

        private EntityRef<Employee> _Employee;
        [Column(Name = "OrderDate")]
        public DateTime? OrderDate { get; set; }
        [Column(Name = "RequiredDate")]
        public DateTime? RequiredDate { get; set; }
        [Column(Name = "ShippedDate")]
        public DateTime? ShippedDate { get; set; }
        [Column(Name = "ShipVia")]
        public int ShipVia { get; set; }
        [Column(Name = "Freight")]
        public decimal? Freight { get; set; }
        [Column(Name = "ShipName")]
        public string ShipName { get; set; }
        [Column(Name = "ShipAddress")]
        public string ShipAddress { get; set; }
        [Column(Name = "ShipCity")]
        public string ShipCity { get; set; }
        [Column(Name = "ShipRegion")]
        public string ShipRegion { get; set; }
        [Column(Name = "ShipPostalCode")]
        public string ShipPostalCode { get; set; }
        [Column(Name = "ShipCountry")]
        public string ShipCountry { get; set; }



        [Association(Storage = "_Customer", ThisKey = "CustomerID")]
        public Customer Customer
        {
            get { return this._Customer.Entity; }
            set { this._Customer.Entity = value; }
        }
        [Association(Storage = "_Employee", ThisKey = "EmployeeID")]
        public Employee Employee
        {
            get { return this._Employee.Entity; }
            set { this._Employee.Entity = value; }
        }
    }
}
