using SimpleInventorySystem.Models;

namespace SimpleInventorySystem.Utils.Validation;

public class ProductValidator
{
    public static bool ValidateForAdd(Product? product,out string? error)
    {
        if (product == null)
        {
            error = "Product cannot be null.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            error = "Product name cannot be empty.";
            return false;
        }

        if (product.StockCount < 0)
        {
            error = "Stock count cannot be negative.";
            return false;
        }

        if (product.Price < 0)
        {
            error = "Price cannot be negative.";
            return false;
        }
        error = null;

        return true;
    }
    
     public static bool ValidateForUpdate(string? name, int? stockCount, decimal? price, out string? error)
    {
        if (name != null && string.IsNullOrWhiteSpace(name))
        {
            error = "Product name cannot be empty when provided.";
            return false;
        }

        if (stockCount != null && stockCount < 0)
        {
            error = "Stock count cannot be negative.";
            return false;
        }

        if (price != null && price < 0)
        {
            error = "Price cannot be negative.";
            return false;
        }

        error = null;
        return true;
    }
}