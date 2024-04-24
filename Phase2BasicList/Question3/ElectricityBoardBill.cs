using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question3
{
    public class ElectricityBoardBill
    {
        private static int s_meterID=1000;
        private static int s_billID=10400;
        public string MeterID { get; }
        public int BillId { get; }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string MailID { get; set; }
        public int UnitsUsed { get; set; }

        public ElectricityBoardBill()
        {
            s_meterID++;
            MeterID="EB"+s_meterID;
            BillId=s_billID++;
        }

        public ElectricityBoardBill(string userName,long phoneNumber,string mailID)
        {
            s_meterID++;
            MeterID="EB"+s_meterID;
            BillId=s_billID++;

            UserName=userName;
            PhoneNumber=phoneNumber;
            MailID=mailID;
        }

        public double BillCalculator()
        {
          double billAmount=UnitsUsed*5.0;
          return billAmount;
        }
    }
}