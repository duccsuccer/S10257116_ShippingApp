using shippingapp;

List<Customer> customerList = new();

InitCustomerList(customerList);
ListCustomers(customerList);
void InitCustomerList(List<Customer> cList)
{
    ShippingAddr s1 = new("Singapore", "Clementi Rd");
    ShippingAddr s2 = new("Hong Kong", "Mongkok Rd");
    ShippingAddr s3 = new("Malaysia", "Malacca Rd");

    Customer c1 = new("John Tan", "98501111", s1);
    Customer c2 = new("Amy Lim", "99991111", s2);
    Customer c3 = new("Tony Tay", "91112222", s3);
    cList.Add(c1);
    cList.Add(c2);
    cList.Add(c3);
}
void ListCustomers(List<Customer> cList)
{
    Console.WriteLine("{0,1} {1,9} {2,12} {3,12}", "Name", "Tel", "Country", "Street");
    foreach (Customer c in cList)
    {
        Console.WriteLine($"{c.Name, -10} {c.Tel, -5} {c.Addr.Country, -13} {c.Addr.Street, -10}");
    }
}