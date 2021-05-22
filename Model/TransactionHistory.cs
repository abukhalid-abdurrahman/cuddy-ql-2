using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Transactions.Model
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TransactionId { get; set; }
        [Required] 
        public bool IsSuccessfully { get; set; }
        public Transaction Transaction { get; set; }
    }
}