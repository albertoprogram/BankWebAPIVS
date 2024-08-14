using AutoMapper;
using BankWebAPIVS.DTOs;
using BankWebAPIVS.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAPIVS.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDBContext applicationDBContext;
        private readonly IMapper mapper;

        public CustomersController(ApplicationDBContext applicationDBContext, IMapper mapper)
        {
            this.applicationDBContext = applicationDBContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerCreationDTO customerCreationDTO)
        {
            var customer = mapper.Map<Customer>(customerCreationDTO);

            applicationDBContext.Add(customer);

            await applicationDBContext.SaveChangesAsync();

            var customerDTO = mapper.Map<CustomerDTO>(customer);

            return Ok();
            //return CreatedAtRoute("getCustomer", new { id = transaction.Id }, transactionDTO);
        }
    }
}
