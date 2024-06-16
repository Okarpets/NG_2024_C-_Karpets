using Lection_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Program
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            PersonSystem system = new PersonSystem(); 
            while (true)
            {
                Console.WriteLine("Please, enter a command: ");
                string command = Convert.ToString(Console.ReadLine());
                switch (command)
                {
                    case "-help":
                        Console.WriteLine(system.Commands());
                        break;
                    case "Q":
                        system.Quit();
                        break;
                    case "A":
                        Console.WriteLine("Enter person's name: ");
                        string personName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter person's number: ");
                        string personNumber = Convert.ToString(Console.ReadLine());
                        if (system.CheckPhone(personNumber) == false && system.CheckNumber(personNumber) == true)
                        {
                            system.AddToList(new Person(personName, personNumber));
                            break;
                        }
                        Console.WriteLine("This phone number already registrated");
                        break;
                    case "GP":
                        Console.WriteLine("Enter person's number: ");
                        string getByNumber = Convert.ToString(Console.ReadLine());
                        if (system.CheckPhone(getByNumber) == true)
                        {
                            var GPtimely = system.GetByPhone(getByNumber);
                            Console.WriteLine($"Person info:\nName: {GPtimely.FullName}\nPhone Number: {GPtimely.PhoneNumber}");
                            break;
                        }
                        Console.WriteLine("Account with this phone number never has been registrated");
                        break;
                    case "GN":
                        Console.WriteLine("Enter person's name: ");
                        string getByName = Convert.ToString(Console.ReadLine());
                        if (system.CheckName(getByName) == true)
                        {
                            var GNtimely = system.GetByName(getByName);
                            Console.WriteLine($"Person info:\nName: {GNtimely.FullName}\nPhone Number: {GNtimely.PhoneNumber}");
                            break;
                        }
                        Console.WriteLine("Account with this name never has been registrated");
                        break;
                    case "GA":
                        var getAllList = system.GetAll();
                        int iterator = 1;
                        foreach (Person person in getAllList)
                        {
                            Console.WriteLine($"Person N{iterator} info:\nName: {person.FullName}\nPhone Number: {person.PhoneNumber}");
                            iterator++;
                        }
                        break;
                    case "D":
                        Console.WriteLine("Enter person's number: ");
                        string deleteByName = Convert.ToString(Console.ReadLine());
                        if (system.CheckName(deleteByName) == true)
                        {
                            system.DeleteFromList(deleteByName);
                            Console.WriteLine("Account with this phone number never has been registrated");
                            break;
                        }
                        Console.WriteLine("Account with this name never has been registrated");
                        break;
                    default:
                        Console.WriteLine("It is a wrong command, please, use \"-help\"");
                        break;
                }
            }
        }
    }
}
