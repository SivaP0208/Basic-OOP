using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibraryManagement
{
    public static class OperationsClass
    {
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowList=new List<BorrowDetails>();

        public static void AddDefaultData()
        {
            userList.Add(new UserDetails("Ravichandran",Gender.Male,Department.EEE,9938388333L,"ravi@gmail.com",100));
            userList.Add(new UserDetails("Priyadharshini",Gender.Female,Department.CSE,9944444455L,"priya@gmail.com",150));

            bookList.Add(new BookDetails("C#","Author1",3));
            bookList.Add(new BookDetails("HTML","Author2",5));
            bookList.Add(new BookDetails("CSS","Author1",3));
            bookList.Add(new BookDetails("JS","Author1",3));
            bookList.Add(new BookDetails("TS","Author2",3));

            borrowList.Add(new BorrowDetails("BID1001","SF3001",new DateTime(2023,09,10),2,Status.Borrowed,0));
            borrowList.Add(new BorrowDetails("BID1003","SF3001",new DateTime(2023,09,12),1,Status.Borrowed,0));
            borrowList.Add(new BorrowDetails("BID1004","SF3001",new DateTime(2023,09,14),1,Status.Returned,16.0));
            borrowList.Add(new BorrowDetails("BID1002","SF3002",new DateTime(2023,09,11),2,Status.Borrowed,0));
            borrowList.Add(new BorrowDetails("BID1005","SF3002",new DateTime(2023,09,09),1,Status.Returned,20));
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t******** Syncfusion College Library Management ********");
            bool exit=true;
            do
            {
                Console.WriteLine("\n\t\tMain Menu");
                Console.WriteLine("1. User Registration\n2. User Login\n3. Exit\n");
                Console.Write("\nSelect an Option : ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            Console.WriteLine("\n\t\tUser Registratation");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n\t\tLogin");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            exit=false;
                            Console.WriteLine("\n\t\t Thank You !\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\n\t\tInvalid Input");
                            break;
                        }
                }
            } while (exit);
        }

        public static void UserRegistration()
        {
            UserDetails user=new UserDetails();
            Console.Write("Enter your Name : ");
            user.UserName=Console.ReadLine();
            Console.Write("Enter your Gender (Male/Female/Transgender) : ");
            user.Gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Department (EEE/ECE/CSE) : ");
            user.Department=Enum.Parse<Department>(Console.ReadLine(),true);
            Console.Write("Enter your Mobile Number : ");
            bool isValidMobile=long.TryParse(Console.ReadLine(),out long mobileNumber);
            while(!(mobileNumber>=6000000000 && mobileNumber<=9999999999) || !isValidMobile)
            {
                Console.Write("Invalid Mobile Number Please enter again : ");
                isValidMobile=long.TryParse(Console.ReadLine(),out mobileNumber);
            }
            user.MobileNumber=mobileNumber;
            Console.Write("Enter your Mail Id : ");
            string mailID=Console.ReadLine().ToLower();
            bool isValidMail=true;
            while(isValidMail)
            {
                if(mailID.Contains("@gmail.com"))
                {
                    isValidMail=false;
                    user.MailID=mailID;
                }
                else
                {
                    Console.Write("Invalid Mail ID please enter again : ");
                    mailID=Console.ReadLine().ToLower();
                }
            }
            Console.Write("Enter your Wallet Balance : ");
            double walletBalance=double.Parse(Console.ReadLine());
            bool isValidAmount=true;
            while(isValidAmount)
            {
                if(walletBalance>0)
                {
                    isValidAmount=false;
                    user.WalletBalance=walletBalance;
                }
                else
                {
                    Console.Write("Invalid Amount please enter again : ");
                    walletBalance=double.Parse(Console.ReadLine());
                }
            }

            userList.Add(user);

            Console.WriteLine($"\n\t User Registered Successfully and Your User ID is : {user.UserID}");
        }

        public static void Login()
        {
            Console.Write("Enter your User ID : ");
            string loginID=Console.ReadLine().ToUpper();
            bool isValidLogin=true;
            foreach(UserDetails user in userList)
            {
                if(user.UserID.Equals(loginID))
                {
                    isValidLogin=false;
                    Console.WriteLine("\n\t   Login Successfull");
                    SubMenu(user);
                    break;
                }
            }
            if(isValidLogin)
            {
                Console.WriteLine("\n\tInvalid User ID or Registration not Completed");
            }
        }

        public static void SubMenu(UserDetails user)
        {
            Console.WriteLine($"\n\t Welcome {user.UserName}");
            bool mainMenu=true;
            do
            {
                Console.WriteLine("\n\t        Sub Menu");
                Console.WriteLine("1. Borrow Book\n2. Show Borrowed History\n3. Return Books\n4. Wallet Recharge\n5. Exit\n");
                Console.Write("\nSelect an Option : ");
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                    {
                        Console.WriteLine("\n\t\tBorrow Book\n");
                        BorrowBook(user);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("\n\t\t\tBorrowed History\n");
                        ShowBorrowedHistory(user);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("\n\t\t\tReturn Books\n");
                        ReturnBooks(user);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("\n\t Wallet Recharge");
                        WalletRecharge(user);
                        break;
                    }
                    case 5:
                    {
                        mainMenu=false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("\n\t\tInvalid Input");
                        break;
                    }
                }
            } while (mainMenu);
        }

        public static void BorrowBook(UserDetails user)
        {
            if(bookList!=null)
            {
                Console.WriteLine($"|  {"Book ID",-9}| {"Book Name",-10}| {"Author Name",-12}| {"Book Count",-11}|");
                foreach(BookDetails book in bookList)
                {
                    if(book.BookCount>0)
                    {
                        Console.WriteLine($"|  {book.BookID,-9}|   {book.BookName,-8}|   {book.AuthorName,-10}|     {book.BookCount,-7}|");
                    }
                }
                Console.WriteLine();
                Console.Write("Enter Book ID to Borrow : ");
                string bookID=Console.ReadLine().ToUpper();
                bool isValidBook=true;
                foreach(BookDetails book in bookList)
                {
                    if(book.BookID.Equals(bookID))
                    {
                        isValidBook=false;
                        Console.Write("Enter the Count of Book to Borrow : ");
                        int booksNeedToBorrow;
                        while(!int.TryParse(Console.ReadLine(),out booksNeedToBorrow))
                        {
                            Console.Write("Invalid number please enter again : ");
                        }
                        if(book.BookCount>=booksNeedToBorrow)
                        {
                            int noOfBooksBorrowed=0;
                            foreach(BorrowDetails borrow in borrowList)
                            {
                                if(user.UserID.Equals(borrow.UserID) && borrow.Status==Status.Borrowed)
                                {
                                    noOfBooksBorrowed+=borrow.BorrowBookCount;
                                }
                            }
                            if(noOfBooksBorrowed<3)
                            {
                                if(booksNeedToBorrow<=(3-noOfBooksBorrowed))
                                {
                                    BorrowDetails borrow=new BorrowDetails();
                                    borrow.BookID=book.BookID;
                                    borrow.UserID=user.UserID;
                                    borrow.BorrowedDate=DateTime.Now;
                                    borrow.BorrowBookCount=booksNeedToBorrow;
                                    borrow.Status=Status.Borrowed;
                                    borrow.PaidFineAmount=0.0;
                                    book.BookCount-=booksNeedToBorrow;

                                    borrowList.Add(borrow);

                                    Console.WriteLine("\n\t Book Borrowed Successfully");

                                }
                                else
                                {
                                    Console.WriteLine($"\n\t\t\tYou can have maximum of 3 Borrowed books.\n\tYou're already borrowed books count is {noOfBooksBorrowed} and Requested Count is {booksNeedToBorrow}, Which exceeds 3");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\t You have Borrowed 3 Books Already");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\t Books are Not Available for the selected count");
                            DateTime availableDate;
                            foreach(BorrowDetails borrow in borrowList)
                            {
                                if(book.BookID.Equals(borrow.BookID))
                                {
                                    availableDate=borrow.BorrowedDate.AddDays(15);
                                    Console.WriteLine($"\n\t The Book will be available on {availableDate}");
                                    break;
                                }
                            }
                        }
                    }
                }
                if(isValidBook)
                {
                    Console.WriteLine("\n\t Invalid Book ID, Please enter Valid ID");
                }
            }
            else
            {
                Console.WriteLine("\n\tThere is no Books Available");
            }
        }

        public static void ShowBorrowedHistory(UserDetails user)
        {
            bool isUserBorrowed=false;
            foreach(BorrowDetails borrow in borrowList)
            {
                if(user.UserID.Equals(borrow.UserID))
                {
                    isUserBorrowed=true;
                }
            }
            if(isUserBorrowed)
            {
                Console.WriteLine($"| {"Borrow ID",-10} |  {"Book ID",-9} |  {"User ID",-9}| {"Borrowed Date",-14} | {"Borrowed Book Count",-20} |  {"Status",-7} | {"Paid Fine Amount",-17} |");
                bool isBorrowed=true;
                foreach(BorrowDetails borrow in borrowList)
                {
                    if(user.UserID.Equals(borrow.UserID))
                    {
                        isBorrowed=false;
                        Console.WriteLine($"| {borrow.BorrowID,-10} | {borrow.BookID,-10} | {borrow.UserID,-9} |   {(borrow.BorrowedDate).ToString("dd/MM/yyyy"),-12} |         {borrow.BorrowBookCount,-12} | {borrow.Status,-8} |       {Math.Round(borrow.PaidFineAmount),-11} |");
                    }
                }
                if(isBorrowed)
                {
                    Console.WriteLine("\n\t\tNo Books are Borrowed by You");
                }
            }
            else
            {
                Console.WriteLine("\t\tThere is no Borrowed History to Show");
            }
        }

        public static void ReturnBooks(UserDetails user)
        {
            bool isUserBorrowed=false;
            foreach(BorrowDetails borrow in borrowList)
            {
                if(user.UserID.Equals(borrow.UserID))
                {
                    isUserBorrowed=true;
                    break;
                }
            }
            if(isUserBorrowed)
            {
                Console.WriteLine($"| {"Borrow ID",-10} |  {"Book ID",-9} |  {"User ID",-9}| {"Borrowed Date",-14} | {"Borrowed Book Count",-20} |  {"Status",-7} | {"Paid Fine Amount",-17} |");
                bool isBorrowed=true;
                double fineAmount = 0;
                foreach(BorrowDetails borrow in borrowList)
                {
                    if(user.UserID.Equals(borrow.UserID))
                    {
                        isBorrowed=false;
                        DateTime returnDate = (borrow.BorrowedDate).AddDays(15);
                        Console.WriteLine($"| {borrow.BorrowID,-10} | {borrow.BookID,-10} | {borrow.UserID,-9} |   {(borrow.BorrowedDate).ToString("dd/MM/yyyy"),-12} |         {borrow.BorrowBookCount,-12} | {borrow.Status,-8} |       {Math.Round(borrow.PaidFineAmount),-11} |");
                    }
                }
                if(isBorrowed)
                {
                    Console.WriteLine("\n\t\tNo Books are Borrowed by you");
                }
                else
                {
                    Console.Write("\nEnter the Borrow ID to return : ");
                    string borrowID=Console.ReadLine().ToUpper();
                    bool isValidBorrow=true;
                    foreach(BorrowDetails borrow in borrowList)
                    {
                        if(borrow.BorrowID.Equals(borrowID) && user.UserID.Equals(borrow.UserID) && borrow.Status==Status.Borrowed)
                        {
                            isValidBorrow=false;
                            DateTime returnDate=(borrow.BorrowedDate).AddDays(15);
                            if(returnDate<DateTime.Now)
                            {
                                TimeSpan span=DateTime.Now-returnDate;
                                fineAmount+=span.TotalDays*1.0;
                                if(user.WalletBalance>=fineAmount)
                                {
                                    user.WalletBalance-=fineAmount;
                                    borrow.Status=Status.Returned;
                                    borrow.PaidFineAmount=fineAmount;

                                    foreach(BookDetails book in bookList)
                                    {
                                        if(borrow.BookID.Equals(book.BookID))
                                        {
                                            book.BookCount+=borrow.BorrowBookCount;
                                            break;
                                        }
                                    }

                                    Console.WriteLine("\n\t Book Returned Successfully");
                                }
                                else
                                {
                                    Console.WriteLine("\n\t Insufficient Balance. Please recharge and proceed");
                                }
                            }
                            else
                            {
                                borrow.Status=Status.Returned;
                                foreach (BookDetails book in bookList)
                                {
                                    if (borrow.BookID.Equals(book.BookID))
                                    {
                                        book.BookCount += borrow.BorrowBookCount;
                                        break;
                                    }
                                }

                                Console.WriteLine("\n\t Book Returned Successfully");
                            }
                            break;
                        }
                    }
                    if(isValidBorrow)
                    {
                        Console.WriteLine("\n\tInvalid Borrow ID or Book Returned Already ");
                    }

                }

            }
            else
            {
                Console.WriteLine("\n\t\tThere is no Borrowed History to Show");
            }
           
        }

        public static void WalletRecharge(UserDetails user)
        {
            Console.Write("\nDo you want to recharge your Wallet (yes/no) : ");
            string userWish=Console.ReadLine().ToLower();
            switch(userWish)
            {
                case "yes":
                {
                    Console.Write("Enter the Amount to Recharge : ");
                    int walletBalance;
                    while(!int.TryParse(Console.ReadLine(),out walletBalance) || !(walletBalance>0))
                    {
                        Console.Write("Invalid Amount please enter again : ");
                    }
                    user.WalletBalance+=walletBalance;
                    Console.WriteLine($"\n\tYour Updated Wallet Balance is : {user.WalletBalance}");
                    break;
                }
                case "no":
                {
                    break;
                }
                default:
                {
                    Console.WriteLine("\n\t Invalid Input");
                    break;
                }
            }

        }
    }
}