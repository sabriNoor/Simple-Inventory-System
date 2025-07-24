namespace SimpleInventorySystem.Models.Interfaces;
interface IInventoryOperations
{
    void DisplayProducts(bool displayOutOfStock = false);
    void AddNewProduct(string name, int stockCount, decimal price);
    void UpdateProduct(uint id, string? name, int? stockCount, decimal? price);
    void DeleteProduct(uint id);
    void GetProductById(uint id);
}