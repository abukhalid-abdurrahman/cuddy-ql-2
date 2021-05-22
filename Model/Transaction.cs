using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Transactions.Model
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string RecipientName { get; set; }
        [Required]
        public float TransactionAmount { get; set; }
        public ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}