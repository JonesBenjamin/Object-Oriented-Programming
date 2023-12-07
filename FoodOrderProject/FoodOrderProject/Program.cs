using System;
using System.Collections.Generic;
using System.Linq;
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
            string[] item;
            string csvMenuPath = "Menu.csv";
            string csvOrderPath = "Order.csv";
            string csvHistoryPath = "CustomerHistory.csv";
            string csvCustomerPath = "Customers.csv";
            
            List<MenuItems> menu = new List<MenuItems>();
            List<Customer> customer = new List<Customer>();
            try
            {
                using (StreamReader bufferFile = new StreamReader(csvMenuPath))
                {
                    while ((curLine = bufferFile.ReadLine()) != null)
                    {
                        item = curLine.Split(fileDelimiter);
                        menu.Add(new MenuItems(item[1], item[2], item[3], item[4], item[5]));
                    }
                }

                using (StreamReader bufferFile = new StreamReader(csvCustomerPath))
                {
                    while ((curLine = bufferFile.ReadLine()) != null)
                    {
                        item = curLine.Split(fileDelimiter);
                        customer.Add(new Customer(item[1], item[2], item[3], item[4], item[5]));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // No File found
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                // Can't read file
                Console.WriteLine("An error occurred while reading the file.");
            }
            // Sort the list of items
            menu.Sort();
            // Print the sorted list of items
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1},{menu[i].ToString()}");
            }

            Console.WriteLine("What type of user are you?");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Delivery");
            Console.WriteLine("4. Exit");
            int typeInput;
            do
            {
                typeInput = Convert.ToInt32(Console.ReadLine());
                switch (typeInput)
                {

                    case 1:
                        Customer register = new Customer();
                        register.RegisterCustomer();

                        Console.WriteLine("What would you like to order from the menu?");
                        int userOrder = Convert.ToInt32(Console.ReadLine());
                        int newID = 1;
                        using (StreamReader bufferFile = new StreamReader(csvOrderPath))
                        {
                            while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                            {
                                newID = newID + 1;
                            }
                        }
                        Orders order = new Orders();
                        order.orderID = Convert.ToString(newID);
                        order.orderStatus = "In Preparation";
                        Console.WriteLine("Would you like to make any modifications to your order?");
                        order.orderMod = Console.ReadLine();

                        using (StreamWriter writer = new StreamWriter(csvOrderPath, append : true))
                        {
                            writer.WriteLine(order.orderID);
                            writer.WriteLine($"{menu[userOrder].ToString()}");
                            writer.WriteLine(order.orderStatus);
                            writer.WriteLine(order.orderMod);
                            writer.WriteLine(register.customerID);
                         }

                        using (StreamWriter writer = new StreamWriter(csvHistoryPath, append : true))
                        {
                            writer.WriteLine(register.customerID);
                            writer.WriteLine($"{menu[userOrder].ToString()}");
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
                            adminChoice = Convert.ToInt32(Console.ReadLine());
                            switch (adminChoice) 
                            {
                                case 1:
                                    MenuItems add = new MenuItems();
                                    add.AddMenu();
                                    break;

                                case 2:
                                    MenuItems update = new MenuItems();
                                    update.UpdateMenu();
                                    break;

                                case 3:
                                    MenuItems remove = new MenuItems();
                                    remove.RemoveMenu();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }
                        } while (adminChoice != 4);

                        break;

                    case 3:
                        
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
