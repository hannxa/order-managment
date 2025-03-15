using Xunit;
public class Tests
{
    [Fact]
    public void ShowCustomerData_Dalid_Id_ShouldDisplayCorrectCustomerInfo()
    {
        var custimer = new Customer("F", "ul. Jasminowa 1") { CustomerId = 1 };
        var writer = new StringWriter();
        Console.SetOut(writer);

        Customer.ShowCustomerData(1);

        var output = writer.ToString();
        Assert.Contains("Id klienta: 1, klient: firma, Adres: ul. Jasminowa 1", output);
    }

    [Fact]
    public void ShowCustomerData_invalidId_ShouldDisplayNotFoundMessage()
    {
        var custimer = new Customer("F", "ul. Jasminowa 1") { CustomerId = 1 };
        var writer = new StringWriter();
        Console.SetOut(writer);

        Customer.ShowCustomerData(100);

        var output = writer.ToString();
        Assert.Contains("Nie znaleziono klienta o ID 100", output);
    }
}
public class ProductTest
{
    [Fact]
    public void HowMuchProduct_ValidProduct_ShouldDisplayCorrectCount()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        Product.boughtProducts = new List<Product>
        {
            new Product("Myszka"),
            new Product("Komputer"),
            new Product("Taśma")
        };

        Product.HowMuchProduct("Myszka");

        var output = writer.ToString();
        Assert.Contains("Produkt o nazwie: Myszka kupiono 1 raz i jest to 100 % wszystkich produktów", output);
    }
}

