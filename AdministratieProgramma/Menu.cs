using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratieProgramma
{
    internal class Menu
    {
        CustomerManager admin = new CustomerManager();


        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome! To get started please choose one of the following by typing only their respective number.");
            Console.WriteLine("For more functionality, please view user first");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Show users");
            Console.WriteLine("3. Exit program.");  

            int userInput;

            while (true)
            {
                Console.Write("Your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userInput) && userInput >= 1 && userInput <= 3)
                    break;

                Utilities.ShowErrorLog("Invalid input. Please choose 1, 2, or 3.");
            }

            switch (userInput)
            {
                case 1:
                    admin.AddFromInput("Customer added succesfully.", this);
                    break;

                case 2:
                    admin.ShowAllCustomers(this);
                    break;

                case 3:
                    Environment.Exit(0);
                    break;
            }
        }


        public void ReturnToMenu(bool showCustomer, string moreFunctionality) 
        {
            int optionChosen;

            while (true)
            {
               
                if (showCustomer)
                {
                    Console.Write("Type 1 to return to main menu, 2 to exit program");
                    Console.WriteLine(moreFunctionality);
                    Console.Write("Your choice: ");
                } else
                {
                    Console.WriteLine("Type 1 to return to main menu, 2 to exit program");
                    Console.Write("Your choice: ");
                }


                    string menuoption = Console.ReadLine();

                if (int.TryParse(menuoption, out optionChosen) &&
                    optionChosen >= 1 && optionChosen <= 4)
                {
                    break;
                }

                Utilities.ShowErrorLog("Invalid input, please try again");
            }


            switch (optionChosen)
            {
                case 1:
                    MainMenu();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

                case 3:
                    admin.EditDetails(this);
                    break;

                case 4:
                    admin.RemoveCustomer("Succesfully removed customer!",this);
                    break;
            }

        }
    }
}
