using FinanceTrackerAPI.Models;

namespace FinanceTrackerAPI.Services.Transaction
{
    public class TransactionService : ITransactionInterface
    {
        Task<TransactionModel> ITransactionInterface.CreateTransaction(TransactionModel transaction)
        {
            throw new NotImplementedException();
        }

        Task ITransactionInterface.DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<TransactionModel>> ITransactionInterface.GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        Task<TransactionModel> ITransactionInterface.GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        Task<TransactionModel> ITransactionInterface.UpdateTransaction(int id, TransactionModel transaction)
        {
            throw new NotImplementedException();
        }
    }
}
