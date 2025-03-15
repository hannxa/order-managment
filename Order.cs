enum OrderStatus
{
    Nowe,
    WMagazynie,
    Wysylka,
    ZwroconoDoKlienta,
    Blad,
    Zamkniete
}
class Order
{
    private int Amount { get; set; }
    private string PaymentMethod { get; set; }
    private int Id { get; set; }
    private DateTime TimeOrder { get; set; }
    private Customer customer { get; set; }
    public Product product { get; set; }

    private static List<Order> orders = new List<Order>();
    public OrderStatus Status { get; private set; }
    public Order(int amount, string paymentMethod, Customer customer, Product product)
    {
        Amount = amount;
        PaymentMethod = paymentMethod;
        this.customer = customer;
        this.product = product;
    }
    public void MakeOrder()
    {
        orders.Add(this);
        Product.AddProduct(product);
        customer.AddCustomerOrder(this);
        orders[Id].Status = OrderStatus.Nowe;
        Console.WriteLine($"Zamówienie nr: {this.Id} zostało utworzone.");
        string klientType;
        string paymentMethod;

        if (this.customer.KlientType == "F")
        {
            klientType = "firma";
        }
        else
        {
            klientType = "osoba fizyczna";
        }
        if(this.PaymentMethod == "K")
        {
            paymentMethod = "karta";
        }
        else
        {
            paymentMethod = "gotówka";
        }
        Console.WriteLine($"Nazwa: {this.product.Name}, kwota: {this.Amount}, klient: {klientType}," +
            $" adres: {this.customer.Address}, sposób płatności: {paymentMethod}");
    }
    public static void MoveOrderToMagazine(int id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            Console.WriteLine("Nie znaleziono zamówienia o taim ID.");
            return;
        }
        if (string.IsNullOrEmpty(order.customer.Address))
        {
            order.Status = OrderStatus.Blad;
            Console.WriteLine($"Zamówienie nr {order.Id} zakończyło się błędem (brak adresu dostawy)");
            return;
        }
        if (order.Amount < 2500 && order.PaymentMethod == "G")
        {
            order.Status = OrderStatus.ZwroconoDoKlienta;
            Console.WriteLine($"Zamówienie nr: {order.Id} zostało zwrócone do klienta.");
            return;
        }
        order.Status = OrderStatus.WMagazynie;
    }
    public static void MoveOrderToShipment(int id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);
        if(order == null)
        {
            Console.WriteLine("Zamówienie o tym numerze ID nie istnieje");
            return;
        }
        if(order.Status != OrderStatus.WMagazynie)
        {
            Console.WriteLine("Zamówienie o tym numerze ID nie istnieje");
            return;
        }

        order.Status = OrderStatus.Wysylka;
        Console.WriteLine($"Zamówienie nr {order.Id} zostało wysłane. Poczekaj na potwierdzenie...");
        Thread.Sleep(4000);
        order.Status = OrderStatus.Zamkniete;
        Console.WriteLine($"Zamówienie nr {order.Id} zostało dostarczone.");
    }
    public static void SeeOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("Brak zamówień");
            return;
        }
        string paymentMethod;
        foreach (Order order in orders)
        {
            if (order.PaymentMethod == "K")
            {
                paymentMethod = "karta";
            }
            else
            {
                paymentMethod = "gotówka";
            }
            Console.WriteLine($"ID: {order.Id}, Nazwa: {order.product.Name}, Kwota: {order.Amount}, Status: {order.Status}, Sposób płatności: {paymentMethod}, Data i czas złożonego zamówienia: {order.TimeOrder}");
        }
    }
}

