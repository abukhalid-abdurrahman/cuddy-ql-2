using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using Transactions.Data;
using Transactions.Model;

namespace Transactions.GraphQl
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Transaction> GetTransactions([ScopedService] AppDbContext context)
        {
            return context.Transactions;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TransactionHistory> GetTransactionHistories([ScopedService] AppDbContext context)
        {
            return context.TransactionHistories;
        }
    }
}