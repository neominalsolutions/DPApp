using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Behavioral
{
  public interface IHandler<T>
  {
    IHandler<T> NextHandler(IHandler<T> handler); // isteği bir sonraki sürece bağla
    void Handle(T request); // süreci işlet en son adım
  }


  public abstract class AbstractHandler<T> : IHandler<T>
  {
    private IHandler<T> _nextHandler;
    
    public virtual void Handle(T request)
    {
      if(_nextHandler != null)
      {
        _nextHandler.Handle(request);
      }
    }

    public IHandler<T> NextHandler(IHandler<T> handler)
    {
      _nextHandler = handler;
      return _nextHandler;
    }
  }

  public class HandlerRequest { }
  public class AHandler: AbstractHandler<HandlerRequest>
  {
    public override void Handle(HandlerRequest request)
    {
      Console.WriteLine("A işlemi algoritması 1.adım");

      base.Handle(request);
    }

  }

  public class BHandler : AbstractHandler<HandlerRequest>
  {
    public override void Handle(HandlerRequest request)
    {
      Console.WriteLine("B işlemi algoritması 2.adım");

      base.Handle(request);
    }

  }

  public class CHandler : AbstractHandler<HandlerRequest>
  {
    public override void Handle(HandlerRequest request)
    {
      Console.WriteLine("C işlemi algoritması 2.adım");

      base.Handle(request);
    }

  }
}
