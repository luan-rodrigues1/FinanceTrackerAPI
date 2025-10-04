using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerAPI.Dtos.Transaction
{
    public class UpdateTransaction
    {
        [MaxLength(100, ErrorMessage = "Description can't exceed 100 characters")]
        public string? Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal ?Amount { get; set; }

        public bool? IsIncome { get; set; }

        public DateTime? Date { get; set; }
    }
}
