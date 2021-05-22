using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Transactions.Data;
using Transactions.Model;

namespace Transactions.GraphQl.Transactions
{
    public class TransactionType : ObjectType<Transaction>
    {
        protected override void Configure(IObjectTypeDescriptor<Transaction> descriptor)
        {
            descriptor.Description("Represents transactions and transactions histories");
            descriptor
                .Field(x => x.TransactionHistories)
                .ResolveWith<Resolvers>(x => x.GetTransactionHistories(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Represents transactions histories");
        }
        
        private class Resolvers
        {
            public IQueryable<TransactionHistory> GetTransactionHistories(Transaction transaction, 
                [ScopedService] AppDbContext dbContext)
            {
                return dbContext.TransactionHistories.Where(x => x.TransactionId == transaction.Id);
            }
        }
    }
}