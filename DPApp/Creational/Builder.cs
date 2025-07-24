using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Creational
{
  // Builder tasarım deseni bir nesnenin farklı varyasyonlar ile üretilmesini sağlar
  public interface IBuilder<T> where T : class // code defensing
  {
    T Build(); // Build methodu ile Nesnenin kendi referansını döndür
  }

  public class Product
  {
    public string? Name { get; init; } // code defensing
    public decimal Price { get; init; }

    public Product(string? name,decimal price)
    {
      Name = name;
      Price = price;
    }

  }

  public class ProductBuilder : IBuilder<Product>
  {
    private string? _name;
    private decimal _price;
    public Product Build()
    {
      return new Product(_name, _price);
    }

    public ProductBuilder SetName(string? name)
    {
      ArgumentException.ThrowIfNullOrWhiteSpace(name);
      _name = name;
      return this;
    }

    public ProductBuilder SetPrice(decimal price)
    {
      ArgumentOutOfRangeException.ThrowIfNegativeOrZero<decimal>(price);
      _price = price;
      return this;
    }
  }


}
