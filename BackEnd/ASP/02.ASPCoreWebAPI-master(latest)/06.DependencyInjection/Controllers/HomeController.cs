using ApiWebDemo.DataTransfers;
using ApiWebDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebDemo.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly GcashPaymentProcessorService gCashPaymentProcessorService;
        public HomeController(GcashPaymentProcessorService gCashPaymentProcessorService)
        {
            this.gCashPaymentProcessorService = gCashPaymentProcessorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = gCashPaymentProcessorService.processPayment();
            return StatusCode(StatusCodes.Status200OK, new PaymentResponse { Status = result, PaymentMethod = "GCASH" });
        }
    }
}
