using Microsoft.AspNetCore.Mvc;
using FinancialControl.Models;
using FinancialControl.Services;

namespace FinancialControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService transactionService)
        {
            _service = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _service.GetAllTransactionAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(Guid id)
        {
            var transaction = await _service.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            await _service.CreateTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, Transaction transaction)
        {
            if (id != transaction.Id)
                return BadRequest();
            var updatedCategory = await _service.UpdateTransactionAsync(transaction);
            if (updatedCategory == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var success = await _service.DeleteTransactionAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
