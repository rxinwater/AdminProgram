using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdministratieProgramma
{
    internal class Program
    {
        public static void Main()
        {
            Menu menu = new Menu();
            CustomerManager admin = new CustomerManager();
            menu.MainMenu(admin);
        }
    }
}
