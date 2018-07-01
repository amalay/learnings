using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Entities
{
    public class Person
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public Guid PersonId { get; set; } = Guid.NewGuid();
    }
}
