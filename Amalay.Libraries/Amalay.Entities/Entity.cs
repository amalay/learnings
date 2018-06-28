using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Entity() { }

        public Entity(int id)
        {
            this.Id = id;
        }

        public Entity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
