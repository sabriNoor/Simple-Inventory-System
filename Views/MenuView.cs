using SimpleInventorySystem.Models.Enums;
using SimpleInventorySystem.Models.Interfaces;
using SimpleInventorySystem.Utils;

namespace SimpleInventorySystem.Views;

class MenuView :IInventoryMenuView
{
    private IInventoryOperationsView operationsView;

    public MenuView(IInventoryOperationsView operationsView)
    {
        Logger.LogInfo("MenuView initialized.");
        this.operationsView = operationsView;
    }

    private void DisplayMenu()
    {
        Console.WriteLine("1. Add New Product");
        Console.WriteLine("2. Update Product");
        Console.WriteLine("3. Remove Product");
        Console.WriteLine("4. Display Product By ID");
        Console.WriteLine("5. Display All Products");
        Console.WriteLine("6. Display Out of Stock Products");
        Console.WriteLine("7. Exit");
    }

    public void ExecuteMenu()
    {
        Logger.LogInfo("User has started the application");
        Console.WriteLine("Welcome Back!");
        try
        {
            while (true)
            {
                DisplayMenu();
                short opt = Convert.ToInt16(Console.ReadLine());
                Option option = (Option)opt;
                if (option == Option.Exit)
                {
                    break;
                }
                switch (option)
                {
                    case Option.Add:
                        operationsView.ShowAddNewProduct();
                        break;
                    case Option.Update:
                        operationsView.ShowUpdateProduct();
                        break;
                    case Option.Remove:
                        operationsView.ShowDeleteProduct();
                        break;
                    case Option.DisplayById:
                        operationsView.ShowDisplayProductById();
                        break;
                    case Option.DisplayAll:
                        operationsView.ShowDisplayAllProducts();
                        break;
                    case Option.DisplayOutOfStock:
                        operationsView.ShowDisplayAllProducts(true);
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Something went wrong, {ex.Message}");
            Console.WriteLine($"Something went wrong, {ex.Message}");

        }
        Logger.LogInfo("User has exited the application");
        Console.WriteLine("Have a Good Day, Bye!");
    }
}