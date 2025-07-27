namespace SimpleInventorySystem.Models.Interfaces;
public interface IInventoryOperationsView
{
    void RenderAddNewProduct();
    void RenderUpdateProduct();
    void RenderDeleteProduct();
    void RenderDisplayProductById();
    void RenderDisplayAllProducts(bool displayOutOfStock = false);
}