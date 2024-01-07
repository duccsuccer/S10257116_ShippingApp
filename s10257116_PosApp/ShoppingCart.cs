using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    internal class ShoppingCart
    {
        public List<CartItem> itemList { get; set; } = new();
        public ShoppingCart() { }
        public void AddItem(CartItem item) 
        { 
            itemList.Add(item);
        }
        public List<CartItem> GetItemList()
        {
            return itemList;
        }
        public bool RemoveItem(int qty) 
        { 
            foreach (CartItem item in itemList)
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
        { itemList.Clear(); }
        public int Size()
        { return itemList.Count; }
        public bool IsEmpty()
        { 
            if(itemList.Count > 0)
            {
                return false;
            }
            return true;
        }

    }
}
