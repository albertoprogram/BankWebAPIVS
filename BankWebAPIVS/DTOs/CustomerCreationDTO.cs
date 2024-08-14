using System.ComponentModel.DataAnnotations;

namespace BankWebAPIVS.DTOs
{
    public class CustomerCreationDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 10, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string Name { get; set; }
    }
}
