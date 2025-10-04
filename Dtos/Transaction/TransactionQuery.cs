using FinanceTrackerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerAPI.Dtos.Transaction
{
    public class TransactionQuery
    {
        public bool? IsIncome { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public OrderByType? OrderBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate.HasValue && EndDate.HasValue && StartDate > EndDate)
            {
                yield return new ValidationResult(
                    "StartDate must be less than or equal to EndDate.",
                    new[] { nameof(StartDate), nameof(EndDate) }
                );
            }
        }
    }

    public enum OrderByType
    {
        ASC,
        DESC
    }
}
