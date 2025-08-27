namespace SimpleInventorySystem.Models;
public class Product
{
    public uint Id{get;set;}

    public string Name{get;set;}

    public int StockCount{get;set; }

    public decimal Price{ get;set;  }

    public Product(uint id, string name, int stockCount, decimal price)
    {
        Id = id;
        Name = name;
        StockCount = stockCount;
        Price = price;
    }

    public override string ToString()
    {
        return $"id#: {Id}, name: {Name}, price: {Price:c}, stock count: {StockCount}";
    }
}
