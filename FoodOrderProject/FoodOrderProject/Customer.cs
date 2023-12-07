using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderProject
{
    public class Customer : Person
    {
        public string customerID;
        public string contact;
        public string address;
        string csvCustomerPath = "Customers.csv";
        public Customer()
        {
            this.customerID = "0";
            this.name = "Unknown";
            this.usertype = "Customer";
            this.contact = "Unknown";
            this.address = "Unknown";
        }

        public Customer(string customerID, string name, string usertype, string contact, string address)
        {
            this.customerID = "0";
            this.name = "Unknown";
            this.usertype = "Customer";
            this.contact = "Unknown";
            this.address = "Unknown";
        }

        public void RegisterCustomer()
        {
            string curLine = "";
            int count = 0;
            Console.WriteLine("What is your name?");
            this.name = Console.ReadLine();
            this.usertype = "Customer";
            Console.WriteLine("What is your contact number?");
            this.contact = Console.ReadLine();
            Console.WriteLine("What is your address?");
            this.address = Console.ReadLine();

            using (StreamReader reader = new StreamReader(csvCustomerPath))
            {
                while ((curLine = reader.ReadLine()) != null) // While not End of File
                {
                    count = count + 1;
                }

                this.customerID = Convert.ToString(count);

                using (StreamWriter streamWriter = new StreamWriter(csvCustomerPath, append : true))
                {
                    streamWriter.WriteLine(this.customerID);
                    streamWriter.WriteLine(this.name);
                    streamWriter.WriteLine(this.usertype);
                    streamWriter.WriteLine(this.contact);
                    streamWriter.WriteLine(this.address);
                }
            }
        }
    }
}
