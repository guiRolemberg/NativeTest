namespace Native.Core.Entities;
public class Sneaker(int idUser, string name, string brand, decimal price, int size, int year, int rate)
    : BaseEntity
{
    public int IdUser { get; private set; } = idUser;
    public User User { get; private set; }
    public string Name { get; private set; } = name;
    public string Brand { get; private set; } = brand;
    public decimal Price { get; private set; } = price;
    public int Size { get; private set; } = size;
    public int Year { get; private set; } = year;
    public int Rate { get; set; } = rate;

    public void Update(string name, string brand, decimal price, int size, int year, int rate)
    {
        Name = name;
        Brand = brand;
        Price = price;
        Size = size;
        Year = year;
        Rate = rate;
    }    
}