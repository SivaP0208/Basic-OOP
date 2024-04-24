using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public enum WorkLocation{select,AnnaNagar,Kilpauk}
    public enum Gender{select,Male,Female}
    public class EmployeePayroll
    {
        private static int s_employeeID=1000;
        public string EmployeeID { get; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NumberOfWorkingDaysInMonth { get; set; }
        public int NumberOfLeaveTaken { get; set; }
        public Gender Gender { get; set; }

        public EmployeePayroll()
        {
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;
        }

        public double SalaryCalculator()
        {
            int workedDays=NumberOfWorkingDaysInMonth-NumberOfLeaveTaken;
            return workedDays*500.0;
        }
    }
}