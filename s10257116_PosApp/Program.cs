using PosApp;
Dictionary<string, Product> productDict = new Dictionary<string, Product>();
ShoppingCart cart = new ShoppingCart();

Product p1 = new ("1001", "Apple iPhone", 1088.00);
Product p2 = new ("1005", "HTC Sensation", 888.00);
Product p3 = new ("1013", "LG Optimus 2X", 788.00);
Product p4 = new ("1022", "Motorola Atrix", 958.00);
Product p5 = new ("1027", "Samsung Galaxy", 988.00);
productDict.Add(p1.Code, p1); 
productDict.Add(p2.Code, p2);
productDict.Add(p3.Code, p3); 
productDict.Add(p4.Code, p4); 
productDict.Add(p5.Code, p5);

while (true)
{
    Console.Write("\r\n---------------- M E N U -----------------\r\n" +
    "[1] List all products and prices\r\n" +
    "[2] Add item to cart\r\n" +
    "[3] View cart items\r\n" +
    "[4] Remove item from cart\r\n" +
    "[5] Clear cart items\r\n" +
    "[0] Exit\r\n------------------------------------------\r\n" +
    "Enter your option : ");
    int opt = Convert.ToInt32(Console.ReadLine());
    if (opt == 1)
    {
        foreach (Product p in productDict.Values)
        {
            Console.WriteLine(p.ToString());
        }
    }
    else if (opt == 2)
    {
        foreach (Product p in productDict.Values)
        {
            Console.WriteLine(p.ToString());
        }
        Console.WriteLine();
        Console.Write("Enter product code: ");
        string code = Console.ReadLine();
        Console.Write("Enter quantity: ");
        int quan = Convert.ToInt32(Console.ReadLine());
        CartItem CI = new CartItem(code, productDict[code].Name, productDict[code].Price, quan);
        cart.AddItem(CI);
    }
    else if (opt == 3)
    {
        double total = 0;
        if (cart.IsEmpty() == false)
        {
            foreach (CartItem CI in cart.itemList)
            {
                total += CI.Price * CI.Qty;
                Console.WriteLine(CI.ToString() + "\tSub-Total: $" + CI.Price * CI.Qty);
            }
            Console.WriteLine("Grand Total: $" + total);
        }
        else
        {
            Console.WriteLine("Cart List is empty.");
        }
    }
    else if (opt == 4)
    {
        foreach (Product p in productDict.Values)
        {
            Console.WriteLine(p.ToString());
        }
        Console.WriteLine();
        Console.Write("Enter product code to remove: ");
        string code = Console.ReadLine();
        for (int i = 0; i < cart.itemList.Count; i++)
        {
            if (cart.itemList[i].Code == code)
            {
                cart.RemoveItem(i);
            }
        }
    }
    else if (opt == 5)
    {
        cart.ClearCart();
    }
    else if (opt == 0)
    {
        break;
    }
}