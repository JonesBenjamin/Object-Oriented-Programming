using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderProject
{
    public class MenuItems
    {
        private string itemID;
        private string name;
        private string description;
        private string price;
        private string category;

        public MenuItems()
        {
            this.itemID = " ";
            this.name = " ";
            this.description = " ";
            this.price = " ";
            this.category = " ";
        }

        public MenuItems(string itemID, string name, string description, string price, string category)
        {
            this.itemID = itemID;
            this.name = name;
            this.description = description;
            this.price = price;
            this.category = category;
        }

        public void AddMenu()
        {
            
        }

        public void UpdateMenu()
        {
            this.itemID = Console.ReadLine();
            this.name = Console.ReadLine();
            this.description = Console.ReadLine();
            this.price = Console.ReadLine();
            this.category = Console.ReadLine();
        }

        public void RemoveMenu()
        {
            
        }

        public int CompareTo(MenuItems other)
        {
            return category.CompareTo(other.category);
        }

        public override string ToString()
        {
            return $"{this.itemID},{this.name},{this.description},{this.price},{this.category}";
        }
    }
}
