using SimpleInventorySystem.Services;
using SimpleInventorySystem.Models.Interfaces;
using SimpleInventorySystem.Views;
class Program
{
    public static void Main()
    {
        IInventoryOperations inventoryOperations = new Operations();
        IInventoryOperationsView inventoryOperationsView = new OperationsView(inventoryOperations);
        IInventoryMenuView menuView = new MenuView(inventoryOperationsView);
        menuView.ExecuteMenu();

    }


}