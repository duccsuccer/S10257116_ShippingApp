using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    internal class Product
    {
        public string Code {  get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Product() { }
        public Product(string code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Code: {Code} Name: {Name} Price: {Price}";
        }
    }
}
