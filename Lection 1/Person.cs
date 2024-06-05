using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Person : Client
    {
        public Person(decimal personId, string name, decimal accountNumber) : base(personId, name, accountNumber)
        {
            this.personID = personId;
        }
        private decimal personID;
        private string? address;

        public string Address
        {
            get => "Person dosen't have address" ?? address;
            set => address = value;
        }
    }
}
