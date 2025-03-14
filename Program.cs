using System.Collections.Specialized;
using System.Reflection.Metadata;

class Program
{
    static void displayWindow()
    {
        Console.Clear();
        for (int j = 0; j < 42; j++)
        {
            Console.Write("*");
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(" ");
            Console.Write("*");
            for (int j = 0; j < 40; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
            Console.WriteLine(" ");
        }
        for (int j = 0; j < 42; j++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
    
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
        Console.WriteLine("4. wyświetl liste zamówień");
        Console.WriteLine("4. Wyjście");
        Console.WriteLine("Wybierz numer:");
        string userInput = Console.ReadLine();

        int menuNumber;

        if (int.TryParse(userInput, out menuNumber))
        {
            if (menuNumber == 1)
            {
                Order order = new Order("Laptop", 9,"ss", "xx","xx");
                order.MakeOrder();
                
            }else if(menuNumber == 2)
            {
                Console.WriteLine("Podaj ID zamówienia do przeniesienia do magazynu:");
                int id = int.Parse(Console.ReadLine());
                Order.MoveOrderToMagazine(id);
            }
            else if (menuNumber == 3)
            {
                Console.WriteLine("Podaj ID zamówienia do przeniesienia do wysyłki:");
                int id = int.Parse(Console.ReadLine());
                Order.MoveOrderToShipment(id);
            }
            else if (menuNumber == 4)
            {
                Order.SeeOrders();
            }
            Console.WriteLine("Nacisnij dowolny klawisz, aby wrócić do menu");
            Console.ReadKey();
        }
    }
    static void Main()
    {
        while (true)
        {
            displayWindow();
            menu();
        }
    }
}
