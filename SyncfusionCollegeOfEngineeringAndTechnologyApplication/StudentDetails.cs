using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionCollegeOfEngineeringAndTechnology
{
    /// <summary>
    /// This Datatype is used to store predefined values.
    /// </summary>
    /// <value>Male / Female / Transgender</value>
    public enum Gender{Select,Male,Female,Transgender}
    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails"/>.
    /// Refer documentation on <see href="www.Syncfusion.com"=/>.
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// Static Field s_studentID used to auto increment StudentID of the instance of <see cref="StudentDetails"/>.
        /// </summary>
        private static int s_studentID=3000;

        // Auto Property
        // Type "prop" and Press "tab" key

        /// <summary>
        /// StudentID Property used to hold a Student's ID of instance of <see cref="StudentDetails"/>.
        /// </summary>
        public string StudentID { get; }

        /// <summary>
        /// StudentName Property used to hold Student's Name of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// FatherName Property used to hold Student's Father Name of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        public string FatherName { get; set; }

        /// <summary>
        /// DOB Property used to hold Date of Birth of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gender Property used to hold Gender of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Physics Property used to hold Physics mark of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        /// <value>0 to 100</value>
        public int Physics { get; set; }

        /// <summary>
        /// Chemistry Property used to hold Chemistry mark of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        /// <value>0 to 100</value>
        public int Chemistry { get; set; }

        /// <summary>
        /// Maths Property used to hold Maths mark of a instance of <see cref="StudentDetails"/>.
        /// </summary>
        /// <value>0 to 100</value>
        public int Maths { get; set; }

        /// <summary>
        /// Constructor StudentDetails used to initialize default values to its Properties.
        /// </summary>
        public StudentDetails()
        {
            s_studentID++;
            StudentID="SF"+s_studentID;
        }

        /// <summary>
        /// Constructor StudentDetails used to initialize parameter values to its Properties
        /// </summary>
        /// <param name="studentName">studentName parameter used to assign its value to its respected Property.</param>
        /// <param name="fatherName">fatherName parameter used to assign its value to its respected Property.</param>
        /// <param name="dob">dob parameter used to assign its value to its respected Property.</param>
        /// <param name="gender">gender parameter used to assign its value to its respected Property.</param>
        /// <param name="physics">physics parameter used to assign its value to its respected Property.</param>
        /// <param name="chemistry">chemistry parameter used to assign its value to its respected Property.</param>
        /// <param name="maths">maths parameter used to assign its value to its respected Property.</param>
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int chemistry,int maths)
        {
            s_studentID++;
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            this.DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }

        /// <summary>
        /// This method is used to check whether the instance of <see cref="StudentDetails"/> is eligible for admission based on Marks.
        /// </summary>
        /// <param name="Physics">Physics parameter used to assign its value to its respected Property.</param>
        /// <param name="Chemistry">Chemistry parameter used to assign its value to its respected Property.</param>
        /// <param name="Maths">Maths parameter used to assign its value to its respected Property.</param>
        /// <returns>returns true if eligible, else false.</returns>
        public bool CheckEligibility(int Physics,int Chemistry,int Maths)
        {
            double average=(Physics+Chemistry+Maths)/3.0;
            if(average>=75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}