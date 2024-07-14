namespace Native.Application.ViewModels;
public class SneakerDetailsViewModel(int id, string name, string brand, decimal price, int size, int year)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Brand { get; private set; } = brand;
    public decimal Price { get; private set; } = price;
    public int Size { get; private set; } = size;
    public int Year { get; private set; } = year;
}