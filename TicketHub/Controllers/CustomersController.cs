using Microsoft.AspNetCore.Mvc;
using TicketHubAPI.Models;

namespace TicketHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration _configuration;

        // Constructor injection for both logger and configuration
        public CustomersController(ILogger<CustomersController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from CustomersController - GET");
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            // Basic validation (note: model binding + [Required] annotations do most of this)
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return BadRequest("First name is invalid.");
            }

            if (string.IsNullOrEmpty(customer.LastName))
            {
                return BadRequest("Last name is invalid.");
            }

            return Ok("Hello " + customer.FirstName + " from CustomersController");
        }
    }
}
