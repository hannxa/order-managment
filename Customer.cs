class Customer
{
    public int CustomerId { get; set; }
    public string KlientType { get; private set; }
    public string Address { get; private set; }
    private static int nextCustomer = 0;
    public List<Order> customerOrders = new List<Order>();
    public static List<Customer> allCustomers = new List<Customer>();
    public Customer(string klientType, string address){
        this.CustomerId = nextCustomer++;
        this.KlientType = klientType;
        this.Address = address;
        allCustomers.Add(this);
    }
    public static void SeeCustomerOrders(int id)
    {
        Customer foundCustomer = allCustomers.Find(c => c.CustomerId == id);
        if (foundCustomer == null)
        {
            Console.WriteLine($"Nie znaleziona klienta o ID: {id}");
            return;
        }
        if(foundCustomer.customerOrders.Count == 0)
        {
            Console.WriteLine("Brak zamówień.");
        }
        else
        {
            if (foundCustomer.KlientType == "F")
            {
                foundCustomer.KlientType = "firma";
            }
            else
            {
                foundCustomer.KlientType = "osoba fizyczna";
            }
            Console.WriteLine($"Zamówienie dla klienta nr: {id}, typ klienta: ({foundCustomer.KlientType}):");
            foreach (Order order in foundCustomer.customerOrders)
            {
                Console.WriteLine(order.product.Name);
            }
        }
    }
    public void AddCustomerOrder(Order order)
    {
        customerOrders.Add(order);
    }
    public static void ShowCustomerData(int id)
    {
        Customer foundCustomer = allCustomers.Find(c => c.CustomerId == id);
        if(foundCustomer != null)
        {
            if (foundCustomer.KlientType == "F")
            {
                foundCustomer.KlientType = "firma";
            }
            else
            {
                foundCustomer.KlientType = "osoba fizyczna";
            }
            Console.WriteLine($"Id klienta: {id}, klient: {foundCustomer.KlientType}," +
            $" Adres: {foundCustomer.Address}");

            SeeCustomerOrders(id);
        }
        else
        {
            Console.WriteLine($"Nie znaleziono klienta o ID {id}");
        }
    }
}

