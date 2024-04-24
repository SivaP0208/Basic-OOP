using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    // Enum for Gender,Branch,Team
    public enum Gender{Select,Male,Female}
    public enum Branch{Select,Eymard,Karuna,Madhura}
    public enum Team{Select,Network,Hardware,Developer,Facility}

    public class EmployeeDetails
    {
        //Field
        private static int s_employeeID=3000;

        //Properties
        public string EmployeeID { get; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public long MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public Branch Branch { get; set; }
        public Team Team { get; set; }

        //Constructors
        public EmployeeDetails()
        {
            // Auto Increment ID
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;
        }

        public EmployeeDetails(string fullName,DateTime dob,long mobileNumber,Gender gender,Branch branch,Team team)
        {
            // Auto Increment ID
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;

            FullName=fullName;
            DOB=dob;
            MobileNumber=mobileNumber;
            Gender=gender;
            Branch=branch;
            Team=team;
        }
    }
}