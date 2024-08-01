using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankWebAPIVS.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 10, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 100, ErrorMessage = "The field {0} must not be more than {1} characters.")]
        public string Name { get; set; }
    }
}
