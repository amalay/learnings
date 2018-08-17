using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using MailServer.Contracts.Contracts;
using MailServer.Contracts.Model;

namespace MailServerStatefulService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class MailServerStatefulService : StatefulService, IMailService
    {
        public MailServerStatefulService(StatefulServiceContext context)
            : base(context)
        { }
        
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
            {
                new ServiceReplicaListener(c => this.CreateServiceRemotingListener(c))
            };
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            var inputMailQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<MailMessage>>("inputMailQueue");
            var mailDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<Guid, string>>("mailDictionary");

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var tx = this.StateManager.CreateTransaction())
                {
                    //dequeue mail
                    var mail = await inputMailQueue.TryDequeueAsync(tx);

                    if (mail.HasValue)
                    {
                        var processedMail = mail.Value;
                        processedMail.ReceivedAt = DateTime.Now;

                        //process and add to state
                        await mailDictionary.AddAsync(tx, processedMail.FromId, processedMail.Message);
                    }

                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.
                    await tx.CommitAsync();
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }


        #region Mail Service Implementation
        public async Task<long> GetMessageCount()
        {
            var mailDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<Guid, string>>("mailDictionary");

            using (var tx = this.StateManager.CreateTransaction())
            {
                return await mailDictionary.GetCountAsync(tx);
            }
        }

        public async Task SendMessage(MailMessage message)
        {
            using (var tx = this.StateManager.CreateTransaction())
            {
                var inputMailQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<MailMessage>>("inputMailQueue");

                await inputMailQueue.EnqueueAsync(tx, message);

                await tx.CommitAsync();
            }
        }

        public Task<MailMessage> ReceiveMessage(Guid toId)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
