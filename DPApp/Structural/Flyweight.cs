using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Structural
{

  // Bizim farklı özelliklerde oyun için asker üretmemiz lazım
  // ama bu asker sınıfından üretilen askerlerin bazı özellikler ortak değişmiyor bazıları değişir
  // power -> güç, healt -> sağlık durumu -> dışarıdan gelen değerler method için parametre olarak gönderilir
  // type -> süvari, atlı, okçu -> bu değerler için sınıftan tekrar instance almak gerekir.
  // icon -> karakter resmi 
  public interface ISoldier
  {
    public string Type { get; init; }
    public string Icon { get; init; } // değişkenlik göstermeye değerler

    double Damage(int Power, int Healt); // dışarıdan gönderilen değerler -> bu değerler değişkenlik gösterir. 
  }

  public class Soldier : ISoldier
  {
    public string Type { get; init; }
    public string Icon { get; init; }

    public Soldier(string type, string icon)
    {
      Type = type;
      Icon = icon;
    }

    public double Damage(int Power, int Healt)
    {
      return Power * (Healt / 10); // Hasar Puanı
    }
  }

  // aynı tipde olan nesne instancelarını bu factory üzerindne üretiyoruz
  // iç nesne özelliklerini instance ayarlaması yapan sınıf
  public class SoldierFactory
  {
    // instance yöentimi
    private Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

    public IImmutableDictionary<string, ISoldier> Soldiers => soldiers.ToImmutableDictionary<string,ISoldier>();


    public ISoldier create(string type, string icon)
    {
      if (!soldiers.ContainsKey(type))
      {
        soldiers.Add(type, new Soldier(type, icon));
        return soldiers[type];
      }
      else
      {
        return soldiers[type];
      }
    }


  }


  public class Game
  {

    private SoldierFactory sf = new SoldierFactory();

    public void CreateSuvari(int count)
    {
      Random rdm = new Random();

      for (int i = 0; i < count; i++)
      {
       
        ISoldier s = sf.create("süvari", "svc-1");
        Console.WriteLine($"{i + 1} {s.Type}");
        Console.WriteLine("Damage " + s.Damage(rdm.Next(1,100), rdm.Next(20,35)));

      }


    }

    public void CreateAtli(int count)
    {
      Random rdm = new Random();

      for (int i = 0; i < count; i++)
      {

        ISoldier s = sf.create("atli", "svc-2");
        Console.WriteLine($"{i + 1} {s.Type}");
        Console.WriteLine("Damage " + s.Damage(rdm.Next(1, 100), rdm.Next(20, 35)));

      }
    }

    public void CreateOkcu(int count)
    {
      Random rdm = new Random();

      for (int i = 0; i < count; i++)
      {

        int power = rdm.Next(1, 100);
        int health = rdm.Next(20, 35);

        ISoldier s = sf.create("okcu", "svc-3");
        Console.WriteLine($"{i + 1} {s.Type}");
        Console.WriteLine("Damage " + s.Damage(power, health));

      }
    }

    public int GetSoldierInstanceCount => sf.Soldiers.Count();

  }


}
