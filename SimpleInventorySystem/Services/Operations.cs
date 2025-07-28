namespace SimpleInventorySystem.Services;

using System.Text.Json;
using SimpleInventorySystem.Interfaces;
using SimpleInventorySystem.Models;
using SimpleInventorySystem.Utils.Validation;
using SimpleInventorySystem.Utils;


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
        Logger.LogInfo($"Operations initialized.");
        ReadFile();
    }

    public bool AddNewProduct(string name, int stockCount, decimal price)
    {
        try
        {
            uint id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            Product product = new Product(id, name, stockCount, price);
            if (!ProductValidator.ValidateForAdd(product, out var error))
            {
                Logger.LogError($"Invalid product details: {error}");
                Logger.LogInfo("Product not added due to validation failure.");
                return false;
            }
            products.Add(product);
            WriteOnFile();
            Logger.LogInfo($"Product added: {product}");
            return true;

        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to add new product: {ex.Message}");
            return false;
        }
    }

    public bool DeleteProduct(uint id)
    {
        try
        {
            Product product = GetExistingProduct(id);
            products.Remove(product);
            WriteOnFile();
            Logger.LogInfo($"Product deleted: {product}");
            return true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to delete product with id {id}: {ex.Message}");
            return false;
        }

    }

    public bool UpdateProduct(uint id, string? name, int? stockCount, decimal? price)
    {
        try
        {
            Product product = GetExistingProduct(id);
            Logger.LogInfo($"Updating product: {product}");
            if (!ProductValidator.ValidateForUpdate(name, stockCount, price, out var error))
            {
                Logger.LogError($"Invalid product details: {error}");
                Logger.LogInfo("Product not updated due to validation failure.");
                return false;
            }


            if (name != null) product.Name = name;
            if (stockCount != null) product.StockCount = stockCount.Value;
            if (price != null) product.Price = price.Value;

            WriteOnFile();
            Logger.LogInfo($"Product updated: {product}");
            return true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to update product with id {id}: {ex.Message}");
            return false;
        }
    }


    public void DisplayProducts(bool displayOutOfStock = false)
    {
        List<Product> filtered  = displayOutOfStock ? products.Where(p => p.StockCount == 0).ToList() :products;
        Console.WriteLine("Products: ");
        Console.WriteLine(format, "Id#", "Name", "Stock Count", "Price");
        foreach (var product in filtered)
        {
            Console.WriteLine(format, $"{product.Id}", product.Name, $"{product.StockCount}", $"{product.Price}");
        }
        Console.WriteLine();
        Console.WriteLine($"Count: {filtered.Count}");
        Logger.LogInfo($"Displayed {filtered.Count} {(displayOutOfStock ? "out of stock" : "")} product(s).");
    }


    public void DisplayProductById(uint id)
    {
        try
        {
            Product product = GetExistingProduct(id);
            Console.WriteLine("Product found:");
            Console.WriteLine(product);
            Logger.LogInfo($"Product retrieved: {product}");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to get the product with id {id}: {ex.Message}");
            Console.WriteLine($"Failed to get the product with id {id}. {ex.Message}");
            return;
        }

    }

    private Product? SearchProduct(uint id)=>
        products.FirstOrDefault(p => p.Id == id);

    private void ReadFile()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {FileName} not found. Starting with empty product list.");
                Logger.LogWarning($"File {FileName} not found. Starting with empty product list.");
                return;
            }

            string json = File.ReadAllText(filePath);
            products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            Logger.LogInfo($"Products read from {FileName} successfully.");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to read the JSON file {FileName}: {ex.Message}");
            Console.WriteLine($"Failed to read the JSON file {FileName}. {ex.Message}");
        }
    }

    private void WriteOnFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, json);
            Logger.LogInfo($"Products written to {FileName} successfully.");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to write to the JSON file {FileName}: {ex.Message}");
            Console.WriteLine($"Failed to write to the JSON file {FileName}. {ex.Message}");
        }
    }

    private Product GetExistingProduct(uint id)
    {
        Product? product = SearchProduct(id);

        if (product == null)
        {
            throw new Exception($"Product with ID {id} does not exist.");
        }
        return product;

    }


}
