using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shippingapp
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public ShippingAddr Addr { get; set; }
        public Customer() { }
        public Customer (string n , string t, ShippingAddr a) 
        {
            Name = n ;
            Tel = t ;
            Addr = a ;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Tel: {Tel}, Shipping Address: {Addr} ";
        }
    }
}
