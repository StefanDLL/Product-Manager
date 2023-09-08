using Microsoft.Data.SqlClient;
using Product_Manager.Data;
using Product_Manager.Domain;
using static System.Console;

namespace Product_Manager;



class Program
{
    


    //static ApplicationContext context = new ApplicationContext();

    static void Main()
    {
        CursorVisible = false;
        Title = "Product_Manager";

        while (true) // Visa huvudmenyn
        {
            WriteLine("1. Ny produkt");
            WriteLine("2. Sök produkt");
            WriteLine("3. Avsluta");

            var keyPressed = ReadKey(intercept: true);
            Clear();

            switch (keyPressed.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddProduct(); // Anropa funktionen för att lägga till en ny produkt
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    SearchProduct();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Environment.Exit(0);
                    return;
            }

            Clear();
        }
    }

    static void AddProduct()
    {
        while (true)
        {
            Clear();
            WriteLine("Lägg till en ny produkt:");
            WriteLine();

            Write("Namn: ");
            string productName = ReadLine();

            Write("SKU: ");
            string sku = ReadLine();

            Write("Beskrivning: ");
            string description = ReadLine();

            Write("Bild (URL): ");
            string imageUrl = ReadLine();

            Write("Pris: ");
            if (int.TryParse(ReadLine(), out int price))
            {
                using (var context = new ApplicationContext())
                {
                    var product = new Product
                    {
                        Name = productName,
                        SKU = sku,
                        Description = description,
                        ImageUrl = imageUrl,
                        Price = price
                    };

                    context.Product.Add(product);
                    context.SaveChanges();
                }

                Clear();
                WriteLine("Produkt sparad");
                Thread.Sleep(2000);
                break;
            }
            else
            {
                Clear();
                WriteLine("Ogiltig inmatning för pris. Försök igen.");
                Thread.Sleep(2000);
            }
        }
    }

    static void SearchProduct()
    {
        Clear();
        Write("SKU: ");
        string searchSku = ReadLine();

        using (var context = new ApplicationContext())
        {
            var product = context.Product.FirstOrDefault(x => x.SKU == searchSku);

            if (product != null)
            {
                Clear();
                WriteLine($"Namn: {product.Name}");
                WriteLine($"SKU: {product.SKU}");
                WriteLine($"Beskrivning: {product.Description}");
                WriteLine($"Bild (URL): {product.ImageUrl}");
                WriteLine($"Pris: {product.Price}");
                WriteLine();
                WriteLine("(R)adera");
                ConsoleKeyInfo keyInfo = ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.R)
                {
                    context.Product.Remove(product);
                    context.SaveChanges();

                    Clear();
                    WriteLine("Produkt raderad");
                    Thread.Sleep(2000);
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    
                }
            }
            else
            {
                Clear();
                WriteLine("Produkt finns ej");
                Thread.Sleep(2000);
            }
        }
    }
}