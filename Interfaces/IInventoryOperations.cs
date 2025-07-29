namespace SimpleInventorySystem.Interfaces;
interface IInventoryOperations
{
    void DisplayProducts(bool displayOutOfStock = false);
    bool AddNewProduct(string name, int stockCount, decimal price);
    bool UpdateProduct(uint id, string? name, int? stockCount, decimal? price);
    bool DeleteProduct(uint id);
    void DisplayProductById(uint id);
}