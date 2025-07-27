using SimpleInventorySystem.Models.Interfaces;
using SimpleInventorySystem.Utils.Validation;
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
        var nameResult = Validator.ReadNonEmptyString("Enter product name: ");
        if (!CheckValidation(nameResult, out var name))
            return;

        var stockCountResult = Validator.ReadInt("Enter stock count: ");
        if (!CheckValidation(stockCountResult, out var stockCount))
            return;

        var priceResult = Validator.ReadDecimal("Enter price: ");
        if (!CheckValidation(priceResult, out var price))
            return;

        operations.AddNewProduct(name, stockCount, price);

    }

    public void ShowUpdateProduct()
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

        operations.UpdateProduct(id, name, stockCount, price);

    }

    public void ShowDeleteProduct()
    {
        var idResult = Validator.ReadUInt("Enter product ID to delete: ");
        if (!CheckValidation(idResult, out var id))
            return;

        operations.DeleteProduct(id);
    }

    public void ShowDisplayProductById()
    {
        var idResult = Validator.ReadUInt("Enter product ID: ");
        if (!CheckValidation(idResult, out var id))
            return;
        operations.GetProductById(id);
    }
    public void ShowDisplayAllProducts(bool displayOutOfStock = false)
    {
        operations.DisplayProducts(displayOutOfStock);
    }
    private bool CheckValidation<T>(ValidationResult<T> result, out T value)
    {
        if (!result.IsValid)
        {
            Console.WriteLine(result.ErrorMessage);
            value = default!;
            return false;
        }
        value = result.Value!;
        return true;
    }

}