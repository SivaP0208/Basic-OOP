using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionCollegeOfEngineeringAndTechnology
{
    /// <summary>
    /// This class is used to create instance for Department <see cref="DepartmentDetails"/>. 
    /// </summary>
    public class DepartmentDetails
    {
        /// <summary>
        /// Static Field s_departmentID is used to auto increment DepartmentID of instance of <see cref="DepartmentDetails"/>. 
        /// </summary>
        private static int s_departmentID=100;

        /// <summary>
        /// This Property is used to hold DepartmentID of instance of <see cref="DepartmentDetails"/>.
        /// </summary>
        public string DepartmentID { get; }

        /// <summary>
        /// This Property is used to hold Department Name of instance of <see cref="DepartmentDetails"/>. 
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// This Property is used to hold Number of Seats Available in Department of instance of <see cref="DepartmentDetails"/>. 
        /// </summary>
        public int NumberOfSeats { get; set; } 

        /// <summary>
        /// DepartmentDetails Constructor is used to initialize its properties by parameter values.
        /// </summary>
        /// <param name="departmentName">departmentName parameter used to assign its value to its respected Property.</param>
        /// <param name="numberOfSeats">numberOfSeats parameter used to assign its value to its respected Property.</param>
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }
    }
}