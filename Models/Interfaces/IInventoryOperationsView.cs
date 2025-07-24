namespace SimpleInventorySystem.Models.Interfaces;
public interface IInventoryOperationsView
{
    void ShowAddNewProduct();
    void ShowUpdateProduct();
    void ShowDeleteProduct();
    void ShowDisplayProductById();
    void ShowDisplayAllProducts(bool displayOutOfStock = false);
}