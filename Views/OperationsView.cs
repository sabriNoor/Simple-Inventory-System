using SimpleInventorySystem.Interfaces;
using SimpleInventorySystem.Utils;
using SimpleInventorySystem.Utils.Validation;
namespace SimpleInventorySystem.Views;

class OperationsView : IInventoryOperationsView
{
    private readonly IInventoryOperations operations;

    public OperationsView(IInventoryOperations operations)
    {
        this.operations = operations;
        Logger.LogInfo("OperationsView initialized.");
    }

    public void RenderAddNewProduct()
    {
        var nameResult = Validator.ReadNonEmptyString("Enter product name: ");
        if (!CheckValidation(nameResult, out var name))
            return;

        var stockCountResult = Validator.ReadInt("Enter stock count: ");
        if (!CheckValidation(stockCountResult, out var stockCount))
            return;

        var priceResult = Validator.ReadDecimal("Enter price: ");
        if (!CheckValidation(priceResult, out var price))
            return;

        if (operations.AddNewProduct(name??String.Empty, stockCount, price))
        {
            Console.WriteLine("Product added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to add product. Please check the details and try again.");
        }
        ;

    }

    public void RenderUpdateProduct()
    {
        var idResult = Validator.ReadUInt("Enter product ID: ");
        if (!CheckValidation(idResult, out var id))
            return;
        var nameResult = Validator.ReadOptionalString("Enter new product name (or press Enter to keep old): ");
        if (!CheckValidation(nameResult, out var name))
            return;
        var stockCountResult = Validator.ReadOptionalInt("Enter new stock count (or press Enter to keep old): ");
        if (!CheckValidation(stockCountResult, out var stockCount))
            return;
        var priceResult = Validator.ReadOptionalDecimal("Enter new price (or press Enter to keep old): ");
        if (!CheckValidation(priceResult, out var price))
            return;

        if (operations.UpdateProduct(id, name, stockCount, price))
        {
            Console.WriteLine("Product updated successfully!");
        }
        else
        {
            Console.WriteLine("Failed to update product. Please check the details and try again.");
        }
        
    }

    public void RenderDeleteProduct()
    {
        var idResult = Validator.ReadUInt("Enter product ID to delete: ");
        if (!CheckValidation(idResult, out var id))
            return;

        if (operations.DeleteProduct(id))
        {
            Console.WriteLine("Product deleted successfully!");
        }
        else
        {
            Console.WriteLine("Failed to delete product. Please check the ID and try again.");
        }
    }

    public void RenderDisplayProductById()
    {
        var idResult = Validator.ReadUInt("Enter product ID: ");
        if (!CheckValidation(idResult, out var id))
            return;
        operations.DisplayProductById(id);
    }
    public void RenderDisplayAllProducts(bool displayOutOfStock = false)
    {
        operations.DisplayProducts(displayOutOfStock);
    }
    private bool CheckValidation<T>(ValidationResult<T> result, out T? value)
    {
        if (!result.IsValid)
        {
            Console.WriteLine(result.ErrorMessage);
            Logger.LogError(result.ErrorMessage?? "Validation failed.");
            value = default;
            return false;
        }
        value = result.Value;
        return true;
    }

}