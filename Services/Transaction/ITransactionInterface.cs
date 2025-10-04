using FinanceTrackerAPI.Models;

namespace FinanceTrackerAPI.Services.Transaction
{
    public interface ITransactionInterface
    {
        Task<List<TransactionModel>> GetAllTransactions();

        Task<TransactionModel> GetTransactionById(int id);

        Task<TransactionModel> CreateTransaction(TransactionModel transaction);

        Task<TransactionModel> UpdateTransaction(int id, TransactionModel transaction);

        Task DeleteTransaction(int id);
    }
}
