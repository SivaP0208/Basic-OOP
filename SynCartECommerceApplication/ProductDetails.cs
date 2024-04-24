using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartECommerceApplication
{
    public class ProductDetails
    {
        // Field
        private static int s_productID=100;

        // Properties
        public string ProductID { get; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int StockAvailable { get; set; }
        public int ShippingDuration { get; set; }

        // Constructors
        public ProductDetails()
        {
            // Auto Increment ID
            s_productID++;
            ProductID="PID"+s_productID;
        }

        public ProductDetails(string productName,double price,int stockAvailable,int shippingDuration)
        {
            // Auto Increment ID
            s_productID++;
            ProductID="PID"+s_productID;

            ProductName=productName;
            Price=price;
            StockAvailable=stockAvailable;
            ShippingDuration=shippingDuration;
        }
    }
}