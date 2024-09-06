using AutoMapper;
using BankWebAPIVS.DTOs;
using BankWebAPIVS.Entities;

namespace BankWebAPIVS.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TransactionCreationDTO, Transaction>();
            CreateMap<Transaction, TransactionDTO>();

            CreateMap<CustomerCreationDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerUpdateDTO, Customer>();
        }
    }
}
