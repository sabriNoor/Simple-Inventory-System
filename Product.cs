class Product
{
    private readonly uint id;
    private string? name;
    private uint stockCount;
    private decimal price;
    private static uint idC = 0;

    public uint Id => id;

    public string? Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(Name));
            name = value;
        }
    }

    public uint StockCount
    {
        get => stockCount;
        set => stockCount = value;
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be a positive value.");
            price = value;
        }
    }

    public Product(string? name, uint stockCount, decimal price)
    {
        id = idC++;
        Name = name;
        StockCount = stockCount;
        Price = price;
    }


    public void DecrementStockCount()
    {
        if (StockCount > 0)
        {
            StockCount--;
        }
        else
        {
            Console.WriteLine("Sorry, stock count is zero!");
        }
    }

    public override string ToString()
    {
        return $"id#: {id}, name: {Name}, price: {price:c}, stock count: {stockCount}";
    }
}
