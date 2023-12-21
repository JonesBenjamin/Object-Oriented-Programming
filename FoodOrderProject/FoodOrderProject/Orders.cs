using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderProject
{
    public class Orders : MenuItems
    {
        public string orderID { get; set; }
        public string orderStatus { get; set; }
        public string orderMod { get; set; }
        public string customerAddress { get; set; }

        public Orders()
        {
            this.orderID = "Unknown";
            this.itemID = "Unknown";
            this.name = "Unknown";
            this.description = "Unknown";
            this.price = "Unknown";
            this.category = "Unknown";
            this.orderStatus = "Unknown";
            this.orderMod = "Unknown";
            this.customerAddress = "Unknown";
        }

        public Orders(string orderID, string name, string description, string price, string category, string orderStatus, string orderMod, string customerAddress)
        {
            this.orderID = orderID;
            this.name = name;
            this.description = description;
            this.price = price;
            this.category = category;
            this.orderStatus = "Out for Delivery";
            this.orderMod = orderMod;
            this.customerAddress = customerAddress;
        }
    }
}
