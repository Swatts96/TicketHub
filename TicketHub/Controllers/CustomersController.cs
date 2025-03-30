using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TicketHubAPI.Models;

namespace TicketHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration _configuration;

        public CustomersController(ILogger<CustomersController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CustomersController is running. Ready to accept POST requests.");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Retrieve the Azure Storage connection string from configuration
                var connectionString = _configuration.GetConnectionString("AzureStorage");

                // Name of the queue
                var queueName = "tickethub";

                // Logging connections string
                _logger.LogInformation("AzureStorage Connection String: {ConnectionString}", connectionString);

                // Create the queue client and ensure the queue exists
                var queueClient = new QueueClient(connectionString, queueName);
                await queueClient.CreateIfNotExistsAsync();

                // Serialize the payload to JSON and encode it in Base64
                var jsonPayload = JsonSerializer.Serialize(customer);
                var base64Message = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonPayload));

                // Send the message to the queue
                await queueClient.SendMessageAsync(base64Message);

                return Ok(new { message = "Purchase received and added to queue." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding message to queue.");
                return StatusCode(500, new { message = "Error processing purchase request." });
            }
        }
    }

}
