using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Structural
{
  // Bir sınıfa ait olan methodun yeni özellikler kazanarak var olan özelliğini değiştirebilmesini sağlar.
  public interface IInvoiceDecorator
  {
    decimal Calculate();
  }


  public class Invoice : IInvoiceDecorator
  {
    public decimal Calculate()
    {
      // fatura hesaplama algoritması çalışıyor
      return 100;
    }
  }

  public abstract class InvoiceDecoratorAbstract : IInvoiceDecorator
  {
    protected IInvoiceDecorator _decorator;

    public InvoiceDecoratorAbstract(IInvoiceDecorator decorator)
    {
      this._decorator = decorator;
    }

    public virtual decimal Calculate()
    {
      return _decorator.Calculate();
    }
  }



  // Artık bu hesaplama algoritması -> faturayı hesaplarken hesaplamaya % 3 oranında vergi dahil etsin
  public class InvoiceDecorator : InvoiceDecoratorAbstract
  {
    public InvoiceDecorator(IInvoiceDecorator decorator) : base(decorator)
    {
    }

    public override decimal Calculate()
    {
      return base.Calculate() * 1.3M;
    }


  }


  public class ElectricInvoiceDecorator : InvoiceDecoratorAbstract
  {
    public int energyConsumptionCost { get; set; }

    public ElectricInvoiceDecorator(IInvoiceDecorator decorator) : base(decorator)
    {
    }

    public override decimal Calculate()
    {
      return base.Calculate() + energyConsumptionCost;
    }
  }
}
