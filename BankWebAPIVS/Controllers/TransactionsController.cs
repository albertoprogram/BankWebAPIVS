using AutoMapper;
using BankWebAPIVS.DTOs;
using BankWebAPIVS.Entities;
using Microsoft.AspNetCore.Mvc;

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

            return Ok();
        }
    }
}
