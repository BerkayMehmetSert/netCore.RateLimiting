using AutoMapper;
using netCore.RateLimiting.Application.Requests;
using netCore.RateLimiting.Application.Responses;
using netCore.RateLimiting.Models.Entities;

namespace netCore.RateLimiting.Application.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
        }
    }
}
