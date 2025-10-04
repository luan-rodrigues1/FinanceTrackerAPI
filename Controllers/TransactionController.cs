using FinanceTrackerAPI.Common.Exceptions;
using FinanceTrackerAPI.Dtos.Transaction;
using FinanceTrackerAPI.Models;
using FinanceTrackerAPI.Services.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinanceTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionInterface _transactionService;


        public TransactionController(ITransactionInterface transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions([FromQuery] TransactionQuery query)
        {
            try
            {
                var transactions = await _transactionService.GetAllTransactions(query);
                return Ok(transactions);
            }
            catch (DomainException ex)
            {
                return StatusCode(ex.StatusCode, new { statusCode = ex.StatusCode, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{TransactionId}")]
        public async Task<IActionResult> GetTransactionById(int TransactionId)
        {
            try
            {
                var transaction = await _transactionService.GetTransactionById(TransactionId);

                return Ok(transaction);
            }
            catch (DomainException ex)
            {
                return StatusCode(ex.StatusCode, new { statusCode = ex.StatusCode, message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionModel), 201)]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction transaction)
        {
            try
            {
                var createdTransaction = await _transactionService.CreateTransaction(transaction);
                return StatusCode(201, createdTransaction);

            }
            catch (DomainException ex)
            {
                return StatusCode(ex.StatusCode, new { statusCode = ex.StatusCode, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{TransactionId}")]
        public async Task<IActionResult> UpdateTransaction(int TransactionId, [FromBody] UpdateTransaction transaction)
        {
            try
            {
                var updatedTransaction = await _transactionService.UpdateTransaction(TransactionId, transaction);
                return Ok(updatedTransaction);
            }
            catch (DomainException ex)
            {
                return StatusCode(ex.StatusCode, new { statusCode = ex.StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("{TransactionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTransaction(int TransactionId)
        {
            try
            {
                await _transactionService.DeleteTransaction(TransactionId);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return StatusCode(ex.StatusCode, new { statusCode = ex.StatusCode, message = ex.Message });
            }
        }
    }
}
