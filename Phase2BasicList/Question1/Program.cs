using System;
using System.Collections.Generic;
namespace Question1;
class Program
{
    public static void Main(string[] args)
    {
        bool exit=true;
        List<BankAccount> customers=new List<BankAccount>();
        do
        {
            Console.WriteLine("\n\t\tMain Menu");
            Console.WriteLine("1.Registration\n2.Login\n3.Exit\n");
            int userInput=int.Parse(Console.ReadLine());
            switch(userInput)
            {
                case 1:
                {   
                    Console.WriteLine("\n\t\tWelcome to HDFC Bank");
                    BankAccount customer=new BankAccount();
                    Console.Write("Enter your name : ");
                    customer.CustomerName=Console.ReadLine();
                    Console.Write("Select your Gender Male/Female/Transgender : ");
                    customer.Gender=Enum.Parse<Gender>(Console.ReadLine(),true);
                    Console.Write("Enter your Phone number : ");
                    customer.Phone=long.Parse(Console.ReadLine());
                    Console.Write("Enter your Mail ID : ");
                    customer.MailID=Console.ReadLine();
                    Console.Write("Enter your DOB in dd/MM/yyyy : ");
                    customer.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                    customers.Add(customer);

                    Console.WriteLine("\n\t\tRegistration Successfull");

                    Console.WriteLine($"\nYour Customer ID : {customer.CustomerID}\nYour Available Balance : {customer.Balance}");
                    break;
                }
                case 2:
                {
                    bool isValid=true;
                    Console.Write("\nEnter your Customer ID : ");
                    string userEnteredCustomerID=Console.ReadLine();
                    foreach(BankAccount customer in customers)
                    {
                        if(customer.CustomerID==userEnteredCustomerID)
                        {
                            isValid=false;
                            Console.WriteLine("\n\t\tLogin Successfull");
                            bool mainMenu=true;
                            do
                            {
                                Console.WriteLine($"\n\t\tWelcome {customer.CustomerName}!");
                                Console.WriteLine("\n1.Deposit\n2.Withdraw\n3.Balance Check\n4.Back to Main menu\n");
                                switch(int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                    {
                                        Console.Write("\nEnter Amount to Deposit : ");
                                        customer.Deposit(double.Parse(Console.ReadLine()));
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.Write("\nEnter Amount to Withdraw : ");
                                        customer.Withdraw(double.Parse(Console.ReadLine()));
                                        break;
                                    }
                                    case 3:
                                    {
                                        Console.WriteLine($"\nAvailable Balance is : {customer.Balance}");
                                        break;
                                    }
                                    case 4:
                                    {
                                        mainMenu=false;
                                        break;
                                    }
                                    default:
                                    {
                                        Console.WriteLine("\n\t\tInvalid Input");
                                        break;
                                    }
                                }  
                            } while (mainMenu);
                        }
                    }
                    if(isValid)
                    {
                        Console.WriteLine("\n\tInvalid User Id or Registration not Completed ");
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
        Console.WriteLine("\t\tThank You !");
        
    }
}