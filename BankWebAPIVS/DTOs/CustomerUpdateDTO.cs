using System.ComponentModel.DataAnnotations;

namespace BankWebAPIVS.DTOs
{
    public class CustomerUpdateDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string Name { get; set; }
    }
}
