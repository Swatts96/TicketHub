using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketHub.Controllers;

namespace TicketHubapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration? _configuration;
        private IConfiguration? configuration;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello from customers controller - GET");
        }

        [HttpPost]
        public IActionResult Post(Customers customers)
        {
            return Ok("Hello from contact controller);
        }
    }
}
