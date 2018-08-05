using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public Address HomeAddress { get; set; }

        public Address OfficeAddress { get; set; }
    }
}
