namespace SimpleInventorySys.Services;

using System.Text.Json;
using SimpleInventorySys.Models.Interfaces;
using SimpleInventorySys.Models;
class Operations : IInventoryOperations
{
    private List<Product> products;
    private const string FileName = "products.json";
    private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), FileName);
    private const string format = "{0,-5} {1,-20} {2,-15} {3,-10}";

    public Operations()
    {
        products = new List<Product>();
        Console.WriteLine("Path: " + filePath);
        readFile();
    }

    public void addNewProduct(string? name, uint stockCount, decimal price)
    {
        try
        {
            Product product = new Product(name, stockCount, price);
            products.Add(product);
            writeOnFile();
            Console.WriteLine("Product added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add new product. {ex.Message}");
        }
    }

    public void deleteProduct(uint id)
    {
        try
        {
            // products.Remove(products.Where(p => p.Id == id).Single());

            Product? product = searchProduct(id);
            if (product == null)
            {
                Console.WriteLine("Failed to delete, Product Not Found!!");
                return;
            }

            products.Remove(product);
            writeOnFile();
            Console.WriteLine("Product deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete the product with id {id}. {ex.Message}");
        }

    }

    public void updateProduct(uint id, string? name, uint? stockCount, decimal? price)
    {
        try
        {
            Product? product = searchProduct(id);
            if (product == null)
            {
                Console.WriteLine("Failed to update; product Not Found!!");
                return;
            }

            if (!String.IsNullOrEmpty(name))
                product.Name = name;
            if (stockCount != null)
                product.StockCount = (uint)stockCount;
            if (price != null)
                product.Price = (decimal)price;

            writeOnFile();
            Console.WriteLine("Product updated successfully!");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to update the product. {ex.Message}");
        }

    }

    public void displayProducts(bool displayOutOfStock=false)
    {
        List<Product> products = displayOutOfStock ? 
            this.products.Where(p => p.StockCount == 0).ToList() : 
            this.products;
        Console.WriteLine("Produts: ");
        Console.WriteLine(format, "Id#", "Name", "Stock Count", "Price");
        products.ToList().ForEach(p => Console.WriteLine(format, $"{p.Id}", p.Name, $"{p.StockCount}", $"{p.Price}"));
        Console.WriteLine();
        Console.WriteLine($"Count: {products.Count}");
    }

    public void getProductById(uint id)
    {
        Product? product = searchProduct(id);
        if (product != null)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    private Product? searchProduct(uint id)
    {
        foreach (Product p in products)
        {
            if (p.Id == id)
            {
                return p;
            }
        }
        return null;
    }

    private void readFile()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {FileName} not found. Starting with empty product list.");
                return;
            }

            string json = File.ReadAllText(filePath);
            products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read the JSON file {FileName}. {ex.Message}");
        }
    }

    private void writeOnFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write to the JSON file {FileName}. {ex.Message}");
        }
    }

   
}
