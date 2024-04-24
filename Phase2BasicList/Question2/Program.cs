using System;
using System.Collections.Generic;
namespace Question2;
class Program
{
    public static void Main(string[] args)
    {
        bool exit=true;
        List<EmployeePayroll> employees=new List<EmployeePayroll>();
        do
        {
            Console.WriteLine("\n\t\tEmployee Payroll Management");
            Console.WriteLine("1.Registration\n2.Login\n3.Exit\n");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                {
                    employees.Add(Registration());
                    break;
                }
                case 2:
                {
                    bool isValid=true;
                    Console.Write("\nEnter your Employee ID : ");
                    string userEnteredEmployeeID=Console.ReadLine();
                    foreach(EmployeePayroll employee in employees)
                    {
                        if(employee.EmployeeID==userEnteredEmployeeID)
                        {
                            isValid=false;
                            Console.WriteLine($"\n\t\tWelcome {employee.EmployeeName} !");
                            SubMenu(employee);
                        }
                    }
                    if(isValid)
                    {
                        Console.WriteLine("\n\t\tUser Invalid ID");
                    }
                    break;
                }
                case 3:
                {
                    exit=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("\t\tInvalid Input");
                    break;
                }
            }
        } while (exit);
        Console.WriteLine("\t\tThank You!\n");
    }
    public static EmployeePayroll Registration()
    {
        Console.WriteLine("\t\tWelcome to Employee Payroll Mangement");
        EmployeePayroll employee=new EmployeePayroll();
        Console.Write("Enter your name : ");
        employee.EmployeeName=Console.ReadLine();
        Console.Write("Enter your role : ");
        employee.Role=Console.ReadLine();
        Console.Write("Select your gender Male / Female : ");
        employee.Gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.Write("Select your Work Location AnnaNagar / Kilpauk : ");
        employee.WorkLocation=Enum.Parse<WorkLocation>(Console.ReadLine(),true);
        Console.Write("Enter your Team name : ");
        employee.TeamName=Console.ReadLine();
        Console.Write("Enter your Date Of Joining in dd/MM/yyyy : ");
        employee.DateOfJoining=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

        Console.WriteLine("\n\t\tRegistration Successful");

        Console.WriteLine($"\nYour Employee ID is : {employee.EmployeeID}");

        return employee;
    }

    public static void SubMenu(EmployeePayroll employee)
    {
        bool mainMenu=true;
        do
        {
            Console.WriteLine("\n\t\tSub Menu");
            Console.WriteLine("1.Calculate Salary\n2.Display Details\n3.Back to Main Menu\n");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                {
                    Console.Write("Enter Number of Working Days in Month : ");
                    employee.NumberOfWorkingDaysInMonth=int.Parse(Console.ReadLine());
                    Console.Write("Enter Number of Leaves Taken : ");
                    employee.NumberOfLeaveTaken=int.Parse(Console.ReadLine());
                    Console.WriteLine($"\nYour Salary is : {employee.SalaryCalculator()}");
                    break;
                }
                case 2:
                {
                    Console.WriteLine($"\nEmployee ID: {employee.EmployeeID}\nEmployee Name : {employee.EmployeeName}");
                    Console.WriteLine($"Role : {employee.Role}\nGender : {employee.Gender}\nWork Location : {employee.WorkLocation}");
                    Console.WriteLine($"Team Name : {employee.TeamName}\nDate Of Joining : {(employee.DateOfJoining).ToString("dd/MM/yyyy")}");
                    break;
                }
                case 3:
                {
                    mainMenu=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("\t\tInvalid Input");
                    break;
                }
            }  
        } while (mainMenu);
    }
}