using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartECommerceApplication
{
    public class CustomerDetails
    {
        // Field
        private static int s_customerID=1000;

        // Properties
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string MailID { get; set; }

        // Constructors
        public CustomerDetails()
        {
            // Auto Increment ID
            s_customerID++;
            CustomerID="CID"+s_customerID;
        }

        public CustomerDetails(string customerName,string city,long mobileNumber,double walletBalance,string mailID)
        {
            // Auto Increment ID
            s_customerID++;
            CustomerID="CID"+s_customerID;

            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            MailID=mailID;
        }

        // Methods
        public void WalletRecharge(double rechargeAmount)
        {
            WalletBalance+=rechargeAmount;
            Console.WriteLine($"\n\tWallet is Recharged with Amount {rechargeAmount} and Available Balance is {WalletBalance}");
        }

        public void DeductBalance(double deductAmount)
        {
            if(WalletBalance>=deductAmount)
            {
                WalletBalance-=deductAmount;
            }
        }
    }
}