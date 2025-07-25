using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Behavioral
{
  // dinleyici kendini gözlemciye göre günceller
  public interface ISubcriber
  {
    void Update(IPublisher publisher);
  }

  public class Subscriber1 : ISubcriber
  {
    public void Update(IPublisher publisher)
    {
      Console.WriteLine("1. Gözlemci Değişikliği dinledi");
    }
  }

  public class Subscriber2 : ISubcriber
  {
    public void Update(IPublisher publisher)
    {
      Console.WriteLine("2. Gözlemci Değişikliği dinledi");
    }
  }

  // bildirim atar gözlemcilere
  public interface IPublisher
  {
    void Notify();
  }



  //Bildirim fırlatıcak olan sınıf
  public class Publisher : IPublisher
  {
    private List<ISubcriber> _subscribers = new List<ISubcriber>(); // gözlemciler


    public void Register(ISubcriber subcriber)
    {
      _subscribers.Add(subcriber);
    }

    // artık bizi dinlemiyor
    public void Remove(ISubcriber subcriber)
    {
      _subscribers.Remove(subcriber);
    }

    public void Notify()
    {
      // bende birşeyler değişti o zaman tüm subscriberler bunu bilmeli
      foreach (var item in _subscribers)
      {
        item.Update(this);
      }
    }
  }

}
