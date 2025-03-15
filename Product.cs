using System.Diagnostics.CodeAnalysis;

class Product
{
    public string Name { get; set; }

    public static List<Product> boughtProducts = new List<Product>();
    public Product(string name)
    {
        this.Name = name;
    }
    public static void AddProduct(Product product)
    {
        boughtProducts.Add(product);
    }
    public static void HowMuchProduct(string name)
    {
        int count = boughtProducts.Count(p => p.Name== name);
        int sum = boughtProducts.Count();
        if (count == 0)
        {
            Console.WriteLine("Nie kupiono tego produktu");
            return;
        }
        if (sum == 0)
        {
            Console.WriteLine("Brak produktów w bazie");
            return;
        }
        else if (count == 1)
        {
            Console.WriteLine($"Produkt o nazwie: {name} kupiono {count} raz i jest to {(double)count/sum *100}% wszystkich produktów");
        }
        else
        {
            Console.WriteLine($"Produkt o nazwie: {name} kupiono {count} razy i jest to {(double)count / sum * 100}% wszystkich produktów");
        }
    }
}

