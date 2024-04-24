using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionCollegeOfEngineeringAndTechnology
{
    /// <summary>
    /// This Datatype is used to store predefined values.<see cref="StudentDetails"/>
    /// </summary>
    /// <value>Admitted / Cancelled</value> 
    public enum AdmissionStatus{select,Admitted,Cancelled}

    /// <summary>
    /// This class is used to create instance for Admission <see cref="AdmissionDetails"/> 
    /// </summary>
    public class AdmissionDetails
    {
        /// <summary>
        /// Static Field s_admissionID used to auto increment AdmissionID of the instance of <see cref="AdmissionDetails"/>.
        /// </summary>
        private static int s_admissionID=1000;

        /// <summary>
        /// This Property is used to hold AdmissionID of instance of <see cref="AdmissionDetails"/>. 
        /// </summary>
        public string AdmissionID { get; }

        /// <summary>
        /// This Property is used to hold StudentID of instance of <see cref="AdmissionDetails"/>. 
        /// </summary>
        public string StudentID { get; set; }

        /// <summary>
        /// This Property is used to hold DepartmentID of instance of <see cref="AdmissionDetails"/>.
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// This Property is used to hold Date of Admission of instance of <see cref="AdmissionDetails"/>.
        /// </summary>
        public DateTime AdmissionDate { get; set; }

        /// <summary>
        /// This Property is used to hold Status of Admission of instance of <see cref="AdmissionDetails"/>.
        /// </summary>
        /// <value>Admitted / Cancelled</value>
        public AdmissionStatus AdmissionStatus { get; set; }

        /// <summary>
        /// AdmissionDetails Constructor is used to initialize its Properties by parameter values.
        /// </summary>
        /// <param name="studentID">studentName parameter used to assign its value to its respected Property.</param>
        /// <param name="departmentID">departmentID parameter used to assign its value to its respected Property.</param>
        /// <param name="admissionDate">admissionDate parameter used to assign its value to its respected Property.</param>
        /// <param name="admissionStatus">admissionStatus parameter used to assign its value to its respected Property.</param>
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        } 
    }
}