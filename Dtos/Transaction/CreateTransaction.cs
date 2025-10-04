using FinanceTrackerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerAPI.Dtos.Transaction
{
    public class CreateTransaction
    {
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(100, ErrorMessage = "Description can't exceed 100 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction IsIncome is required")]
        public bool? IsIncome { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; }
    }
}
