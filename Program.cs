using SimpleInventorySystem.Services;
using SimpleInventorySystem.Models.Interfaces;
using SimpleInventorySystem.Views;
using SimpleInventorySystem.Utils;
public class Program
{
    public static void Main()
    {
        try
        {
            Logger.LogInfo("Application started.");
            IInventoryOperations inventoryOperations = new Operations();
            IInventoryOperationsView inventoryOperationsView = new OperationsView(inventoryOperations);
            IInventoryMenuView menuView = new MenuView(inventoryOperationsView);
            menuView.ExecuteMenu();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing logger: {ex.Message}");
            Logger.LogError($"Error initializing logger: {ex.Message}");
            return;
        }

    }


}