using System;
using HotChocolate;
using HotChocolate.Types;
using Transactions.Model;

namespace Transactions.GraphQl
{
    public class Subscriptions
    {
        [Subscribe]
        [Topic]
        public Transaction OnTransactionAdded([EventMessage] Transaction transaction)
        {
            return transaction;
        }
    }
}