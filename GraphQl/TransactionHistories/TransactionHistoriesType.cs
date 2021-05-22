using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Transactions.Data;
using Transactions.Model;

namespace Transactions.GraphQl.TransactionHistories
{
    public class TransactionHistoriesType : ObjectType<TransactionHistory>
    {
        protected override void Configure(IObjectTypeDescriptor<TransactionHistory> descriptor)
        {
            descriptor.Description("Represents transactions history of statuses (successfully, failed)");
            descriptor
                .Field(x => x.Transaction)
                .ResolveWith<Resolvers>(x => x.GetTransaction(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Represents transaction, that reference to this transaction history");
        }
        
        private class Resolvers
        {
            public Transaction GetTransaction(TransactionHistory history, [ScopedService] AppDbContext dbContext)
            {
                return dbContext.Transactions.FirstOrDefault(x => x.Id == history.TransactionId);
            }
        }
    }
}