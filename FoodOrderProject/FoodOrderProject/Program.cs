using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Local Variables
            string curLine = "";
            string fileDelimiter = ",";
            string csvMenuPath = "Menu.csv";
            string csvOrderPath = "Order.csv";
            string csvHistoryPath = "CustomerHistory.csv";

            // Create a List (A type of array) for all our people!
            List<MenuItems> menu = new List<MenuItems>();
            List<Customer> customer = new List<Customer>();
            try
            {
                // Open the file
                using (StreamReader bufferFile = new StreamReader(csvMenuPath))
                {
                    bufferFile.ReadLine();
                    while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                    {
                        string[] item = curLine.Split(fileDelimiter);
                        menu.Add(new MenuItems(item[0], item[1], item[2], item[3], item[4]));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An error occurred while reading the file.");
            }
            menu.Sort();
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{menu[i].ToString()}");
                }

            Console.WriteLine("What type of user are you?");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Delivery");
            Console.WriteLine("4. Exit");
            int typeInput;
            do
            {
                Console.WriteLine("Pick An Option");
                typeInput = Convert.ToInt32(Console.ReadLine());
                switch (typeInput)
                {

                    case 1:
                        Customer register = new Customer();
                        register.RegisterCustomer();
                        customer.Add(new Customer(register.customerID, register.name, register.usertype, register.contact, register.address));

                        Console.WriteLine("What would you like to order from the menu?");
                        int userOrder = Convert.ToInt32(Console.ReadLine());
                        int newID = 1;
                        using (StreamReader bufferFile = new StreamReader(csvOrderPath))
                        {
                            bufferFile.ReadLine();
                            while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                            {
                                if (curLine.Length > 0)
                                {
                                    newID = newID + 1;
                                }
                            }
                        }
                        userOrder = userOrder - 1;
                        Orders order = new Orders();
                        order.orderID = Convert.ToString(newID);
                        order.name = menu[userOrder].name;
                        order.description = menu[userOrder].description;
                        order.price = menu[userOrder].price;
                        order.category = menu[userOrder].category;
                        order.orderStatus = "In Preparation";
                        Console.WriteLine("Would you like to make any modifications to your order?");
                        order.orderMod = Console.ReadLine();

                        using (StreamWriter writer = new StreamWriter(csvOrderPath, append : true))
                        {
                            writer.WriteLine(order.orderID + "," + order.name + "," + order.description + "," + order.price + "," + order.category + "," + order.orderStatus + "," + order.orderMod + "," + register.address);
                         }

                        using (StreamWriter writer = new StreamWriter(csvHistoryPath, append : true))
                        {
                            writer.WriteLine(register.name + "," + order.name);
                        }
                        break;

                    case 2:
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1. Add To Menu");
                        Console.WriteLine("2. Update Menu");
                        Console.WriteLine("3. Delete Item");
                        Console.WriteLine("4. Go Back");
                        int adminChoice;
                        do
                        {
                            Console.WriteLine("Pick An Option");
                            adminChoice = Convert.ToInt32(Console.ReadLine());
                            switch (adminChoice) 
                            {
                                case 1:
                                    MenuItems add = new MenuItems();
                                    add.AddMenu();
                                    menu.Add(new MenuItems(add.itemID, add.name, add.description, add.price, add.category));
                                    using (StreamWriter writer = new StreamWriter(csvMenuPath, append: true))
                                    {
                                        writer.WriteLine(add.itemID + "," + add.name + "," + add.description + "," + add.price + "," + add.category);
                                    }
                                    break;

                                case 2:
                                    MenuItems update = new MenuItems();
                                    update.UpdateMenu();
                                    int updateID = (Convert.ToInt32(update.itemID) - 1);
                                    menu.RemoveAt(updateID);
                                    menu.Add(new MenuItems(update.itemID, update.name, update.description, update.price, update.category));
                                    System.IO.File.WriteAllText(csvMenuPath, string.Empty);
                                    using (StreamWriter writer = new StreamWriter(csvMenuPath, append: true))
                                    {
                                        writer.WriteLine();
                                        for (int i = 0; i < menu.Count; i++)
                                        {
                                            writer.WriteLine($"{menu[i].ToString()}");
                                        }
                                    }
                                    menu.Clear();
                                    using (StreamReader bufferFile = new StreamReader(csvMenuPath))
                                    {
                                        bufferFile.ReadLine();
                                        while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                                        {
                                            string[] item = curLine.Split(fileDelimiter);
                                            menu.Add(new MenuItems(item[0], item[1], item[2], item[3], item[4]));
                                        }
                                    }
                                    menu.Sort();
                                    for (int i = 0; i < menu.Count; i++)
                                    {
                                        Console.WriteLine($"{menu[i].ToString()}");
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("What do you want to remove?");
                                    int remove = Convert.ToInt32(Console.ReadLine());
                                    remove = remove - 1;
                                    menu.RemoveAt(remove);
                                    System.IO.File.WriteAllText(csvMenuPath, string.Empty);
                                        using (StreamWriter writer = new StreamWriter(csvMenuPath, append: true))
                                        {
                                            writer.WriteLine();
                                            for (int i = 0; i < menu.Count; i++)
                                            {
                                                writer.WriteLine($"{menu[i].ToString()}");
                                            }
                                        }
                                    break;

                                case 4:
                                    Console.WriteLine("Goodbye");
                                    break;

                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }
                        } while (adminChoice != 4);

                        break;

                    case 3:
                        Boolean ordersYes = false;
                        List<Orders> orders = new List<Orders>();
                        using (StreamReader bufferFile = new StreamReader(csvOrderPath))
                        {
                            while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                            {
                                if (curLine.Length > 0)
                                {
                                    string[] item = curLine.Split(fileDelimiter);
                                    orders.Add(new Orders(item[0], item[1], item[2], item[3], item[4], item[5], item[6], item[7]));
                                    ordersYes = true;
                                }
                            }
                        }

                        if (ordersYes == true)
                        {
                            for (int i = 0; i < orders.Count; i++)
                            {
                                orders[i].orderStatus = "Out for Delivery";
                                Console.WriteLine($"{orders[i].ToString()}");
                                Console.WriteLine("What is the address you want to deliver to?");
                                string deliveryAddress;
                                do
                                {
                                    deliveryAddress = Console.ReadLine();
                                    if (deliveryAddress != orders[i].customerAddress)
                                    {
                                        Console.WriteLine("Try again");
                                    }
                                } while (deliveryAddress != orders[i].customerAddress);
                                orders[i].orderStatus = "Received";
                                Console.WriteLine($"{orders[i].ToString()}");
                            }
                            System.IO.File.WriteAllText(csvOrderPath, string.Empty);
                        }

                        Console.WriteLine("There are no orders");
                        break;

                    case 4:
                        Console.WriteLine("Goodbye");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (typeInput != 4);
        }
    }
}
