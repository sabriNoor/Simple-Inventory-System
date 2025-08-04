using SimpleInventorySystem.Services;
using SimpleInventorySystem.Interfaces;
using SimpleInventorySystem.Views;
using SimpleInventorySystem.Utils;
using SimpleInventorySystem.Models;
public class Program
{
    public static void Main()
    {
        try
        {
            Logger.LogInfo("Application started.");
            IFileService<Product> fileService = new FileService<Product>("products.json");
            IInventoryOperations inventoryOperations = new Operations(fileService);
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