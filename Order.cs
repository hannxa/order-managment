using System;
using System.Collections.Generic;
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
    zamknięte
}
class Order
{
    private int id { get; set; }
    private int amount { get; set; }
    private string nazwa { get; set; }
    private string klientType { get; set; }
    private string adres { get; set; }
    private string paymentMethod { get; set; }

    private static List<Order> orders = new List<Order>();

    private static int nextOrder = 0;
    private OrderStatus Status { get; set; }

    public Order(string nazwa, int amount, string klientType, string adres, string paymentMethod)
    { 
        this.amount = amount;
        this.nazwa = nazwa;
        this.klientType = klientType;
        this.paymentMethod = paymentMethod;
        this.adres = adres;
        this.id = nextOrder++;
    }
    public Order(int id) { }

    public void MakeOrder()
    {
        orders.Add(this);
        orders[id].Status = OrderStatus.Nowe;

        Console.WriteLine("Stworzono zamówienie:");
        Console.WriteLine($"Nazwa: {this.nazwa}");
        Console.WriteLine($"Ilość: {this.amount}");
        Console.WriteLine($"Klient: {this.klientType}");
        Console.WriteLine($"Adres: {this.adres}");
        Console.WriteLine($"Metoda płatności: {this.paymentMethod}");

    }
    public static void MoveOrderToMagazine(int id)
    {
        Console.SetCursorPosition(2, 2);
        orders[id].Status = OrderStatus.WMagazynie;
    }
    public static void MoveOrderToShipment(int id)
    {
        Console.SetCursorPosition(2, 2);
        orders[id].Status = OrderStatus.Wysylka;
    }
    public static void SeeOrders()
    {
        foreach(Order order in orders)
        {
            Console.WriteLine($"ID: {order.id}, Nazwa: {order.nazwa}, Ilość: {order.amount}, Status: {order.Status}, Sposób płatności: {order.paymentMethod}");
        }

    }
}

