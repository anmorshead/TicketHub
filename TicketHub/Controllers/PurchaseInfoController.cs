using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace TicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInfoController : Controller
    {
        private readonly ILogger<PurchaseInfoController> _logger;
        private readonly IConfiguration _configuration;
        public PurchaseInfoController(ILogger<PurchaseInfoController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Contacts controller - GET");
        }

        [HttpPost]
        public async Task<IActionResult> Post(PurchaseInfo purchaseInfo)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            //
            //POST  purchases to queue
            //

            string queueName = "purchases";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(purchaseInfo);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("success - message posted to storage queue");
        }
    }

}
