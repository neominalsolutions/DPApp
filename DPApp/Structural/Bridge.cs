using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Structural
{

  // Deviceları çalıştırıcak olan kumanda kontrolü
  public interface IRemoteControl
  {
    void Open();
    void Close();

  }

  public interface IDevice
  {
    void On();
    void Off();
  }

  public class SwitchLight : IDevice
  {
    public void Off()
    {
      Console.WriteLine("Işık Kapandı");
    }

    public void On()
    {

      Console.WriteLine("Işık Açıldı");
    }
  }

  public class SmartDoor : IDevice
  {
    public void Off()
    {
      Console.WriteLine("Kapı Kapandı");
    }

    public void On()
    {
      Console.WriteLine("Kapı Açıldı");
    }
  }

  public class SmartRemoteAccess : IRemoteControl
  {
    private IDevice _device;

    public SmartRemoteAccess(IDevice device)
    {
      _device = device;
    }

    public void Close()
    {
      _device.Off();
    }

    public void Open()
    {
      _device.On();
    }
  }



}
