using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum OrderStatus
{
    Nowe,
    WMagazynie,
    Wysylka,
    Zwrocone,
    Blad,
    Zamkniete
}
class Order
{
    private int Id { get; set; }
    private int Amount { get; set; }
    private string Nazwa { get; set; }
    private string KlientType { get; set; }
    private string Adres { get; set; }
    private string PaymentMethod { get; set; }
    private DateTime TimeOrder { get; set; }

    private static List<Order> orders = new List<Order>();

    private static int nextOrder = 0;
    private OrderStatus Status { get; set; }

    public Order(string nazwa, int amount, string klientType, string adres, string paymentMethod)
    { 
        this.Amount = amount;
        this.Nazwa = nazwa;
        this.KlientType = klientType;
        this.PaymentMethod = paymentMethod;
        this.Adres = adres;
        this.Id = nextOrder++;
        this.TimeOrder = DateTime.Now;
    }

    public void MakeOrder()
    {
        orders.Add(this);
        orders[Id].Status = OrderStatus.Nowe;

        Console.WriteLine($"Zamówienie nr: {this.Id} zostało utworzone.");
        Console.WriteLine($"Nazwa: {this.Nazwa}, Ilość: {this.Amount}, Klient: {this.KlientType}," +
            $" Adres: {this.Adres}, Sposób płatności: {this.PaymentMethod}");
    }
    public static void MoveOrderToMagazine(int id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            Console.WriteLine("Nie znaleziono zamówienia o taim ID.");
            return;
        }
        if (string.IsNullOrEmpty(order.Adres))
        {
            order.Status = OrderStatus.Blad;
            Console.WriteLine($"Zamówienie nr {order.Id} zakończyło się błędem (brak adresu dostawy)");
            return;
        }

        if(order.Amount < 2500 && order.PaymentMethod == "G")
        {
            order.Status = OrderStatus.Zwrocone;
            Console.WriteLine($"Zamówienie nr: {order.Id} zostało przeniesione do wysyłki. Status zmieni się po 5 sekundach.");
            return;
        }
        order.Status = OrderStatus.Wysylka;

        Thread.Sleep(5000);
        order.Status = OrderStatus.Zamkniete;
        Console.WriteLine($"Zamówienie nr {order.Id} zostało wysłane.");
    }
    public static void MoveOrderToShipment(int id)
    {
        Console.SetCursorPosition(2, 2);
        orders[id].Status = OrderStatus.Wysylka;
    }
    public static void SeeOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("Brak zamówień");
            return;
        }

        foreach(Order order in orders)
        {
            Console.WriteLine($"ID: {order.Id}, Nazwa: {order.Nazwa}, Ilość: {order.Amount}, Status: {order.Status}, Sposób płatności: {order.PaymentMethod}, Data i czas złożonego zamówienia: {order.TimeOrder}");
        }
        
    }
    public static void SeeOrdersByTime(DateTime startDate, DateTime endDate)
    {
        var filteredOrders = orders.Where(order => order.TimeOrder >= startDate && order.TimeOrder <= endDate)
                                           .OrderByDescending(order => order.TimeOrder)
                                           .ToList();

        foreach (Order order in filteredOrders)
        {
            Console.WriteLine($"ID: {order.Id}, Nazwa: {order.Nazwa}, Ilość: {order.Amount}, Status: {order.Status}, Sposób płatności: {order.PaymentMethod}, Data: {order.TimeOrder}");
        }

        if(filteredOrders.Count == 0)
        {
            Console.WriteLine("Brak zamówień w podanym przedziale czasowym");
        }
    }
}

