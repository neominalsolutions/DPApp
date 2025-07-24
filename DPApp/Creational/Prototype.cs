using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Creational
{
  // Net Version

  public class Address
  {
    public string? Text { get; set; }

  }

  public class Customer : ICloneable
  {
    public string? Name { get; set; }
    public Address Adddres { get;set; }

    public object Clone()
    {
      return (Customer)MemberwiseClone();
    }
  }

  public interface IClonable<T> where T : class
  {
    T Clone();
  }

  public class Employee : IClonable<Employee>
  {
    public string Name { get; set; }
    public Address Address { get; set; }
    public Employee Clone()
    {
      var emp = new Employee();
      emp.Address = this.Address;
      emp.Name = Name;
      return emp;
    }

  }

  public class PrototypeRegister<T> where T:class {

    private IDictionary<string, IClonable<T>> map = new Dictionary<string, IClonable<T>>();

    public IClonable<T> Clone(string key)
    {
      if (map.ContainsKey(key))
        return map[key];

      return null;
    }

    public void Register(string key, IClonable<T> value) { 
    
      if(!map.ContainsKey(key))
        ArgumentException.ReferenceEquals(map[key], value);
      
      map.Add(key, value);

    }

   

  
  }


}
