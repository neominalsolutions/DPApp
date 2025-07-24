using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Creational
{
  // Senaryo: Bir Geliştirme ekip oluşturmak için farklı özelliklerde developer,tester ve analistlere ihtiyac var. bu sınıfların doğru bir şekilde oluşturulması için abstract factory design pattern kullnalım

  // abstraction
  public interface IDeveloper { }

  // implementatio
  public class JuniorDeveloper : IDeveloper { }
  public class SeniorDeveloper: IDeveloper { }

  public interface ITester { }

  public class JuniorTester:ITester { }
  public class SeniorTester: ITester { }


  public interface IDeveloperFactory
  {
    JuniorDeveloper CreateJuniorDeveloper();
    SeniorDeveloper CreateSeniorDeveloper();
  }

  public class DeveloperFactory : IDeveloperFactory
  {
    public JuniorDeveloper CreateJuniorDeveloper()
    {
      return new JuniorDeveloper();
    }

    public SeniorDeveloper CreateSeniorDeveloper()
    {
      return new SeniorDeveloper();
    }
  }

  public interface ITesterFactory
  {
    JuniorTester CreateJuniorTester();
    SeniorTester CreateSeniorTester();
  }

  public class TesterFactory : ITesterFactory
  {
    public JuniorTester CreateJuniorTester()
    {
      return new JuniorTester();
    }

    public SeniorTester CreateSeniorTester()
    {
      return new SeniorTester();
    }
  }

  public interface ITeamFactory
  {
    IDeveloperFactory CreateDeveloperFactory();
    ITesterFactory CreateTesterFactory();

  }

  public class TeamFactory : ITeamFactory
  {
    public IDeveloperFactory CreateDeveloperFactory()
    {
      return new DeveloperFactory();
    }

    public ITesterFactory CreateTesterFactory()
    {
      return new TesterFactory();
    }
  }






}
