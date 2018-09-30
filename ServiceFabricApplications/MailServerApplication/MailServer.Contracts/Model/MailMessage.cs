using System;
using System.Runtime.Serialization;

namespace MailServer.Contracts.Model
{
    [DataContract]
    public class MailMessage
    {
        [DataMember]
        public Guid FromId { get; set; }

        [DataMember]
        public Guid ToId { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTime ReceivedAt { get; set; }
    }
}
