using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderProject
{
    public class MenuItems : IComparable<MenuItems>
    {
        public string itemID;
        public string name;
        public string description;
        public string price;
        public string category;
        string csvMenuPath = "Menu.csv";

        public MenuItems()
        {
            this.itemID = "0";
            this.name = "Unknown";
            this.description = "Unknown";
            this.price = "0.00";
            this.category = "Unknown";
        }

        public MenuItems(string itemID, string name)
        {
            this.itemID = itemID;
            this.name = name;
            this.description = "Unknown";
            this.price = "0.00";
            this.category = "Unknown";
        }
        public MenuItems(string itemID, string name, string price)
        {
            this.itemID = itemID;
            this.name = name;
            this.description = "Unknown";
            this.price = price;
            this.category = "Unknown";
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
            string curLine = "";
            int count = 1;
            using (StreamReader reader = new StreamReader(csvMenuPath))
            {
                while ((curLine = reader.ReadLine()) != null) // While not End of File
                {
                    count = count + 1;
                }

                this.itemID = Convert.ToString(count);
            }
            Console.WriteLine("What is the item's name?");
            this.name = Console.ReadLine();
            Console.WriteLine("What is the item description?");
            this.description = Console.ReadLine();
            Console.WriteLine("What is the item price?");
            this.price = Console.ReadLine();
            Console.WriteLine("What is the category? (Starter, Main Course, Dessert)");
            this.category = Console.ReadLine();
        }

        public void UpdateMenu()
        {
            Console.WriteLine("What do you want to update?");
            int updateChoice = Convert.ToInt32(Console.ReadLine());
            this.itemID = Convert.ToString(updateChoice);
            Console.WriteLine("Name?");
            this.name = Console.ReadLine();
            Console.WriteLine("Description?");
            this.description = Console.ReadLine();
            Console.WriteLine("Price?");
            this.price = Console.ReadLine();
            Console.WriteLine("Category?");
            this.category = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(csvMenuPath, append: true))
            {
                writer.WriteLine(this.itemID + "," + this.name + "," + this.description + "," + this.price + "," + this.category);
            }
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
