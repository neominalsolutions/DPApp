using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Behavioral
{
  // Senaryo -> Sekil Sınıfımız var ama alan hesaplamıyı başka bir sınıf üzerinden yapıcaz. 

  public interface IVisitor
  {
    void Visit(Rect visitor);
  }

  public class RectAreaCalculatorVisitor : IVisitor
  {
    public void Visit(Rect visitor)
    {
      Console.WriteLine($"Alan : {visitor.CornerOne * visitor.CornerTwo}");
    }
  }

  public class RectAreaPerimeterVisitor : IVisitor
  {
    public void Visit(Rect visitor)
    {
      Console.WriteLine($"Çevre : {2* (visitor.CornerOne + visitor.CornerTwo)}");
    }
  }

  public interface IShape
  {
    void Accept(IVisitor visitor);
  }

  // double dispatch pattern
  public class Rect : IShape
  {
    public int CornerOne { get; set; }
    public int CornerTwo { get; set; }

    public void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
    }
  }




}
