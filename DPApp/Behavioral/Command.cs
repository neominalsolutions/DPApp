using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Behavioral
{


  public interface ICommand
  {
    void Execute();
  }

  public class SaveComand : ICommand
  {
    public void Execute()
    {
      Console.WriteLine("Save");
    }
  }

  public class CancelComand : ICommand
  {
    public void Execute()
    {
      Console.WriteLine("Cancel");
    }
  }

  public class ApplyComand : ICommand
  {
    public void Execute()
    {
      Console.WriteLine("Apply");
    }
  }

  public class CommandExecutor
  {
    private List<ICommand> commands = new List<ICommand>();
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
      _command = command;
    }

    public void AddCommand(ICommand command)
    {
      commands.Add(command);
    }

    public void Execute()
    {
      foreach (ICommand command in commands)
      {
        command.Execute();
      }

    }

    public void Apply()
    {
      this._command.Execute();
    }


  }

  }
