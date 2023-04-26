using AutoMapper;
using netCore.RateLimiting.Application.Repositories;
using netCore.RateLimiting.Application.Requests;
using netCore.RateLimiting.Application.Responses;
using netCore.RateLimiting.Models.Entities;

namespace netCore.RateLimiting.Application.Services
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);

            _customerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<CustomerResponse> UpdateCustomer(Guid id, UpdateCustomerRequest request)
        {
            var customer = await GetCustomer(id);

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;

            _customerRepository.Update(customer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<CustomerResponse> DeleteCustomer(Guid id)
        {
            var customer = await GetCustomer(id);

            _customerRepository.Delete(customer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<CustomerResponse> GetCustomerById(Guid id)
        {
            var customer = GetCustomer(id).Result;

            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<List<CustomerResponse>> GetCustomers()
        {
            var customers = await _customerRepository.GetAll();

            return _mapper.Map<List<CustomerResponse>>(customers);
        }

        private async Task<Customer> GetCustomer(Guid id) => await _customerRepository.Get(x => x.Id == id);
    }
}
