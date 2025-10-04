using FinanceTrackerAPI.Common.Exceptions;
using FinanceTrackerAPI.Data;
using FinanceTrackerAPI.Dtos.Transaction;
using FinanceTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Services.Transaction
{
    public class TransactionService : ITransactionInterface
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }
        async Task<TransactionModel> ITransactionInterface.CreateTransaction(CreateTransaction payload)
        {
            
            var transaction = new TransactionModel
            {
                Description = payload.Description,
                Amount = payload.Amount,
                Date = payload.Date.Value,
                IsIncome = payload.IsIncome.Value,
            };

            await _context.Transactions.AddAsync(transaction); 
            await _context.SaveChangesAsync();          
            return transaction;

        }

        async Task ITransactionInterface.DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                throw new DomainException("Transaction not found", 404);
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        async Task<List<TransactionModel>> ITransactionInterface.GetAllTransactions(TransactionQuery query)
        {
            var queryable = _context.Transactions.AsQueryable();

            if (query.IsIncome.HasValue)
                queryable = queryable.Where(t => t.IsIncome == query.IsIncome.Value);

            if (query.StartDate.HasValue)
                queryable = queryable.Where(t => t.Date >= query.StartDate.Value);

            if (query.EndDate.HasValue)
                queryable = queryable.Where(t => t.Date <= query.EndDate.Value);

            if (query.OrderBy.HasValue)
            {
                queryable = query.OrderBy.Value == OrderByType.ASC
                    ? queryable.OrderBy(t => t.Date)
                    : queryable.OrderByDescending(t => t.Date);
            }

            return await queryable.ToListAsync();
        }

        async Task<TransactionModel> ITransactionInterface.GetTransactionById(int id)
        {
            var transaction = await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
            {
                throw new DomainException("Transaction not found", 404);
            }

            return transaction;
        }

        async Task<TransactionModel> ITransactionInterface.UpdateTransaction(int id, UpdateTransaction payload)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                throw new DomainException("Transaction not found", 404);
            }

            if (!string.IsNullOrWhiteSpace(payload.Description))
                transaction.Description = payload.Description;

            if (payload.Amount.HasValue)
                transaction.Amount = payload.Amount.Value;

            if (payload.IsIncome.HasValue)
                transaction.IsIncome = payload.IsIncome.Value;

            if (payload.Date.HasValue)
                transaction.Date = payload.Date.Value;

            transaction.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return transaction;
        }
    }
}
