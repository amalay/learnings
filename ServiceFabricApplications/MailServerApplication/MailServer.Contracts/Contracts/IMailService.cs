using MailServer.Contracts.Model;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;
using System;

namespace MailServer.Contracts.Contracts
{
    public interface IMailService : IService
    {
        Task SendMessage(MailMessage message);

        Task<MailMessage> ReceiveMessage(Guid toId);

        Task<long> GetMessageCount();
    }
}
