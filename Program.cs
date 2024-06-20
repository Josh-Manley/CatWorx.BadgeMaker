using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {

      Console.WriteLine("Do you want to fetch employee data from the API? (if yes press'y'. if no press any other key)");

      ConsoleKeyInfo cki = Console.ReadKey();
      Console.WriteLine();

      if (cki.Key == ConsoleKey.Y)
      {
        List<Employee> employees = await PeopleFetcher.GetFromApi();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
      }
      else
      {
        List<Employee> employees = PeopleFetcher.GetEmployees();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
      }
    }
  }
}