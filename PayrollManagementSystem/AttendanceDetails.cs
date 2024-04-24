using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    public class AttendanceDetails
    {
        // Field
        private static int s_attendanceID=1000;

        // Properties
        public string AttendanceID { get; }
        public string EmployeeID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int HoursWorked { get; set; }

        // Constructors
        public AttendanceDetails()
        {
            // Auto Increment ID
            s_attendanceID++;
            AttendanceID="AID"+s_attendanceID;
        }

        public AttendanceDetails(string employeeID,DateTime checkInTime,DateTime checkOutTime)
        {
            // Auto Increment ID
            s_attendanceID++;
            AttendanceID="AID"+s_attendanceID;

            EmployeeID=employeeID;
            CheckInTime=checkInTime;
            CheckOutTime=checkOutTime;
        }

        public AttendanceDetails(string employeeID,DateTime checkInTime,DateTime checkOutTime,int hoursWorked)
        {
            // Auto Increment ID
            s_attendanceID++;
            AttendanceID="AID"+s_attendanceID;

            EmployeeID=employeeID;
            CheckInTime=checkInTime;
            CheckOutTime=checkOutTime;
            HoursWorked=hoursWorked;
        }

        public void WorkedHours()
        {
            TimeSpan span=CheckOutTime-CheckInTime;
            HoursWorked=span.Hours;
        }
    }
}