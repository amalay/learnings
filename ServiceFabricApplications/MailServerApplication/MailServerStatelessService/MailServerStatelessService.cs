using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using MailServer.Contracts.Contracts;
using MailServer.Contracts.Model;
using System.Collections.Concurrent;

namespace MailServerStatelessService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class MailServerStatelessService : StatelessService, IMailService
    {
        private ConcurrentQueue<MailMessage> _queue = new ConcurrentQueue<MailMessage>();
        private ConcurrentDictionary<Guid, MailMessage> _mailDictionary = new ConcurrentDictionary<Guid, MailMessage>();

        public MailServerStatelessService(StatelessServiceContext context)
            : base(context)
        { }
        
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(c=>this.CreateServiceRemotingListener(c))
            };
        }
        
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            long iterations = 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                MailMessage mail = null;

                if (_queue.TryDequeue(out mail) == true)
                {
                    _mailDictionary.TryAdd(mail.FromId, mail);
                }

                ServiceEventSource.Current.ServiceMessage(this, "Working-{0}", ++iterations);

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }

        }

        #region Mail Service Implementation

        public Task<long> GetMessageCount()
        {
            return Task.FromResult((long)_mailDictionary.Count);
        }

        public Task SendMessage(MailMessage message)
        {
            _queue.Enqueue(message);
            return Task.FromResult(true);
        }

        public Task<MailMessage> ReceiveMessage(Guid toId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
