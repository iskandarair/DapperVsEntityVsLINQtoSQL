using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.LinSqlModels
{
    [Table(Name ="Customers")]
    public class Customer
    {
        public Customer()
        {
            this._Orders = new EntitySet<Order>();
        }
        [Column(Name ="CustomerID",IsPrimaryKey = true, IsDbGenerated = true)]
        public string CustomerID { get; set; }
        [Column(Name = "CompanyName")]
        public string CompanyName { get; set; }
        [Column(Name = "ContactName")]
        public string ContactName { get; set; }
        [Column(Name = "ContactTitle")]
        public string ContactTitle { get; set; }
        [Column(Name = "Address")]
        public string Address { get; set; }
        [Column(Name ="City")]
        public string City { get; set; }
        [Column(Name = "Region")]
        public string Region { get; set; }
        [Column(Name = "PostalCode")]
        public string PostalCode { get; set; }
        [Column(Name = "Country")]
        public string Country { get; set; }
        [Column(Name = "Phone")]
        public string Phone { get; set; }
        [Column(Name = "Fax")]
        public string Fax { get; set; }

        // NOT REQUIRED BUT GOOD TO HAVE  ORDERS of Customers
        private EntitySet<Order> _Orders;
        [Association(Storage ="_Orders",OtherKey ="CustomerID")]
        public EntitySet<Order> Orders
        {
            get { return this._Orders; }
            set { this._Orders.Assign(value); }
        }
    }
}
