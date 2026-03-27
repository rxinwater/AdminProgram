using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdministratieProgramma
{
    internal class CustomerManager
    {
        private readonly List<Customer> customers = new List<Customer>();
        private readonly Menu menu = new Menu();
        private int _age;
        private string _ageInput;
     

        public void AddFromInput(string succesMessage)
        {
            Console.Clear();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter age: ");
                _ageInput = Console.ReadLine();

                if (int.TryParse(_ageInput, out _age) && _age > 0)
                    break;

                Utilities.ShowErrorLog("invalid age");
            }

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            customers.Add(new Customer(name, address, _age, phone));

            Console.WriteLine();
            menu.ReturnToMenu(this, false, "");
           
        }
        public void ShowAllCustomers()
        {
            Console.Clear();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                Console.WriteLine("Any respone will return you to main menu.");
                string input = Console.ReadLine();

                bool flag = input != null;
                if (flag) menu.MainMenu(this);
            }

            int index = 1;
            foreach (var c in customers)
            {
                Console.WriteLine($"ID: {index}.| Name: {c.Name} | Adress: {c.Address} | Age: {c.Age} | Phone number: {c.Phone}");
                index++;
            }

            menu.three = false;
            menu.four = false;

            menu.ReturnToMenu(this, true, " , 3 to edit details, or 4 to remove a customer.");
            if (menu.three)
            {
                EditDetails();
                menu.three = false;
            }
            else if (menu.four)
            {
                RemoveCustomer("Removal succesfull");
                menu.four = false;
            }
        }
        public Customer idSelection()
        {
            int id;

            while (true)
            {
                Console.WriteLine("Who would you like to edit or remove? Please respond with their ID number.");
                string response1 = Console.ReadLine();

                if (int.TryParse(response1, out id) &&
                    id >= 1 &&
                    id <= customers.Count)
                {
                    break;
                }

                Utilities.ShowErrorLog("Invalid ID, try again.");
            }

            int index = id - 1;


            Customer customer = customers[index];
            return customer;
        }

        public void EditDetails()
        {
            Customer customerToEdit = idSelection();

            Console.Clear();
            Console.WriteLine("Leave a field blank to keep it unchanged.");

            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName)) newName = null; //keep unchanged

            Console.Write("Enter new address: ");
            string newAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newAddress)) newAddress = null;

            int? newAge = null;
            while (true)
            {
                Console.Write("Enter new age: ");
                string ageInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ageInput))
                    break; 
                if (int.TryParse(ageInput, out int age) && age > 0)
                {
                    newAge = age;
                    break;
                }
                Utilities.ShowErrorLog("Invalid age, try again.");
            }

            Console.Write("Enter new phone: ");
            string newPhone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newPhone)) newPhone = null;

            // Apply changes
            customerToEdit.Update(newName, newAddress, newAge, newPhone);

            Console.Clear();
            Console.WriteLine("Customer details updated successfully!");
            menu.ReturnToMenu(this, false, "");


        }

        public void RemoveCustomer(string successMessage)
        {
           Customer customer = idSelection();
            if (customers.Remove(customer))
            {
                Console.Clear();
                Console.WriteLine(successMessage);
                menu.ReturnToMenu(this, false, "");
             
            }
            else
            {
                Utilities.ShowErrorLog("Removal failed");
            }


        }

        
      

    }


}


