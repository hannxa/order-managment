using System.Security;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                menu();
                Console.WriteLine(" ");
            }
        }
        static void menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Utwórz przykładowe zamówienie");
            Console.WriteLine("2. Przekaż zamówienie do magazynu");
            Console.WriteLine("3. Przekazanie zamówienia do wysyłki");
            Console.WriteLine("4. Wyświetl liste zamówień");
            Console.WriteLine("5. Wyświetl ilość zamówienionego produktu");
            Console.WriteLine("6. Wyświetl dane klienta");
            Console.WriteLine("7. Wyjście");
            Console.WriteLine("Wybierz numer:");
            string userInput = Console.ReadLine();

            int menuNumber;

            if (int.TryParse(userInput, out menuNumber))
            {
                Console.Clear();
                switch (menuNumber)
                {
                    case 1:
                        CreateOrder();
                        break;
                    case 2:
                        MoveToMagazine();
                        break;
                    case 3:
                        MoveToShipment();
                        break;
                    case 4:
                        SeeOrders();
                        break;
                    case 5:
                        HowMuchProduct();
                        break;
                    case 6:
                        ShowCustomerData();
                        break;
                    case 7:
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        break;
                }
                Console.WriteLine("Nacisnij dowolny klawisz, aby wrócić do menu");
                Console.ReadKey();
            }
        }
        static void CreateOrder()
        {
            string name;
            do
            {
                Console.Write("Podaj nazwę produktu: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Nazwa produktu nie może być pusta. Spróbuj ponownie");
                }
            } while (string.IsNullOrWhiteSpace(name));


            int amount;
            do
            {
                Console.Write("Podaj kwote: ");
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

            Customer customer = new Customer(klientType, adres);
            Product product = new Product(name);
            Order order = new Order(amount, paymentMethod, customer, product);
            order.MakeOrder();
        }
        static void MoveToMagazine()
        {
            Console.WriteLine("Podaj ID zamówienia do przeniesienia do magazynu lub napisz 'lista', żeby najpierw wyświetlić listę zamówień:");
            string input = Console.ReadLine();

            if (input.Equals("lista", StringComparison.OrdinalIgnoreCase))
            {
                Order.SeeOrders();

                while (true)
                {
                    Console.WriteLine("Podaj ID zamówienia do przeniesienia do magazynu lub kliknij enter, żeby przejść do menu:");
                    string orderInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(orderInput))
                    {
                        return;
                    }

                    if (int.TryParse(orderInput, out int id))
                    {
                        Order.MoveOrderToMagazine(id);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawne ID zamówienia.");
                    }
                }
            }
            else
            {
                if (int.TryParse(input, out int id))
                {
                    Order.MoveOrderToMagazine(id);
                }
                else
                {
                    Console.WriteLine("Niepoprawne ID zamówienia.");
                }
            }
        }
        static void MoveToShipment()
        {
            int id;

            Console.WriteLine("Podaj ID zamówienia do wysyłki lub napisz 'lista', żeby najpierw wyświetlić listę zamówień:");
            string input = Console.ReadLine();
            if (input.Equals("lista", StringComparison.OrdinalIgnoreCase))
            {
                Order.SeeOrders();
                while (true)
                {
                    Console.WriteLine("Podaj ID zamówienia do wysyłki lub kliknij enter, żeby przejść do menu:");
                    string orderInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(orderInput))
                    {
                        return;
                    }

                    if (int.TryParse(orderInput, out id))
                    {
                        Order.MoveOrderToShipment(id);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawne ID zamówienia.");
                    }
                }
            }
            else
            {
                if (int.TryParse(input, out id))
                {
                    Order.MoveOrderToMagazine(id);
                }
                else
                {
                    Console.WriteLine("Niepoprawne ID zamówienia.");
                }
            }
        }
        static void SeeOrders()
        {
            Order.SeeOrders();
            Console.WriteLine("Jeżeli chcesz zobaczyć liste zamówień dla konkretnego klienta, wpisz id klienta lub wciśnij enter, jeżeli chesz wyjść");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            int customerId;
            do
            {
                if (int.TryParse(input, out customerId))
                {
                    Customer.SeeCustomerOrders(customerId);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format ID klienta.");
                }
            } while (!int.TryParse(input, out customerId));

        }
        static void ExitProgram()
        {
            Console.WriteLine("Jesteś pewien/ pewna, że chcesz opuścić program? Odpowiedz: tak lub nie");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "tak")
            {
                try
                {
                    Environment.Exit(0);
                }
                catch (SecurityException se)
                {
                    Console.WriteLine(se);
                }
            }
        }
        static void HowMuchProduct()
        {
            string name;
            do
            {
                Console.WriteLine("Podaj nazwe produktu: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));
            Product.HowMuchProduct(name);
        }
        static void ShowCustomerData()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID klienta (lub wciśnij Enter, aby wyjść):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return;
                }
                if (int.TryParse(input, out int id) && id >= 0)
                {
                    Customer.ShowCustomerData(id);
                    return;
                }
                else
                {
                    Console.WriteLine("Niepoprawny format ID klienta. Spróbuj ponownie.");
                }
            }
        }
    }
} 
