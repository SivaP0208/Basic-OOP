using System;
using System.Collections.Generic;
namespace PayrollManagementSystem;
class Program
{
    // Creating List for Employees and their Attendance Details
    static List<EmployeeDetails> employeesList=new List<EmployeeDetails>();
    static List<AttendanceDetails> attendanceDetails=new List<AttendanceDetails>();

    public static void Main(string[] args)
    {
        // Creating Default Employee deatils and Adding it in List
        employeesList.Add(new EmployeeDetails("Ravi",DateTime.ParseExact("11/11/1999","dd/MM/yyyy",null),9958858888L,Gender.Male,Branch.Eymard,Team.Developer));

        // Creating Default Attendance Details and Adding it in List
        attendanceDetails.Add(new AttendanceDetails("SF3001",DateTime.ParseExact("15/05/2022 09:00 AM","dd/MM/yyyy hh:mm tt",null),DateTime.ParseExact("15/05/2022 06:10 PM","dd/MM/yyyy hh:mm tt",null),8));
        attendanceDetails.Add(new AttendanceDetails("SF3002",DateTime.ParseExact("16/05/2022 09:10 AM","dd/MM/yyyy hh:mm tt",null),DateTime.ParseExact("16/05/2022 06:50 PM","dd/MM/yyyy hh:mm tt",null),8));

        bool exit=true;
        do
        {
            Console.WriteLine("\n\t\tPayroll Management System");
            Console.WriteLine("\t\t\tMain Menu");
            Console.WriteLine("1. Employee Registration\n2. Employee Login\n3. Exit\n");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                {
                    EmployeeDetails employee=Registration();
                    employeesList.Add(employee);
                    Console.WriteLine($"\tEmployee added successfully your ID is : {employee.EmployeeID}");
                    break;
                }
                case 2:
                {
                    bool mainMenu=true;
                    Console.Write("Enter your Employee ID : ");
                    string userEnteredEmployeeID=Console.ReadLine();
                    bool isEmployeeIdValid=true;
                    foreach(EmployeeDetails employee in employeesList)
                    {
                        if(employee.EmployeeID.ToLower()==(userEnteredEmployeeID.Trim()).ToLower())
                        {
                            isEmployeeIdValid=false;
                            do
                            {
                                Console.WriteLine($"\n\t\tWelcome {employee.FullName}");
                                Console.WriteLine("1. Add Attendance\n2. Display Details\n3. Calculate Salary\n4. Back to Main Menu\n");
                                switch(int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                    {
                                        AttendanceDetails attendance=AddAttendance(employee);
                                        attendanceDetails.Add(attendance);
                                        if(attendance.HoursWorked>=8)
                                        {
                                            attendance.HoursWorked=8;
                                            Console.WriteLine($"\n\tCheck-in and Check-out Successful and Today you have worked {attendance.HoursWorked} Hours");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"\n\tCheck-in and Check-out Successful and Today you have worked {attendance.HoursWorked} Hours");
                                        }
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.WriteLine("\t\tEmployee Details");
                                        Console.Write($"Employee ID : {employee.EmployeeID}\nEmployee Full Name : {employee.FullName}\nDate of Birth : {(employee.DOB).ToString("dd/MM/yyyy")}\n");
                                        Console.WriteLine($"Mobile Number : {employee.MobileNumber}\nGender : {employee.Gender}\nBranch : {employee.Branch}\nTeam : {employee.Team}");
                                        break;
                                    }
                                    case 3:
                                    {
                                        bool isEmployeeWorked=true;
                                        double totalSalary=0;
                                        foreach(AttendanceDetails attendance in attendanceDetails)
                                        {
                                            if(employee.EmployeeID==attendance.EmployeeID && attendance.CheckInTime.Month==(DateTime.Now).Month)
                                            {
                                                isEmployeeWorked=false;
                                                totalSalary+=500.0*attendance.HoursWorked/8;
                                            }
                                        }
                                        if(isEmployeeWorked)
                                        {
                                            Console.WriteLine("\t\tYou didn't Worked in this current Month");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"\tYour Salary for this month is {totalSalary} INR");
                                        }
                                        break;
                                    }
                                    case 4:
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
                    if(isEmployeeIdValid)
                    {
                        Console.WriteLine("\t\tInvalid User ID or Registration not completed");
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
        }while(exit);
    }

    // Method for Registration
    public static EmployeeDetails Registration()
    {
        Console.WriteLine("\t\tEmployee Registration");
        EmployeeDetails employee=new EmployeeDetails();
        Console.Write("Enter your Full Name : ");
        employee.FullName=Console.ReadLine();
        Console.Write("Enter your Date of Birth (dd/MM/yyyy) : ");
        bool isDateValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out DateTime date);
        while(!isDateValid)
        {
            Console.Write("Invalid Date please enter again (dd/MM/yyyy) : ");
            isDateValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out date);
        }
        employee.DOB=date;
        Console.Write("Enter your Mobile Number : ");
        bool isNumberValid=long.TryParse(Console.ReadLine(),out long mobileNumber);
        while(!isNumberValid)
        {
            Console.Write("Invalid Mobile Number please enter again : ");
            isNumberValid=long.TryParse(Console.ReadLine(),out mobileNumber);
        }
        employee.MobileNumber=mobileNumber;
        Console.Write("Enter your Gender (Male/Female) : ");
        employee.Gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.Write("Enter your Branch (Eymard/Karuna/Madhura) : ");
        employee.Branch=Enum.Parse<Branch>(Console.ReadLine(),true);
        Console.Write("Enter your Team (Network/Hardware/Developer/Facility) : ");
        employee.Team=Enum.Parse<Team>(Console.ReadLine(),true);

        return employee;
    }

    // Method for Add Attendance

    public static AttendanceDetails AddAttendance(EmployeeDetails employee)
    {
        AttendanceDetails attendance=new AttendanceDetails();
        attendance.EmployeeID=employee.EmployeeID;
        Console.Write("Enter Date with CheckIn Time (dd/MM/yyyy hh:mm tt) : ");
        bool isCheckInValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm tt",null,System.Globalization.DateTimeStyles.None,out DateTime checkInTime);
        while(!isCheckInValid)
        {
            Console.Write("Invalid Date or Time please enter again (dd/MM/yyyy hh:mm tt) : ");
            isCheckInValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm tt",null,System.Globalization.DateTimeStyles.None,out checkInTime);
        }
        attendance.CheckInTime=checkInTime;
        Console.Write("Enter Date with CheckOut Time (dd/MM/yyyy hh:mm tt) : ");
        bool isCheckOutValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm tt",null,System.Globalization.DateTimeStyles.None,out DateTime checkOutTime);
        while(!isCheckOutValid)
        {
            Console.Write("Invalid Date or Time please enter again (dd/MM/yyyy hh:mm tt) : ");
            isCheckOutValid=DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm tt",null,System.Globalization.DateTimeStyles.None,out checkOutTime);
        }
        attendance.CheckOutTime=checkOutTime;
        attendance.WorkedHours();

        return attendance;
    }
}