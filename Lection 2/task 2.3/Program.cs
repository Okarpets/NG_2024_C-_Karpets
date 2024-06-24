using Lection_2;

namespace Program
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            PersonSystem System = new PersonSystem();
            while (true)
            {
                Console.WriteLine("Please, enter a command: ");
                string Command = Convert.ToString(Console.ReadLine());
                switch (Command)
                {
                    case "-help":
                        Console.WriteLine(System.Commands());
                        break;

                    case "Q":
                        System.Quit();
                        break;

                    case "A":
                        Console.WriteLine("Enter person's name: ");
                        string PersonName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter person's number: ");
                        string PersonNumber = Convert.ToString(Console.ReadLine());
                        if (System.CheckNumber(PersonNumber) == true)
                        {
                            if (System.CheckPhone(PersonNumber) == false)
                            {
                                System.AddToList(new Person(PersonName, PersonNumber));
                                break;
                            }
                            Console.WriteLine("This phone number already registrated");
                            break;
                        }
                        Console.WriteLine("Please, type a real number");
                        break;

                    case "GP":
                        Console.WriteLine("Enter person's number: ");
                        string GetByNumber = Convert.ToString(Console.ReadLine());
                        if (System.CheckPhone(GetByNumber) == true)
                        {
                            var GPtimely = System.GetByPhone(GetByNumber);
                            Console.WriteLine($"Person info:\nName: {GPtimely.FullName}\nPhone Number: {GPtimely.PhoneNumber}");
                            break;
                        }
                        Console.WriteLine("Account with this phone number never has been registrated");
                        break;

                    case "GN":
                        Console.WriteLine("Enter person's name: ");
                        string GetByName = Convert.ToString(Console.ReadLine());
                        if (System.CheckName(GetByName) == true)
                        {
                            var GNtimely = System.GetByName(GetByName);
                            Console.WriteLine($"Person info:\nName: {GNtimely.FullName}\nPhone Number: {GNtimely.PhoneNumber}");
                            break;
                        }
                        Console.WriteLine("Account with this name never has been registrated");
                        break;

                    case "GA":
                        var GetAllList = System.GetAll();
                        int Iterator = 1;
                        foreach (Person Person in GetAllList)
                        {
                            Console.WriteLine($"Person N{Iterator} info:\nName: {Person.FullName}\nPhone Number: {Person.PhoneNumber}");
                            Iterator++;
                        }
                        break;

                    case "D":
                        Console.WriteLine("Enter person's number: ");
                        string DeleteByName = Convert.ToString(Console.ReadLine());
                        if (System.CheckName(DeleteByName) == true)
                        {
                            System.DeleteFromList(DeleteByName);
                            Console.WriteLine("Person has been removed from list");
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
