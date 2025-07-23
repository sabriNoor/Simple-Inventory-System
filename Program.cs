class Program
{
    public static void Main()
    {
        try
        {
            Operations operations = new Operations();
            Console.WriteLine("Wellcome Back!");
            while (true)
            {
                Console.WriteLine("Menue Operations:");
                Console.WriteLine("1- Display products.");
                Console.WriteLine("2- Add new product.");
                Console.WriteLine("3- Update a product.");
                Console.WriteLine("4- Delete a product.");
                Console.WriteLine("5- Display a product by id.");
                Console.WriteLine("6- Display out of stock products.");
                Console.WriteLine("7- Exit.");
                Console.WriteLine("Enter your option:");
                short opt = Convert.ToInt16(Console.ReadLine());
                if (opt == 7)
                {
                    break;
                }
                switch (opt)
                {
                    case 1:
                        {
                            operations.displayProducts();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Name: ");
                            var name = Console.ReadLine();
                            Console.WriteLine("Price: ");
                            if (!Decimal.TryParse(Console.ReadLine(), out var price))
                            {
                                Console.WriteLine("Invalid price input. Please enter a valid decimal number.");
                                continue;
                            }
                            ;
                            Console.WriteLine("Stock Count: ");
                            if (!UInt32.TryParse(Console.ReadLine(), out var stockCount))
                            {
                                Console.WriteLine("Invalid stock count input. Please enter a valid positive integer.");
                                continue;
                            }
                            operations.addNewProduct(name, stockCount, price);

                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("id#: ");
                            if (!UInt32.TryParse(Console.ReadLine(), out var id))
                            {
                                Console.WriteLine("Invalid ID input. Please enter a valid positive integer.");
                                continue;
                            }

                            Console.WriteLine("New name (or press Enter to keep old): ");
                            string? name = Console.ReadLine();
                            name = String.IsNullOrWhiteSpace(name) ? null : name;

                            Console.WriteLine("New stock count (or press Enter to keep old): ");
                            string? stockInput = Console.ReadLine();
                            uint? stockCount = null;
                            if (!String.IsNullOrWhiteSpace(stockInput) && uint.TryParse(stockInput, out var stock))
                            {
                                stockCount = stock;
                            }

                            Console.WriteLine("New price (or press Enter to keep old): ");
                            string? priceInput = Console.ReadLine();
                            decimal? price = null;
                            if (!String.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out var p))
                            {
                                price = p;
                            }

                            operations.updateProduct(id, name, stockCount, price);
                            break;

                        }
                    case 4:
                        {
                            Console.WriteLine("id#: ");
                            if (!UInt32.TryParse(Console.ReadLine(), out var id))
                            {
                                Console.WriteLine("Invalid ID input. Please enter a valid positive integer.");
                                continue;
                            }
                            operations.deleteProduct(id);
                            break;
                        }
                        case 5:
                        {
                            Console.WriteLine("id#: ");
                            if (!UInt32.TryParse(Console.ReadLine(), out var id))
                            {
                                Console.WriteLine("Invalid ID input. Please enter a valid positive integer.");
                                continue;
                            }
                            operations.getProductById(id);
                            break;
                        }
                        case 6:
                        {
                            operations.displayProducts(true);
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Have a Good Day, Bye!");

    }


}