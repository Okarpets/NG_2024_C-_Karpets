using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Person
    {
        public decimal PersonId;
        public string? Address
        {
            get;
            set;
        }
        public Person(decimal PersonId, string Name, decimal AccountNumber)
        {
            this.PersonId = PersonId;
        }
        
    }
}
