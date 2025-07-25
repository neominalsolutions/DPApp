using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Structural
{
  // birbirileri ile uyumusuz sistemlerin birbirlerin uyumlu hale getirilmesini sağlayan bir pattern
  // senaryo -> XML SOAP servisden gelen verilerin API Restfullservislerde kullanılması lazım. Bu durumda Controller üzerinden direk soap servislerini tetiklersek, Controllerda SVC dosyalarının referansları olucak. Eğer bir gün var olan SOAP service yerine farklı bir SOAP servis kullanamız gerekirse bütün controllerdaki SOAP service veri çekme noktaları değiştirilmek refactor edilmek zorunda kalacak. 

  // SMS paketleri değişebilir bu sebep ile bir adapter tasarladık

  public class SmsObject
  {
    string PhoneNumber { get; set; }
    string AreaCode { get; set; }
    string Message { get; set; }
  }

  // 3rd Service
  public class TurkcellSmsService
  {
    public void Send(SmsObject smsObject)
    {
      Console.WriteLine("Türkcell SMS iletildi");
    }
  }

  // 3rd Service
  public class VodaPhoneSmsService
  {
    public void Send(string phone, string message)
    {
      Console.WriteLine("VodaPhone SMS iletildi");
    }
  }

  // Bu Tarz servisler adapter kullanılmadığından refactor edilecek
  public class OrderService
  {
    //private TurkcellSmsService smsService = new TurkcellSmsService();

    private ISmsAdapter _smsAdapter;

    public OrderService(ISmsAdapter smsAdapter)
    {
      _smsAdapter = smsAdapter;
    }


    public void SubmitOrder()
    {
      //smsService.Send(new SmsObject());
      _smsAdapter.SendSms("58787","sdasd");
    }
  }


  public interface ISmsAdapter
  {
    void SendSms(string phoneNumber, string message);
  }

  public class SmsAdapter : ISmsAdapter
  {
    //private TurkcellSmsService smsService = new TurkcellSmsService();
    private VodaPhoneSmsService vodaPhoneSms = new VodaPhoneSmsService();


    public void SendSms(string phoneNumber, string message)
    {
      //smsService.Send(new SmsObject());
      vodaPhoneSms.Send(phoneNumber, message);
    }
  }
}
