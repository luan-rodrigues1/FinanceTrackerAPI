using FinanceTrackerAPI.Dtos.Transaction;
using FinanceTrackerAPI.Models;

namespace FinanceTrackerAPI.Services.Transaction
{
    public interface ITransactionInterface
    {
        Task<List<TransactionModel>> GetAllTransactions(TransactionQuery query);

        Task<TransactionModel> GetTransactionById(int id);

        Task<TransactionModel> CreateTransaction(CreateTransaction transaction);

        Task<TransactionModel> UpdateTransaction(int id, UpdateTransaction transaction);

        Task DeleteTransaction(int id);
    }
}
