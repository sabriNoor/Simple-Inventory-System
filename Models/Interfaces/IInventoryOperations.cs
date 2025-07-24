namespace SimpleInventorySystem.Models.Interfaces;
interface IInventoryOperations
{
    void displayProducts(bool displayOutOfStock = false);
    void addNewProduct(string? name, uint stockCount, decimal price);
    void updateProduct(uint id, string? name, uint? stockCount, decimal? price);
    void deleteProduct(uint id);
    void getProductById(uint id);
}