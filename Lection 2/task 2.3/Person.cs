using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lection_2
{
    public class Person
    {
        private string Name;
        private string Number;
        public Person(string name, string phone)
        {
            Name = name;
            Number = phone;
        }

        public string PhoneNumber 
        { 
            set => Number = value;
            get => Number;
        }
        public string FullName 
        { 
            set => Name = value;
            get => Name;
        }

    }
}
