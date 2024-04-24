using System;
namespace CovidVaccinationDrive;
class Program
{
    public static void Main(string[] args)
    {
        Operations.AddDefaultData();
        Operations.MainMenu();
    }
}