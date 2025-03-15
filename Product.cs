using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Product
{
    private int AmountOfMoney { get; set; }
    public string Name { get; set; }

    private static List<Product> boughtProducts = new List<Product>();
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
        if(count == 1)
        {
            Console.WriteLine($"Produktu o nazwie: {name} kupiono {count} raz");
        }
        else
        {
            Console.WriteLine($"Produktu o nazwie: {name} kupiono {count} razy");
        }
    }
}

