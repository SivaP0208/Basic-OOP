using System;
using System.Collections.Generic;
namespace Question3;
class Program
{
    public static void Main(string[] args)
    {
        List<ElectricityBoardBill> bills=new List<ElectricityBoardBill>();
        bool exit=true;
        do
        {
            Console.WriteLine("\n\t\tMain Menu");
            Console.WriteLine("1.Registration\n2.Login\n3.Exit\n");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                {
                    Console.WriteLine("\t\tElectricity Board");
                    Console.Write("Enter your name : ");
                    string name=Console.ReadLine();
                    Console.Write("Enter your Phone Number : ");
                    long phoneNumber=long.Parse(Console.ReadLine());
                    Console.Write("Enter your Mail ID : ");
                    string mailID=Console.ReadLine();

                    ElectricityBoardBill bill=new ElectricityBoardBill(name,phoneNumber,mailID);
                    bills.Add(bill);

                    Console.WriteLine($"\n\t\tRegistration Successfull\nMeter ID : {bill.MeterID}");
                    break;
                }
                case 2:
                {
                    bool isValid=true;
                    Console.Write("Enter your Meter ID : ");
                    string userEnteredMeterID=Console.ReadLine();
                    foreach(ElectricityBoardBill bill in bills)
                    {
                        if(bill.MeterID==userEnteredMeterID)
                        {
                            isValid=false;
                            bool mainMenu=true;
                            Console.WriteLine($"\n\t\tWelcome {bill.UserName} !");
                            do
                            {
                                Console.WriteLine("\n\t\tSub Menu");
                                Console.WriteLine("1.Calculate Bill Amount\n2.Display details\n3.Back to Main Menu\n");
                                switch(int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                    {
                                        Console.Write("Enter How many Units used : ");
                                        bill.UnitsUsed=int.Parse(Console.ReadLine());
                                        Console.WriteLine("\n\tElectricity Board Bill");
                                        Console.WriteLine($"\nBill ID : {bill.BillId}\nUser Name : {bill.UserName}\nBill Amount : {bill.BillCalculator()}");
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("\n\t\tUser Detais");
                                        Console.WriteLine($"\nMeter ID : {bill.MeterID}\nUser Name : {bill.UserName}\nPhone Number : {bill.PhoneNumber}\nMail ID : {bill.MailID}");
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
                    if(isValid)
                    {
                        Console.WriteLine("\n\t\tInvalid Meter ID");
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
        Console.WriteLine("\t\tThank You !\n");
    }
}