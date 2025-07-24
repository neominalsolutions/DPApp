using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Cretional
{

  // Factory Method: Bir interface üzerinden birden fazla aynı interfacaden implemente olan sınıfın instance yönetimi sağlar
  public interface ICar
  {
        public string Color { get; set; }
        public int ModelYear { get; set; }
  }

  public class Mercedes : ICar
  {
    public string Color { get; set; }
    public int ModelYear { get; set; }
  }

  public class Bmw : ICar
  {
    public string Color { get; set; }
    public int ModelYear { get; set; }
  }

  public interface ICarFactory
  {
    ICar Create();
  }

  public class BmwCarFactory : ICarFactory
  {
    public ICar Create()
    {
      return new Bmw();
    }
  }

  public class MercedesFactory : ICarFactory
  {
    public ICar Create()
    {
      return new Mercedes();
    }
  }

  public class CarFactory
  {
    public ICar create(string carType)
    {
      if(carType == "mercedes")
      {
        return new Mercedes();
      }
      else if(carType == "bmw")
      {
        return new Bmw();
      }
      else
      {
        return null;
      }
    }
  }

  

}
