using AutoMapper;
using BankWebAPIVS.DTOs;
using BankWebAPIVS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var transaction = mapper.Map<Transaction>(transactionCreationDTO);

            applicationDBContext.Add(transaction);

            await applicationDBContext.SaveChangesAsync();

            //var transactionDTO = mapper.Map<TransactionDTO>(transaction);

            //return CreatedAtRoute("getTransaction",new {id = transaction.Id}, )

            return Ok();
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
    }
}
