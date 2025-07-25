using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Behavioral
{

  // StartegyInterface

  public record Money(decimal amount, string currency); // 100 $ 100 TL

  public interface IPayment
  {
    void Pay(Money money);
  }

  // ilk strategy
  public class CashPayment : IPayment
  {
    public void Pay(Money money)
    {
      Console.WriteLine("Cash ödeme");
    }
  }

  // otomatik ödeme talimatı
  public class AutoPaymentInstruction : IPayment
  {
    public void Pay(Money money)
    {
      Console.WriteLine("AutoInstruction ödeme");
    }
  }


  public class PaymentService
  {
    private readonly IPayment _payment;
    public PaymentService(IPayment payment)
    {
      _payment = payment;
    }

    public void DoPayment(string currency, decimal amount)
    {
      _payment.Pay(new Money(amount, currency));
    }

  }


}
