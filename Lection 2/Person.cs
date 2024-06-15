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
        public Person(string name, string phone)
        {
            fullName = name;
            phoneNumber = phone;
        }

        private string fullName;
        private string phoneNumber;

        public string PhoneNumber 
        { 
            set => phoneNumber = value;
            get => phoneNumber;
        }
        public string FullName 
        { 
            set => fullName = value;
            get => fullName;
        }

    }
}
