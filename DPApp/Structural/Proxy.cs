using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Structural
{
  public interface IProxy
  {
    void Execute();
  }

  public class RealService
  {
    public void HandleRequest()
    {

    }
  }

  // Not:Proxy ile alakalı değil sadece Proxy için çağırılacak olan bir servis. İşlem loglama yapar
  public interface ILogger
  {
    void Log();
  }

  public class TextLogger : ILogger
  {
    public void Log()
    {
      Console.WriteLine("Log Request");
    }
  }

  public class RealServiceProxy : IProxy
  {
    private readonly RealService _realService;
    private readonly ILogger _logger;

    public RealServiceProxy(RealService realService, ILogger logger)
    {
      _realService = realService;
      _logger = logger;
    }

    public void Execute()
    {
      if (IsRoleAdmin())
      {
        _logger.Log();
        _realService.HandleRequest();
        _logger.Log();
      }
    
    }

    private bool IsRoleAdmin()
    {
      return true;
    }


  }


}
