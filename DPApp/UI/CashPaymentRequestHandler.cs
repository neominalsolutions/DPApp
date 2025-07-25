using DPApp.Behavioral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.UI
{
  public class CashPaymentRequestHandler
  {
    private readonly PaymentService _paymentService;

    public CashPaymentRequestHandler(PaymentService paymentService)
    {
      _paymentService = paymentService;
    }

    public void Handle()
    {
      _paymentService.DoPayment("TL", 100);
    }
  }
}
