using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialControl.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Range(0.01, 9999999999.99, ErrorMessage = "The amount must be between 0.01 and 9999999999.99")]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; } = TransactionType.Expense;

        [Required]
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "BRL";

        [MaxLength(150)]
        public string? LocationName { get; set; }

        [MaxLength(20)]
        public string? LocationIdentifier { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    public enum TransactionType
    {
        Income,
        Expense
    }

    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        DebitCard,
        BankTransfer,
        DigitalWallet
    }
}