using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CatWorx.BadgeMaker
{
  class PeopleFetcher
  {
    public static List<Employee> GetEmployees()
    {
      List<Employee> employees = new List<Employee>();
      while (true)
      {
        Console.WriteLine("Please enter first name: (leave empty to exit): ");
        string firstName = Console.ReadLine() ?? "";
        if (firstName == "")
        {
          break;
        }
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine() ?? "";

        Console.Write("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter Photo URL: ");
        string photoUrl = Console.ReadLine() ?? "";

        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
      }

      return employees;
    }
    async public static Task<List<Employee>> GetFromApi()
    {
      List<Employee> employees = new List<Employee>();

      using (HttpClient client = new HttpClient())
      {
        string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
      }

      return employees;
    }
  }
}