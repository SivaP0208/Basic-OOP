using System;
using System.Collections.Generic;
namespace SyncfusionCollegeOfEngineeringAndTechnology;
class Program
{
    public static void Main(string[] args)
    {
        // Creating List and Adding Details of Department
        List<DepartmentDetails> departmentDetails=new List<DepartmentDetails>();
        departmentDetails.Add(new DepartmentDetails("EEE",29));
        departmentDetails.Add(new DepartmentDetails("CSE",29));
        departmentDetails.Add(new DepartmentDetails("MECH",30));
        departmentDetails.Add(new DepartmentDetails("ECE",30));

        // Creating List and Adding Details of Student
        List<StudentDetails> studentDetails=new List<StudentDetails>();
        studentDetails.Add(new StudentDetails("Ravichandran E","Ettaparajan",DateTime.ParseExact("11/11/1999","dd/MM/yyyy",null),Gender.Male,95,95,95));
        studentDetails.Add(new StudentDetails("Baskaran S","Sethurajan",DateTime.ParseExact("11/11/1999","dd/MM/yyyy",null),Gender.Male,95,95,95));

        // Creating List and Adding Details of Admission
        List<AdmissionDetails> admissionDetails=new List<AdmissionDetails>();
        admissionDetails.Add(new AdmissionDetails("SF3001","DID101",DateTime.ParseExact("11/05/2022","dd/MM/yyyy",null),AdmissionStatus.Admitted));
        admissionDetails.Add(new AdmissionDetails("SF3002","DID102",DateTime.ParseExact("12/05/2022","dd/MM/yyyy",null),AdmissionStatus.Admitted));

        bool exit=true;
        do
        {
           Console.WriteLine("\n\tSyncfusion College of Engineering and Technology\n");
           Console.WriteLine("\t\tMain Menu");
           Console.WriteLine("1.Student Registration\n2.Student Login\n3.Department Wise Seat Availability\n4.Exit\n");
           switch(int.Parse(Console.ReadLine()))
           {
                case 1:
                {
                    // Student Registration
                    Console.WriteLine("\n\t\tStudent Registration");
                    StudentDetails student=new StudentDetails();
                    Console.Write("Enter your name : ");
                    student.StudentName=Console.ReadLine();
                    Console.Write("Enter your Father name : ");
                    student.FatherName=Console.ReadLine();
                    Console.Write("Enter your Date of Birth in dd/MM/yyyy : ");
                    student.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.Write("Select your Gender Male / Female / Transgender : ");
                    student.Gender=Enum.Parse<Gender>(Console.ReadLine());
                    Console.Write("Enter your Physics Mark : ");
                    student.Physics=int.Parse(Console.ReadLine());
                    Console.Write("Enter your Chemistry Mark : ");
                    student.Chemistry=int.Parse(Console.ReadLine());
                    Console.Write("Enter your Maths Mark : ");
                    student.Maths=int.Parse(Console.ReadLine());

                    // Adding StudentDetails instance to List
                    studentDetails.Add(student);

                    Console.WriteLine($"\n\tStudent Registered Successfully and StudentID is {student.StudentID}");
                    break;
                }
                case 2:
                {
                    bool mainMenu=true;
                    Console.WriteLine("\t\tStudent Login");
                    Console.Write("Enter your Student ID : ");
                    string userEnteredStudentID=Console.ReadLine();
                    bool isValid=true;
                    foreach(StudentDetails student in studentDetails)
                    {       
                        if(student.StudentID.ToLower()==(userEnteredStudentID.Trim()).ToLower())
                        {
                            isValid=false;
                            do
                            {
                                Console.WriteLine($"\n\t\tWelcome {student.StudentName}");
                                Console.WriteLine("a. Check Eligibility\nb. Show Details\nc. Take Admission\nd. Cancel Admission\ne. Show Admission Details\nf. Back to Main Menu\n");
                                switch(char.Parse(Console.ReadLine()))
                                {
                                    case 'a':
                                    {
                                        if(student.CheckEligibility(student.Physics,student.Chemistry,student.Maths))
                                        {
                                            Console.WriteLine("\t\tStudent is Eligible");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\t\tStudent is not Eligible");
                                        }
                                        break;
                                    }
                                    case 'b':
                                    {
                                        Console.WriteLine("\t\tStudent Details\n");
                                        Console.WriteLine($"Student ID : {student.StudentID}\nStudent Name : {student.StudentName}\nDOB : {(student.DOB).ToString("dd/MM/yyyy")}");
                                        Console.WriteLine($"Gender : {student.Gender}\nPhysics Mark : {student.Physics}\nChemistry Mark : {student.Chemistry}\nMaths Mark : {student.Maths}");
                                        break;
                                    }
                                    case 'c':
                                    {
                                        Console.WriteLine("\t\tAdmission Form\n");
                                        foreach(DepartmentDetails department in departmentDetails)
                                        {
                                            Console.WriteLine($"DepartmentID : {department.DepartmentID} | Department Name : {department.DepartmentName} | Number of Seats Available : {department.NumberOfSeats}");
                                        }
                                        Console.Write("\nSelect any one Department ID :");
                                        string userEnteredDepartmentID=Console.ReadLine();
                                        bool isDeptAvailable=true;
                                        foreach(DepartmentDetails department in departmentDetails)
                                        {
                                            if(department.DepartmentID.ToLower()==(userEnteredDepartmentID.Trim()).ToLower())
                                            {
                                                isDeptAvailable=false;
                                                if(student.CheckEligibility(student.Physics,student.Chemistry,student.Maths))
                                                {
                                                    if(department.NumberOfSeats>0)
                                                    {
                                                        bool isAdmitted=true;
                                                        foreach(AdmissionDetails admission in admissionDetails)
                                                        {
                                                            if(admission.StudentID==student.StudentID)
                                                            {
                                                                isAdmitted=false;
                                                                break;
                                                            }
                                                        }
                                                        if(isAdmitted)
                                                        {
                                                            department.NumberOfSeats-=1;
                                                            AdmissionDetails admission =new AdmissionDetails(student.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                                            
                                                            // Adding AdmissionDetails to List
                                                            admissionDetails.Add(admission);
                                                            Console.WriteLine($"\n\tAdmission took successfully. Your admission ID - {admission.AdmissionID}");
                                                        }
                                                        else
                                                        {
                                                            bool isBooked=true;
                                                            foreach(AdmissionDetails admission in admissionDetails)
                                                            {
                                                                if(admission.StudentID==student.StudentID && admission.AdmissionStatus==AdmissionStatus.Cancelled)
                                                                {
                                                                    isBooked=false;
                                                                    foreach(DepartmentDetails departments in departmentDetails)
                                                                    {
                                                                        if(departments.DepartmentID==userEnteredDepartmentID)
                                                                        {
                                                                            isDeptAvailable=false;
                                                                            admission.DepartmentID=departments.DepartmentID;
                                                                            admission.AdmissionDate=DateTime.Now;
                                                                            admission.AdmissionStatus=AdmissionStatus.Admitted;
                                                                            department.NumberOfSeats-=1;
                                                                        }
                                                                    }
                                                                    Console.WriteLine($"\n\tAdmission took successfully. Your admission ID - {admission.AdmissionID}");
                                                                }
                                                            }
                                                            if(isBooked)
                                                            {
                                                                Console.WriteLine("\n\t\tAlready Admission Taken");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\n\tSorry Seat is not Available");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tYou're not Eligible");
                                                }
                                            }
                                        }
                                        if(isDeptAvailable)
                                        {
                                            Console.WriteLine("\n\t\tInvalid Department ID");
                                        }
                                        break;
                                    }
                                    case 'd':
                                    { 
                                        bool isPresent=true;
                                        foreach(AdmissionDetails admission in admissionDetails)
                                        {
                                            if(student.StudentID==admission.StudentID)
                                            {
                                                isPresent=false;
                                                foreach(DepartmentDetails department in departmentDetails)
                                                {
                                                    if(admission.DepartmentID==department.DepartmentID && admission.AdmissionStatus==AdmissionStatus.Admitted)
                                                    {
                                                        department.NumberOfSeats+=1;
                                                        admission.AdmissionStatus=AdmissionStatus.Cancelled;
                                                    }
                                                }
                                                Console.WriteLine($"\nAdmission ID : {admission.AdmissionID}\nStudent ID : {admission.StudentID}\nDepartment ID : {admission.DepartmentID}\nAdmission Date : {(admission.AdmissionDate).ToString("dd/MM/yyyy")}\nAdmission Status : {admission.AdmissionStatus}");
                                                Console.WriteLine("\n\t\tAdmission Cancelled Successfully");
                                            }
                                        }
                                        if(isPresent)
                                        {
                                            Console.WriteLine("\t\tAdmission is not taken");
                                        }
                                        break;
                                    }
                                    case 'e':
                                    {
                                        bool admitted=true;
                                        Console.WriteLine("\t\tAdmission Details");
                                        foreach(AdmissionDetails admission in admissionDetails)
                                        {
                                            if(student.StudentID==admission.StudentID)
                                            {
                                                admitted=false;
                                                Console.WriteLine($"\nAdmission ID : {admission.AdmissionID}\nStudent ID : {admission.StudentID}\nDepartment ID : {admission.DepartmentID}\nAdmission Date : {(admission.AdmissionDate).ToString("dd/MM/yyyy")}\nAdmission Status : {admission.AdmissionStatus}");
                                            }
                                        }
                                        if(admitted)
                                        {
                                            Console.WriteLine("\n\tNo Admission has been Taken yet");
                                        }
                                        break;
                                    }
                                    case 'f':
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
                            }while (mainMenu);
                        }
                    }
                    if(isValid)
                    {
                        Console.WriteLine("\n\tInvalid Student ID or Registration not Completed");
                        break;
                    }
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\t\tDepartment Wise Seat Availability\n");
                    foreach(DepartmentDetails department in departmentDetails)
                    {
                        Console.WriteLine($"DepartmentID : {department.DepartmentID} | Department Name : {department.DepartmentName} | Number of Seats Available : {department.NumberOfSeats}");
                    }
                    break;
                }
                case 4:
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