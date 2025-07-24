using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Creational
{
  // Nesnenin tek bir instance ile çalışması ve içindeki methodların çağırması

  public sealed class ThreadSafeToolBar
  {
    private static readonly Lazy<ThreadSafeToolBar> lazy = new Lazy<ThreadSafeToolBar>(() => new ThreadSafeToolBar());

    private ThreadSafeToolBar()
    {

    }

    public static ThreadSafeToolBar Instance => lazy.Value;


    public void openViewTab()
    {
      Console.WriteLine("Thread Safe View Tab");
    }

    public void openFileTab()
    {
      Console.WriteLine("Thread Safe File Tab");
    }
  }



  public sealed class ToolBar
  {
    private static object lockObject = new object(); // nesne instance kitler
    private static ToolBar _toolBar; // nesne instance saklayan field

    // constructor Private
    private ToolBar()
    {

    }

    public static ToolBar Instance { 
      
      get
      {
        if(_toolBar == null)
        {
          lock (lockObject)
          {

            if(_toolBar == null)
            {
              _toolBar = new ToolBar();
              return _toolBar;
            }
            
          }
        }
        return _toolBar;
      } 
   }


    public void openViewTab()
    {
      Console.WriteLine("View Tab");
    }

    public void openFileTab()
    {
      Console.WriteLine("File Tab");
    }

  }
  
}
