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
        public IActionResult Post(PurchaseInfo purchaseInfo)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return Ok("Hello" + purchaseInfo.Name + " from Contacts controller - POST");
        }
    }

}
