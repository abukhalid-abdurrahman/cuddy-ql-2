using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using Transactions.Data;
using Transactions.Model;

namespace Transactions.GraphQl
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddTransactionPayload> AddTransactionAsync(AddTransactionInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                RecipientName = input.RecipientName,
                SenderName = input.SenderName,
                TransactionAmount = input.Amount,
                TransactionId = Guid.NewGuid().ToString()
            };
            await context.Transactions.AddAsync(transaction, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscriptions.OnTransactionAdded), transaction, cancellationToken);
            return new AddTransactionPayload(transaction.TransactionId);
        }
    }

    public class AddTransactionInput
    {
        public string SenderName { get; set; }
        public string RecipientName { get; set; }
        public float Amount { get; set; }
    }

    public class AddTransactionPayload
    {
        public string TransactionId { get; set; }
        public AddTransactionPayload(string transactionId)
        {
            TransactionId = transactionId;
        }
    }
}