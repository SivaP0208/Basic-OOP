using System;
using System.Collections.Generic;
namespace SynCartECommerceApplication;
class Program
{
    // Creating Lists for Products, Customers, Order Details
    static List<ProductDetails> productsList=new List<ProductDetails>();
    static List<CustomerDetails> customersList=new List<CustomerDetails>();
    static List<OrderDetails> ordersList=new List<OrderDetails>();
    public static void Main(string[] args)
    {
        // Adding Default Product Details in List
        productsList.Add(new ProductDetails("Mobile(Samsung)",10000,10,3));
        productsList.Add(new ProductDetails("Tablet(Lenovo)",15000,5,2));
        productsList.Add(new ProductDetails("Camera(Sony)",20000,3,4));
        productsList.Add(new ProductDetails("iPhone",50000,5,6));
        productsList.Add(new ProductDetails("Laptop(Lenovo I3)",40000,3,3));
        productsList.Add(new ProductDetails("HeadPhone(Boat)",1000,5,2));
        productsList.Add(new ProductDetails("Speakers(Boat)",500,4,2));

        // Adding Default Customer Details in List
        customersList.Add(new CustomerDetails("Ravi","Chennai",9885858588L,50000,"ravi@mail.com"));
        customersList.Add(new CustomerDetails("Baskaran","Chennai",9888475757L,60000,"baskaran@mail.com"));

        // Adding Default Order Details in List
        ordersList.Add(new OrderDetails("CID1001","PID101",20000,DateTime.Now,2,OrderStatus.Ordered));
        ordersList.Add(new OrderDetails("CID1002","PID103",40000,DateTime.Now,2,OrderStatus.Ordered));

        bool exit=true;
        do
        {
            Console.WriteLine("\n\t\tSynCart E-Commerce Application");
            Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit\n");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                {
                    Console.WriteLine("\t\tCustomer Registration");
                    CustomerDetails customer=Registration();
                    customersList.Add(customer);
                    Console.WriteLine($"\n\tRegistration Successfull and Customer ID is {customer.CustomerID}");
                    break;
                }
                case 2:
                {
                    Console.Write("Enter your Customer ID : ");
                    string userEnteredCustomerID=Console.ReadLine();
                    bool isCustomerValid=true;
                    foreach(CustomerDetails customer in customersList)
                    {
                        if(Validate(customer.CustomerID,userEnteredCustomerID))
                        {
                            SubMenu(customer);
                            isCustomerValid=false;
                        }
                    }
                    if(isCustomerValid)
                    {
                        Console.WriteLine("\tInvalid Customer ID or Registration not Completed");
                    }
                    break;
                }
                case 3:
                {
                    exit=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("\t\tInvalid Input");
                    break;
                }
            }
        } while (exit);
    }

    // Method for Registration
    public static CustomerDetails Registration()
    {
        CustomerDetails customer=new CustomerDetails();
        Console.Write("Enter your Name : ");
        customer.CustomerName=Console.ReadLine();
        Console.Write("Enter your City : ");
        customer.City=Console.ReadLine();
        Console.Write("Enter your Mobile Number : ");
        bool isMobileValid=long.TryParse(Console.ReadLine(),out long mobile);
        while(!isMobileValid)
        {
            Console.Write("Invalid Mobile Number please enter again : ");
            isMobileValid=long.TryParse(Console.ReadLine(),out mobile);
        }
        customer.MobileNumber=mobile;
        Console.Write("Enter your Mail ID : ");
        bool isMailValid=true;
        string mail=Console.ReadLine();
        while(isMailValid)
        {
            if(mail.Contains("@gmail.com"))
            {
                isMailValid=false;
                customer.MailID=mail;
                break;
            }
            else
            {
                isMailValid=true;
                Console.Write("Invalid Mail ID please enter again : ");
                mail=Console.ReadLine();
            }
        }
        Console.Write("Enter your Wallet Balance : ");
        bool isAmountValid=double.TryParse(Console.ReadLine(),out double balance);
        while(!isAmountValid)
        {
            Console.Write("Invalid Amount please enter again : ");
            isAmountValid=double.TryParse(Console.ReadLine(),out balance);
        }
        customer.WalletBalance=balance;

        return customer;
    }

    // Method for Login Validation
    public static bool Validate(string customerID,string userEnteredCustomerID)
    {
        if(customerID.ToLower()==(userEnteredCustomerID.Trim()).ToLower())
        {
            return true;
        }
        else
        {
            return false;
        }
    }  

    // Method for Sub-Menu
    public static void SubMenu(CustomerDetails customer)
    {
        bool mainMenu=true;
        do
        {
            Console.WriteLine($"\n\t\tWelcome {customer.CustomerName}");
            Console.WriteLine("a. Purchase\nb. Order History\nc. Cancel Order");
            Console.WriteLine("d. Wallet Balance\ne. Wallet Recharge\nf. Back to Menu\n");
            switch(char.Parse(Console.ReadLine()))
            {
                case 'a':
                {
                    Purchase(customer);
                    break;
                }
                case 'b':
                {
                    bool isOrderAvailable=true;
                    Console.WriteLine("\n\t\tOrder Details");
                    foreach(OrderDetails order in ordersList)
                    {
                        if(customer.CustomerID==order.CustomerID)
                        {
                            isOrderAvailable=false;
                            Console.Write($"Order ID : {order.OrderID} | Product ID : {order.ProductID} | Total Price : {order.TotalPrice} | ");
                            Console.WriteLine($"Purchase Date : {(order.PurchaseDate).ToString("dd/MM/yyyy")} | Quantity : {order.Quantity} | Order Status : {order.OrderStatus}");
                        }
                    }
                    if(isOrderAvailable)
                    {
                        Console.WriteLine("\n\tNo Purchases have been made to show order details");
                    }
                    break;
                }
                case 'c':
                {
                    Console.WriteLine("\t\tYour Order History");
                    Cancel(customer);
                    break;
                }
                case 'd':
                {
                    Console.WriteLine($"\n\tYour Wallet Balance is {customer.WalletBalance}");
                    break;
                }
                case 'e':
                {
                    Console.Write("\nDo you want to recharge your Wallet (yes/no) : ");
                    string userWish=Console.ReadLine();
                    if((userWish.Trim()).ToLower()=="yes")
                    {
                        Console.Write("Enter the amount to recharge your Wallet : ");
                        bool isValidAmount=double.TryParse(Console.ReadLine(),out double rechargeAmount);
                        while(rechargeAmount<0 || !isValidAmount)
                        {
                            Console.Write("Invalid Amount please enter again : ");
                            isValidAmount=double.TryParse(Console.ReadLine(),out rechargeAmount);
                        }
                        customer.WalletBalance+=rechargeAmount;
                        Console.WriteLine($"\n\tYour Updated Wallet Balance is {customer.WalletBalance}");
                    }
                    else if((userWish.Trim()).ToLower()=="no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\t\tInvalid Input");
                    }
                    break;
                }
                case 'f':
                {
                    mainMenu=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("\t\tInvalid Input");
                    break;
                }
            }
        } while (mainMenu);
    }

    // Method for Purchasing
    public static void Purchase(CustomerDetails customer)
    {
        // Listing the Available Products to User
        Console.WriteLine("\t\t\t\tAvailable Products");
        foreach(ProductDetails product in productsList)
        {
            Console.Write($"Product ID : {product.ProductID} | Product Name : {product.ProductName} | ");
            Console.WriteLine($"Available Stocks : {product.StockAvailable} | Price Per Quantity : {product.Price} | Shipping Duration : {product.ShippingDuration}");
        }

        Console.Write("\nSelect the Product ID to Purchase : ");
        string userEnteredProductID=Console.ReadLine();
        bool isProductIDValid=true;
        foreach(ProductDetails product in productsList)
        {
            if(product.ProductID.ToLower()==(userEnteredProductID.Trim()).ToLower())
            {
                isProductIDValid=false;
                Console.Write("Enter the Quantity to Purchase : ");
                bool isQuantityValid=int.TryParse(Console.ReadLine(),out int quantity);
                while(!isQuantityValid)
                {
                    Console.Write("Invalid Quantity please enter again : ");
                    isQuantityValid=int.TryParse(Console.ReadLine(),out quantity);
                }
                if(product.StockAvailable>=quantity)
                {
                    double totalPrice=(quantity*product.Price)+50;
                    if(customer.WalletBalance>=totalPrice)
                    {
                        customer.DeductBalance(totalPrice);
                        product.StockAvailable-=quantity;
                        OrderDetails order=new OrderDetails(customer.CustomerID,product.ProductID,totalPrice,DateTime.Now,quantity,OrderStatus.Ordered);
                        ordersList.Add(order);
                        Console.WriteLine($"\n\tOrder Placed Successfully. Order ID : {order.OrderID}");
                        Console.WriteLine($"\t  Your order will be delivered on {(order.PurchaseDate.AddDays(product.ShippingDuration)).ToString("dd/MM/yyyy")}");
                    }
                    else
                    {
                        Console.WriteLine("\nInsufficient Wallet Balance. Please recharge your Wallet and do purchase again");
                    }
                }
                else
                {
                    Console.WriteLine($"\nRequired Quantity is not available. Current availability is {product.StockAvailable}");
                }
            }
        }
        if(isProductIDValid)
        {
            Console.WriteLine("\t\tInvalid Product ID");
        }
    }

    // Method for Cancel the Order
    public static void Cancel(CustomerDetails customer)
    {
        if(ordersList!=null)
        {
            bool isOrderAvailable=false;

            // Listing the Orders Purchased by the logged User
            foreach(OrderDetails order in ordersList)
            {
                if(order.CustomerID==customer.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                {
                    Console.Write($"Order ID : {order.OrderID} | Product ID : {order.ProductID} | Total Price : {order.TotalPrice} | ");
                    Console.WriteLine($"Purchase Date : {(order.PurchaseDate).ToString("dd/MM/yyyy")} | Quantity : {order.Quantity} | Order Status : {order.OrderStatus}");
                    isOrderAvailable=true;
                }
            }

            if(isOrderAvailable)
            {
                Console.Write("Enter the Order ID to Cancel : ");
                string userEnteredOrderID=Console.ReadLine();
                bool isOrderIDValid=true;
                foreach(OrderDetails order in ordersList)
                {
                    if(order.OrderID.ToLower()==(userEnteredOrderID.Trim()).ToLower())
                    {
                        isOrderIDValid=false;
                        foreach(ProductDetails product in productsList)
                        {
                            if(order.ProductID==product.ProductID)
                            {
                                product.StockAvailable+=order.Quantity;
                            }
                        }
                        order.OrderStatus=OrderStatus.Cancelled;
                        customer.WalletRecharge((order.TotalPrice)-50);
                        Console.WriteLine($"\t\tOrder : {order.OrderID} Cancelled Successfully");
                    }
                }
                if(isOrderIDValid)
                {
                    Console.WriteLine("\n\t\tInvalid Order ID");
                }
            }
            else
            {
                Console.WriteLine("\t\tThere is no orders to cancel");    
            }
        }
        else
        {
            Console.WriteLine("\t\tThere is no orders to cancel");
        }
    }
} 
