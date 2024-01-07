using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    internal class ShoppingCart
    {
        public List<CartItem> Itemlist { get; set; } = new();
        public ShoppingCart() { }
        public void AddItem(CartItem item) 
        { 
            Itemlist.Add(item);
        }
        public List<CartItem> GetItemList()
        {
            return Itemlist;
        }
        public bool RemoveItem(int qty) 
        { 
            foreach (CartItem item in Itemlist)
            {
                if (item.Qty < qty)
                {
                    return false;
                }
                item.Qty =- qty;
            }
            return true;
        }
        public void ClearCart()
        { Itemlist.Clear(); }
        public int Size()
        { return Itemlist.Count; }
        public bool IsEmpty()
        { 
            if(Itemlist.Count > 0)
            {
                return false;
            }
            return true;
        }

    }
}
