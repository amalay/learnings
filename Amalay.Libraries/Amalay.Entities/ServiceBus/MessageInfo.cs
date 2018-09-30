using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Entities
{
    public class MessageInfo
    {
        public Message Message { get; set; }
        
        public List<Recipient> Recipients { get; set; }
        
        public List<Recipient> CcRecipients { get; set; }
        
        public List<Recipient> BccRecipients { get; set; }
    }
}
