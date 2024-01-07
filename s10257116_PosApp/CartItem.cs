using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    internal class CartItem : Product
    {
        public int Qty { get; set; }
        public CartItem() { }
        public CartItem(string code, string name, double price, int qty) : base(code, name, price)
        {
            Qty = qty;
        }
        public override string ToString()
        {
            return base.ToString + $"Qty: {Qty}";
        }
    }
}
