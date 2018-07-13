using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortBody { get; set; }

        public string FullBody { get; set; }
    }
}
