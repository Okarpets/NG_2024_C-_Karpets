namespace Lection_1
{
    public class Person
    {
        public decimal PersonId { get; set; }
        public string? Address { get; set; }

        public Person(decimal PersonId, string Name, decimal AccountNumber)
        {
            this.PersonId = PersonId;
        }

    }
}
