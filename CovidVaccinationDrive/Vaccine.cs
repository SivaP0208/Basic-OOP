using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccinationDrive
{
    public enum VaccineName{Covishield,Covaccine}
    public class Vaccine
    {
        private static int s_vaccineID=2000;
        public string VaccineID { get; }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        public Vaccine()
        {
            VaccineID="CID"+(++s_vaccineID);
        }
        
        public Vaccine(VaccineName vaccineName,int noOfDoseAvailable)
        {
            VaccineID="CID"+(++s_vaccineID);
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
    }
}