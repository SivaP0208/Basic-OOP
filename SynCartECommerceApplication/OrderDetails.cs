using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartECommerceApplication
{
    // Enum for OrderStatus
    public enum OrderStatus{Default,Ordered,Cancelled}
    public class OrderDetails
    {
        // Field
        private static int s_orderID=1000;
        
        // Properties
        public string OrderID { get; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }

        // Constructors
        public OrderDetails()
        {
            // Auto Increment ID
            s_orderID++;
            OrderID="OID"+s_orderID;
        }

        public OrderDetails(string customerID,string productID,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {
            // Auto Increment ID
            s_orderID++;
            OrderID="OID"+s_orderID;

            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;
        }
    }
}