using Microsoft.AspNetCore.Mvc;
using netCore.RateLimiting.Application.Requests;
using netCore.RateLimiting.Application.Responses;
using netCore.RateLimiting.Application.Services;

namespace netCore.RateLimiting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var response = await _customerService.CreateCustomer(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponse>> UpdateCustomer([FromRoute] Guid id,
            [FromBody] UpdateCustomerRequest request)
        {
            var response = await _customerService.UpdateCustomer(id, request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var response = await _customerService.DeleteCustomer(id);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerById([FromRoute] Guid id)
        {
            var response = await _customerService.GetCustomerById(id);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerResponse>>> GetCustomers()
        {
            var response = await _customerService.GetCustomers();
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
