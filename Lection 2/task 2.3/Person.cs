namespace Lection_2
{
    public class Person
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public Person(string name, string phone)
        {
            FullName = name;
            PhoneNumber = phone;
        }
    }
}
