using System.ComponentModel.DataAnnotations;

namespace BankWebAPIVS.DTOs
{
    public class TransactionCreationDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 10, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 7, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string TXNTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public decimal Amount { get; set; }
    }
}
