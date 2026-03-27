using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratieProgramma
{
    internal class Customer
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Age { get; private set; }
        public string Phone { get; private set; }

        public Customer(string name, string address, int age, string phone)
        {
            Name = name;
            Address = address;
            Age = age;
            Phone = phone;
        }

        public void Update(string name = null, string address = null, int? age = null, string phone = null)
        {
            if (name != null) Name = name;
            if (address != null) Address = address;
            if (age != null) Age = age.Value;
            if (phone != null) Phone = phone;
        }
    }
}
