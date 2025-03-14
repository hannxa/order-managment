using System.Collections.Specialized;
using System.Data;
using System.Reflection.Metadata;
using System.Security;

class Program
{
   
    static void exit()
    {
        Console.SetCursorPosition(2, 2);

    }
    static void menu()
    {
        Console.SetCursorPosition(2, 2);
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Utwórz przykładowe zamówienie");
        Console.WriteLine("2. Przekaż zamówienie do magazynu");
        Console.WriteLine("3. Przekazanie zamówienia do wysyłki");
        Console.WriteLine("4. Wyświetl liste zamówień");
        Console.WriteLine("4. Wyjście");
        Console.WriteLine("Wybierz numer:");
        string userInput = Console.ReadLine();

        int menuNumber;

        if (int.TryParse(userInput, out menuNumber))
        {
            if (menuNumber == 1)
            {
                string nazwa;
                do
                {
                    Console.Write("Podaj nazwę produktu: ");
                    nazwa = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nazwa))
                    {
                        Console.WriteLine("Nazwa produktu nie może być pusta. Spróbuj ponownie");
                    }
                } while (string.IsNullOrWhiteSpace(nazwa));


                int amount;
                do
                { 
                    Console.Write("Podaj ilość: ");                                        
                } while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0);

                string klientType;
                do
                {
                    Console.Write("Podaj typ klienta (Firma- F/osoba fizyczna- OF): ");
                    klientType = Console.ReadLine().ToUpper();
                    if (klientType != "F" && klientType != "OF")
                    {
                        Console.WriteLine("Podano brak lub zły typ klienta. Spróbuj ponownie- (Firma- F/osoba fizyczna- OF)");
                    }
                } while (klientType != "F" && klientType != "OF");


                string paymentMethod;
                do
                {
                    Console.Write("Podaj sposób płatności (wciśnij 'K' jeżeli karta lub 'G' jeżeli gotówka przy odbiorze: ");
                    paymentMethod = Console.ReadLine().ToUpper();
                    if (paymentMethod != "K" && paymentMethod != "G")
                    {
                        Console.WriteLine("Podaj właściwy znak: 'K', jeżeli karta lub 'G', jeżeli gotówka przy odbiorze.");
                    }
                } while (paymentMethod != "K" && paymentMethod != "G");

                string adres;
               
                Console.Write("Podaj adres dostawy: ");
                adres = Console.ReadLine();
                               
                Order order = new Order(nazwa, amount, klientType, adres, paymentMethod);
                order.MakeOrder();
                
            }else if(menuNumber == 2)
            {
                Console.WriteLine("Podaj ID zamówienia do przeniesienia do magazynu lub napisz 'lista', żeby wyświetlić liste zamówień");

                if(Console.ReadLine() == "lista"){
                    Order.SeeOrders();
                    Console.WriteLine("Podaj ID zamówienia do przeniesienia do magazynu: ");
                }
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Order.MoveOrderToMagazine(id);
                }
                else
                {
                    Console.WriteLine("Niepoprawne ID zamówienia");
                }
            }
            else if (menuNumber == 3)
            {
                Console.Write("Podaj ID zamówienia do przeniesienia do wysyłki: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Order.MoveOrderToShipment(id);
                }
                else
                {
                    Console.WriteLine("Niepoprawne ID zamówienia.");
                }
            }
            else if (menuNumber == 4)
            {
                Order.SeeOrders();
            }
            else if (menuNumber == 5)
            {
                Console.WriteLine("Jesteś pewien/ pewna, że chcesz opuścić program? Odpowiedz: tak lub nie");
                string answer = Console.ReadLine();

                if(answer.ToLower() == "tak")
                {
                    try
                    {
                        Environment.Exit(0);
                    } catch (SecurityException se)
                    {
                        Console.WriteLine(se);
                    }
                }
            }
            Console.WriteLine("Nacisnij dowolny klawisz, aby wrócić do menu");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Niepoprawny wybór");
            menu();
        }
    }
    static void Main()
    {
        while (true)
        {
            menu();
            Console.Clear();
        }
    }
}
