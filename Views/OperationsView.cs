using SimpleInventorySystem.Models.Interfaces;

namespace SimpleInventorySystem.Views;

class OperationsView : IInventoryOperationsView
{
    private IInventoryOperations operations;

    public OperationsView(IInventoryOperations operations)
    {
        this.operations = operations;
    }

    public void ShowAddNewProduct()
    {

        Console.WriteLine("Name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Price: ");
        if (!Decimal.TryParse(Console.ReadLine(), out var price))
        {
            Console.WriteLine("Invalid price input. Please enter a valid decimal number.");
            return;
        }
        Console.WriteLine("Stock Count: ");
        if (!UInt32.TryParse(Console.ReadLine(), out var stockCount))
        {
            Console.WriteLine("Invalid stock count input. Please enter a valid positive integer.");
            return;
        }
        operations.AddNewProduct(name, stockCount, price);
    }

    public void ShowUpdateProduct()
    {
        Console.WriteLine("id#: ");
        if (!UInt32.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid ID input. Please enter a valid positive integer.");
            return;
        }

        Console.WriteLine("New name (or press Enter to keep old): ");
        string? name = Console.ReadLine();
        name = String.IsNullOrWhiteSpace(name) ? null : name;

        Console.WriteLine("New stock count (or press Enter to keep old): ");
        string? stockInput = Console.ReadLine();
        uint? stockCount = null;
        if (!String.IsNullOrWhiteSpace(stockInput) && uint.TryParse(stockInput, out var stock))
        {
            stockCount = stock;
        }

        Console.WriteLine("New price (or press Enter to keep old): ");
        string? priceInput = Console.ReadLine();
        decimal? price = null;
        if (!String.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out var p))
        {
            price = p;
        }

        operations.UpdateProduct(id, name, stockCount, price);

    }

    public void ShowDeleteProduct()
    {
        Console.WriteLine("id#: ");
        if (!UInt32.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid ID input. Please enter a valid positive integer.");
            return;
        }
        operations.DeleteProduct(id);
    }

    public void ShowDisplayProductById()
    {
        Console.WriteLine("id#: ");
        if (!UInt32.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid ID input. Please enter a valid positive integer.");
            return;
        }
        operations.GetProductById(id);
    }
    public void ShowDisplayAllProducts(bool displayOutOfStock = false)
    {
        operations.DisplayProducts(displayOutOfStock);
    }
}