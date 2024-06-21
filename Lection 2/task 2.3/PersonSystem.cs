using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lection_2
{
    class PersonSystem
    {
        private List<Person> PersonList = new List<Person>();
        public bool CheckNumber(string PhoneNumber)
        {
            string Pattern = "^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (PhoneNumber != null) return Regex.IsMatch(PhoneNumber, Pattern);
            else return false;
        }
        public bool CheckName(string Name)
        {
            return PersonList.Any(x => x.FullName == Name);
        }
        public bool CheckPhone(string UserPhoneNumber)
        {
            if (CheckNumber(UserPhoneNumber) == true) 
            {
                return PersonList.Any(x => x.PhoneNumber == UserPhoneNumber);
            }
            return false;
        }
        public void AddToList(Person Person)
        {
            PersonList.Add(Person);
            Console.WriteLine("Person has been added to list");
        }
        public void DeleteFromList(string UserPhoneNumber)
        {
            PersonList.RemoveAll(x => x.PhoneNumber == UserPhoneNumber);
        }
        public void Quit()
        {
            Environment.Exit(0);
        }

        public Person GetByPhone(string UserPhoneNumber)
        {
             return PersonList.FirstOrDefault(x => x.PhoneNumber == UserPhoneNumber);
        }
        public List<Person> GetAll()
        {
            List<Person> OrderedList = PersonList.OrderBy(o => o.FullName).ToList();
            return OrderedList;
        }
        public Person GetByName(string UserName)
        {
            return PersonList.FirstOrDefault(x => x.FullName == UserName);
        }
        public string Commands()
        {
            string Command =
            "* Q - exit\n" +
            "* A - add\n" +
            "* GP - Get by phone(display all info)\n" +
            "* GN - Get by name(display only names)\n" +
            "* GA - Get all(display ordered by name)\n" +
            "* D - delete by phone\n";
            return Command;
        }
    }
}
