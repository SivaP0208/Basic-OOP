using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccinationDrive
{
    public static class Operations
    {
        static List<Beneficiary> beneficiariesList=new List<Beneficiary>();
        static List<Vaccine> vaccinesList=new List<Vaccine>();
        static List<Vaccination> vaccinationsList=new List<Vaccination>();
        public static void AddDefaultData()
        {
            beneficiariesList.Add(new Beneficiary("Ravichandran",21,Gender.Male,8765898769L,"Chennai"));
            beneficiariesList.Add(new Beneficiary("Baskaran",22,Gender.Male,9876543208L,"Chennai"));

            vaccinesList.Add(new Vaccine(VaccineName.Covishield,50));
            vaccinesList.Add(new Vaccine(VaccineName.Covaccine,50));

            vaccinationsList.Add(new Vaccination("BID1001","CID2001",1,new DateTime(2021,11,11)));
            vaccinationsList.Add(new Vaccination("BID1001","CID2001",2,new DateTime(2022,03,11)));
            vaccinationsList.Add(new Vaccination("BID1002","CID2002",1,new DateTime(2022,04,04)));
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t************ Covid Vaccination Drive ************");
            bool exit=true;
            do
            {
                Console.WriteLine("\n\t\tMain Menu");
                Console.WriteLine("1. Beneficiary Registration\n2. Login\n3. Get Vaccine Information\n4. Exit\n");
                Console.Write("\nSelect the Option : ");
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                    {
                        Console.WriteLine("\n\t~~~~~~~~~ Beneficiary Registration ~~~~~~~~~");
                        BeneficiaryRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("\n\t\t    Login         ");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("\n\t----------Vaccine Information----------\n");
                        GetVaccineInfo();
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
        }

        public static void BeneficiaryRegistration()
        {
            Beneficiary beneficiary=new Beneficiary();
            Console.Write("Enter your Name : ");
            beneficiary.Name=Console.ReadLine();
            Console.Write("Enter your Age : ");
            int age;
            while(!int.TryParse(Console.ReadLine(),out age) || !(age>0))
            {
                Console.Write("Invalid Age please enter again : ");
            }
            beneficiary.Age=age;
            Console.Write("Enter your Gender (Male,Female,Others) : ");
            Gender gender;
            while(!Enum.TryParse<Gender>(Console.ReadLine(),true,out gender))
            {
                Console.Write("Invalid Gender please enter again : ");
            }
            beneficiary.Gender=gender;
            Console.Write("Enter your Mobile Number : ");
            long mobileNumber;
            while(!long.TryParse(Console.ReadLine(),out mobileNumber) || !(mobileNumber>=6000000000 && mobileNumber<=9999999999))
            {
                Console.Write("Invalid Mobile Number please enter again : ");
            }
            beneficiary.MobileNumber=mobileNumber;
            Console.Write("Enter your City : ");
            beneficiary.City=Console.ReadLine();

            beneficiariesList.Add(beneficiary);

            Console.WriteLine($"\n\tBeneficiary Registration Successfull and Your Reg.No is {beneficiary.RegistrationNumber}");
        }

        public static void Login()
        {
            Console.Write("Enter your Registration Number : ");
            string loginID=Console.ReadLine().ToUpper();
            bool isValidLogin=true;
            foreach(Beneficiary beneficiary in beneficiariesList)
            {
                if(beneficiary.RegistrationNumber.Equals(loginID))
                {
                    isValidLogin=false;
                    Console.WriteLine("\n\t\t Logged in Successfull");
                    SubMenu(beneficiary);
                    break;
                }
            }
            if(isValidLogin)
            {
                Console.WriteLine("\n\tInvalid Register Number or Registration not Completed");
            }
        }

        public static void SubMenu(Beneficiary beneficiary)
        {
            bool mainMenu=true;
            do
            {
                Console.WriteLine($"\n\t\t Welcome {beneficiary.Name}");
                Console.WriteLine("1. Show My Details\n2. Take Vaccination\n3. My Vaccination History\n4. Next Due Date\n5. Back to Main menu\n");
                Console.Write("Select the Option : ");
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                    {
                        Console.WriteLine("\n\t Beneficiary Details");
                        ShowMyDetails(beneficiary);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("\n\t\t Take Vaccination");
                        TakeVaccination(beneficiary);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("\n\t\t  My Vaccination History\n");
                        MyVaccinationHistory(beneficiary);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("\n\t\t\t Due Date for next Vaccine");
                        NextDueDate(beneficiary);
                        break;
                    }
                    case 5:
                    {
                        mainMenu=false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("\n\t\tInvalid input");
                        break;
                    }
                }
            } while (mainMenu);
        }

        public static void ShowMyDetails(Beneficiary beneficiary)
        {
            Console.WriteLine($"{"Registration Number"} : {beneficiary.RegistrationNumber}\n{"Name",-19} : {beneficiary.Name}\n{"Age",-19} : {beneficiary.Age}\n{"Gender",-19} : {beneficiary.Gender}\n{"Mobile Number",-19} : {beneficiary.MobileNumber}\n{"City",-19} : {beneficiary.City}");
        }

        public static void TakeVaccination(Beneficiary beneficiary)
        {
            Console.WriteLine("\n\t----------Vaccine Information----------");
            GetVaccineInfo();
            Console.Write("\nSelect Vaccine ID : ");
            string vaccineID=Console.ReadLine().ToUpper();
            bool isValidVaccine=true;
            foreach(Vaccine vaccine in vaccinesList)
            {
                if(vaccine.VaccineID.Equals(vaccineID))
                {
                    isValidVaccine=false;
                    bool isVaccined=true;
                    foreach(Vaccination vaccination in vaccinationsList)
                    {
                        if(beneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                        {
                            isVaccined=false;
                            break;
                        }
                    }
                    if(isVaccined)
                    {
                        if(beneficiary.Age>14)
                        {
                            Vaccination vaccination=new Vaccination();
                            vaccination.RegistrationNumber=beneficiary.RegistrationNumber;
                            vaccination.VaccineID=vaccine.VaccineID;
                            vaccination.DoseNumber=1;
                            vaccination.VaccinatedDate=DateTime.Now;

                            vaccine.NoOfDoseAvailable-=1;

                            vaccinationsList.Add(vaccination);
                            Console.WriteLine("\n\t\tVaccinated Successfully");
                        }
                    }
                    else
                    {
                        int doseCount=0;
                        string vaccinedID="";
                        foreach (Vaccination vaccination in vaccinationsList)
                        {
                            if (beneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                            {
                                doseCount++;
                                vaccinedID=vaccination.VaccineID;
                            }
                        }
                        if(doseCount<3)
                        {
                            if(vaccineID.Equals(vaccinedID))
                            {
                                Vaccination vaccination = new Vaccination();
                                vaccination.RegistrationNumber = beneficiary.RegistrationNumber;
                                vaccination.VaccineID = vaccine.VaccineID;
                                vaccination.DoseNumber = doseCount + 1; ;
                                vaccination.VaccinatedDate = DateTime.Now;

                                vaccine.NoOfDoseAvailable -= 1;

                                vaccinationsList.Add(vaccination);
                                Console.WriteLine("\n\t\tVaccinated Successfully");
                            }
                            else
                            {
                                Console.WriteLine($"\n\t\"You have selected different Vaccine\". You can vaccine with {((vaccineID=="CID2001")?"Covaccine":"Covishield")}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nAll the three Vaccination are completed, you can't be vaccinated now");
                        }
                    }
                }
            }
            if(isValidVaccine)
            {
                Console.WriteLine("\n\t\tInvalid Vaccine ID");
            }

        }

        public static void MyVaccinationHistory(Beneficiary beneficiary)
        {
            bool isVaccined = false;
            foreach (Vaccination vaccination in vaccinationsList)
            {
                if (beneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                {
                    isVaccined = true;
                    break;
                }
            }
            if(isVaccined)
            {
                Console.WriteLine($"|{"Vaccination ID",-15}|{"Registration Number",-20}|{"Vaccine ID",-12}|{"Dose Number",-12}|{"Vaccinated Date",-20}|");
                foreach (Vaccination vaccination in vaccinationsList)
                {
                    if (beneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                    {
                        Console.WriteLine($"|{vaccination.VaccinationID,-15}|{vaccination.RegistrationNumber,-20}|{vaccination.VaccineID,-12}|{vaccination.DoseNumber,-12}|{vaccination.VaccinatedDate.ToString("dd/MM/yyyy"),-17}|");
                    }
                }
            }
            else
            {
                Console.WriteLine("\t You have not Vaccined Single dose till now");
            }
        }

        public static void NextDueDate(Beneficiary beneficiary)
        {
            bool isVaccined = false;
            DateTime nextDueDate=DateTime.Now;
            int doseCount=0;
            foreach (Vaccination vaccination in vaccinationsList)
            {
                if (beneficiary.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                {
                    isVaccined = true;
                    doseCount++;
                    nextDueDate=vaccination.VaccinatedDate.AddDays(30);
                }
            }
            if(isVaccined)
            {
                if(doseCount<3)
                {
                    Console.WriteLine($"\n\t\"Your Due Date for Next Vaccine is {nextDueDate.ToString("dd/MM/yyyy")}\"");
                }
                else
                {
                    Console.WriteLine("\n\t\t\"You have completed all vaccination.\n\tThanks for your participation in the vaccination drive.\"");
                }
            }
            else
            {
                Console.WriteLine("\n\t\t\"You can take vaccine now.\"");
            }
        }

        public static void GetVaccineInfo()
        {
            if(vaccinesList!=null)
            {
                Console.WriteLine($"|{"Vaccine ID",-12}|{"Vaccine Name",-14}|{"No of Dose Available",-21}|");
                foreach(Vaccine vaccine in vaccinesList)
                {
                    Console.WriteLine($"|{vaccine.VaccineID,-12}|{vaccine.VaccineName,-14}|{vaccine.NoOfDoseAvailable,-21}|");
                }
            }
        }
    }
}