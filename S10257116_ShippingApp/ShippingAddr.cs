using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shippingapp
{
    internal class ShippingAddr
    {
        public string Country { get; set; } 
        public string Street { get; set; }  
     
        public ShippingAddr(string country, string street)
        {
            Country = country;
            Street = street;
        }
        public override string ToString()
        {
            return $"Country: {Country} Street: {Street}";
        }
    }
}
