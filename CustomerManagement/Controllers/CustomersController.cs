using CustomerManagement.Models;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerService service, ILogger<CustomersController> logger)
        {
            _customerService = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            _logger.LogInformation("Listing all customers");
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpPost]
        public ActionResult<Customer> Add([FromBody] Customer customer)
        {

            var id = _customerService.AddCustomer(customer);
            _logger.LogInformation($"Added Customer with ID: {id}");
            return CreatedAtAction(nameof(GetAll), new {id});
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var removed = _customerService.RemoveCustomer(id);
            if (!removed)
            {
                _logger.LogWarning($"Removing Customer failed. Customer with ID {id} does not exist.");
                return NotFound(new { Message = $"Customer with ID {id} not found." });
            }

            _logger.LogInformation($"Customer with ID {id} removed.");
            return Ok(new { Message = $"Customer with ID {id} removed." });
        }
    }
}
