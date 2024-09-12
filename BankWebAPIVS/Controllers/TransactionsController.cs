using AutoMapper;
using BankWebAPIVS.DTOs;
using BankWebAPIVS.Entities;
using BankWebAPIVS.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transaction = BankWebAPIVS.Entities.Transaction;

namespace BankWebAPIVS.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDBContext applicationDBContext;
        private readonly IMapper mapper;

        public TransactionsController(ApplicationDBContext applicationDBContext, IMapper mapper)
        {
            this.applicationDBContext = applicationDBContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransactionCreationDTO transactionCreationDTO)
        {
            var customerExists = await applicationDBContext.Customers.AnyAsync(
                customer => customer.CustomerId == transactionCreationDTO.CustomerId);

            if (!customerExists)
            {
                return BadRequest("The customer for this transaction does not exist.");
            }

            var transaction = mapper.Map<Transaction>(transactionCreationDTO);

            applicationDBContext.Add(transaction);

            await applicationDBContext.SaveChangesAsync();

            var transactionDTO = mapper.Map<TransactionDTO>(transaction);

            return CreatedAtRoute("getTransaction", new { id = transaction.Id }, transactionDTO);
        }

        [HttpGet("{id:int}", Name = "getTransaction")]
        public async Task<ActionResult<TransactionDTO>> GetTransaction(int id)
        {
            var transaction = await applicationDBContext.Transactions
                .FirstOrDefaultAsync(transactionBD => transactionBD.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return mapper.Map<TransactionDTO>(transaction);
        }

        [HttpGet("TransactionsByPeriod", Name = "getTransactionsByPeriod")]
        public async Task<ActionResult<List<TransactionDTO>>> GetTransactionsByPeriod(
            DateTime startDate, DateTime endDate)
        {
            DateTime UpdatedEndDate = endDate.AddTicks(TimeSpan.TicksPerDay - 1);

            var transactions = await applicationDBContext.Transactions
                .Where(t => t.DateAndTime >= startDate && t.DateAndTime <= UpdatedEndDate)
                .OrderByDescending(t => t.DateAndTime)
                .ToListAsync();

            return mapper.Map<List<TransactionDTO>>(transactions);
        }
    }
}
