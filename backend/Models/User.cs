using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialControl.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1, ErrorMessage = "The name must be at least 1 character long.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1, ErrorMessage = "The name must be at least 1 character long.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1, ErrorMessage = "The name must be at least 1 character long.")]
        public string Password { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
