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
        private List<Person> personList = new List<Person>();
        public bool CheckNumber(string phoneNumber)
        {
            string pattern = "^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (phoneNumber != null) return Regex.IsMatch(phoneNumber, pattern);
            else return false;
        }
        public bool CheckName(string name)
        {
            return personList.Contains(personList.FirstOrDefault(x => x.FullName == name));
        }
        public bool CheckPhone(string phoneNumber)
        {
            if (CheckNumber(phoneNumber) == true) 
            {
                return personList.Contains(personList.FirstOrDefault(x => x.PhoneNumber == phoneNumber));
            }
            return false;
        }
        public void AddToList(Person person)
        {
            personList.Add(person);
            Console.WriteLine("Person has been added to list");
        }
        public void DeleteFromList(string userPhoneNumber)
        {
            if (CheckNumber(userPhoneNumber) == true)
            {
                personList.Remove(personList.FirstOrDefault(x => x.PhoneNumber == userPhoneNumber));
                Console.WriteLine("Person has been removed from list");
            }
        }
        public void Quit()
        {
            Environment.Exit(0);
        }

        public Person GetByPhone(string userPhoneNumber)
        {
             return personList.Where(x => x.PhoneNumber == userPhoneNumber).FirstOrDefault();
        }
        public List<Person> GetAll()
        {
            List<Person> orderedList = personList.OrderBy(o => o.FullName).ToList();
            return orderedList;
        }
        public Person GetByName(string userName)
        {
            return personList.Where(x => x.FullName == userName).FirstOrDefault();
        }
        public string Commands()
        {
            string command =
            "* Q - exit\n" +
            "* A - add\n" +
            "* GP - Get by phone(display all info)\n" +
            "* GN - Get by name(display only names)\n" +
            "* GA - Get all(display ordered by name)\n" +
            "* D - delete by phone\n";
            return command;
        }
    }
}
