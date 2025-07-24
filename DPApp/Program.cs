// See https://aka.ms/new-console-template for more information
using DPApp.Creational;
using DPApp.Cretional;

Console.WriteLine("Hello, World!");

#region Factory Method

// Versiyon 1
// User Interface
var carFactory = new CarFactory();
ICar bmw = carFactory.create("bmw");
bmw.Color = "Red";
bmw.ModelYear = 2015;
ICar mercedes = carFactory.create("mercedes");
mercedes.Color = "White";
mercedes.ModelYear = 2022;

// Versiyon2
var bmwFactory = new BmwCarFactory();
ICar bmw1 = bmwFactory.Create();

var mercedesFactory = new MercedesFactory();
ICar mercedes1 = mercedesFactory.Create();


#endregion

#region Singleton 

ToolBar.Instance.openViewTab(); // 1. instance newlenir
ToolBar.Instance.openFileTab(); // 2. çağırımda instance newlemeye gerek olmaz.

ThreadSafeToolBar.Instance.openFileTab();
ThreadSafeToolBar.Instance.openViewTab();

#endregion


#region AbstractFactory

IList<IDeveloper> developers = new List<IDeveloper>();

var teamFactory = new TeamFactory();
var devFactory = teamFactory.CreateDeveloperFactory();
var testerFactory  = teamFactory.CreateTesterFactory();

var dev1 = devFactory.CreateJuniorDeveloper();
var dev2 = devFactory.CreateSeniorDeveloper();
var dev3 = devFactory.CreateJuniorDeveloper();

developers.Add(dev1);
developers.Add(dev2);
developers.Add(dev3);

IList<ITester> testers = new List<ITester>();

var tester1 = testerFactory.CreateJuniorTester();
var tester2 = testerFactory.CreateSeniorTester();
testers.Add(tester1);
testers.Add(tester2);

//var p = new Product();
//p.Name = "Test1";

#endregion

#region Builder


Product p1 = new ProductBuilder()
  .SetName("Ürün-1")
  .SetPrice(15)
  .Build();

#endregion


#region Prototype

Customer c = new Customer();
c.Name = "Ali";
c.Adddres = new Address();
c.Adddres.Text = "İstanbul";

// aynı nesnenin farklı bir nesne instance olarak kopyalanamasını sağlar.
Customer c2 = (Customer)c.Clone();

if(c == c2)
{

}

c.GetHashCode();
c2.GetHashCode();

Console.Write(c2.Name);
Console.WriteLine(c2.Adddres?.Text);



PrototypeRegister<Employee> prototypeRegister = new PrototypeRegister<Employee>();
Employee a = new Employee();
a.Name = "Mustafa";
Employee emp2 = a.Clone();
emp2.Name = "Cenk";

if(emp2 == a)
{

}

Console.WriteLine(c.GetHashCode());
Console.WriteLine(c2.GetHashCode());

//prototypeRegister.Register("employee", a);
//IClonable<Employee> e2 = prototypeRegister.Clone("employee");



#endregion