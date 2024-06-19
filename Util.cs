using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;

namespace CatWorx.BadgeMaker
{
  class Util
  {
    public static void PrintEmployees(List<Employee> employees)
    {
      for (int i = 0; i < employees.Count; i++)
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
      }
    }
    public static void MakeCSV(List<Employee> employees)
    {
      if (!Directory.Exists("data"))
      {
        Directory.CreateDirectory("data");
      }
      using (StreamWriter file = new StreamWriter("data/employees.csv"))
      {
        file.WriteLine("ID,Name,PhotoUrl");
        for (int i = 0; i < employees.Count; i++)
        {
          string template = "{0},{1},{2}";
          file.WriteLine(string.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
        }
      }
    }
    public static void MakeBadges(List<Employee> employees)
    // {
    //   SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));

    //   SKData data = newImage.Encode();
    //   data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
    // }
  }
}