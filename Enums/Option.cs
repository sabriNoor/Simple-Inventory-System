namespace SimpleInventorySystem.Enums;
public enum Option
{
    /// <summary> Represents no option selected or default state. </summary>
    None = 0,
    /// <summary> Represents the option to add a new product. </summary>
    Add = 1,
    /// <summary> Represents the option to update an existing product. </summary>
    Update = 2,
    /// <summary> Represents the option to remove a product. </summary>
    Remove = 3,
    /// <summary> Represents the option to display a product by its ID. </summary>
    DisplayById = 4,
    /// <summary> Represents the option to display all products. </summary>
    DisplayAll = 5,
    /// <summary> Represents the option to display products that are out of stock. </summary>
    DisplayOutOfStock = 6,
    /// <summary> Represents the option to exit the application. </summary>
    Exit = 7

}