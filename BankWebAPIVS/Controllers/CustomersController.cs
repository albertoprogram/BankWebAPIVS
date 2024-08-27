﻿using AutoMapper;
using BankWebAPIVS.DTOs;
using BankWebAPIVS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return CreatedAtRoute("getCustomer", new { customerId = customer.CustomerId }, customerDTO);
        }

        [HttpGet("{customerId}", Name = "getCustomer")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(string customerId)
        {
            var customer = await applicationDBContext.Customers
                .FirstOrDefaultAsync(customerBD => customerBD.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return mapper.Map<CustomerDTO>(customer);
        }

        [HttpGet(Name = "getCustomers")]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomers()
        {
            var customers = await applicationDBContext.Customers.ToListAsync();

            return mapper.Map<List<CustomerDTO>>(customers);
        }

    }
}
