using netCore.RateLimiting.Application.Requests;
using netCore.RateLimiting.Application.Responses;

namespace netCore.RateLimiting.Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> CreateCustomer(CreateCustomerRequest request);
        Task<CustomerResponse> UpdateCustomer(Guid id, UpdateCustomerRequest request);
        Task<CustomerResponse> DeleteCustomer(Guid id);
        Task<CustomerResponse> GetCustomerById(Guid id);
        Task<List<CustomerResponse>> GetCustomers();
    }
}
