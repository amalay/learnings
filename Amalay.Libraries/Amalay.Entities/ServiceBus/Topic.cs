using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Entities
{
    public class Topic
    {
        public string Name { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    }
}
