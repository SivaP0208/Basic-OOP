using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public enum Gender{select,Male,Female,Transgender}
    public class BankAccount
    {
        private static int s_customerID=1000;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public DateTime DOB { get; set; }

        public BankAccount()
        {
            s_customerID++;
            CustomerID="HDFC"+s_customerID;
        }

        public BankAccount(string CustomerName,Gender Gender,long Phone, string MailID,DateTime DOB)
        {
            s_customerID++;
            CustomerID="HDFC"+s_customerID;
            this.CustomerName=CustomerName;
            this.Gender=Gender;
            this.Phone=Phone;
            this.MailID=MailID;
            this.DOB=DOB;
        }

        public void Deposit(double depositAmount)
        {
            Balance+=depositAmount;
            Console.WriteLine($"Available Balance : {Balance}");
        }
        public void Withdraw(double withdrawAmount)
        {
            if(Balance>=withdrawAmount)
            {
                Balance-=withdrawAmount;
                Console.WriteLine($"Available Balance : {Balance}");
            }
            else
            {
                Console.WriteLine($"Insufficient Balance ! Available Balance is : {Balance}");
            }
        }
    }
}