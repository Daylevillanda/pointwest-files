using ApiWebDemo.DataTransfers;
using ApiWebDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Controllers
{
    [Route("payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService paymentService;
        private IPaymentProcessorService paypalPaymentProcessorService;
        private IPaymentProcessorService gcashPaymentProcessorService;
        private IPaymentProcessorService paymayaPaymentProcessorService;

        public PaymentController(IPaymentService paymentService, PaymentProcessorServiceResolver serviceResolver)
        {
            this.paymentService = paymentService;
            this.paypalPaymentProcessorService = serviceResolver(PaymentProcessorTypes.PaypalPaymentProcessor);
            this.gcashPaymentProcessorService = serviceResolver(PaymentProcessorTypes.GcashPaymentProcessor);
            this.paymayaPaymentProcessorService = serviceResolver(PaymentProcessorTypes.PaymayaPaymentProcessor);
        }

        [HttpGet("credit-card")]
        public IActionResult CreditCard()
        {

            if (paymentService.processPayment())
            {
                return StatusCode(StatusCodes.Status200OK, new PaymentResponse { Status = "Success ", PaymentMethod = "CreditCard" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new PaymentResponse { Status = "Failed ", PaymentMethod = "CreditCard" });
        }

        [HttpGet("paypal")]
        public IActionResult PayPal()
        {
            return StatusCode(StatusCodes.Status200OK, new PaymentResponse { Status = "Success ", PaymentMethod = paypalPaymentProcessorService.processPayment() });
        }

        [HttpGet("gcash")]
        public IActionResult GCash()
        {
            return StatusCode(StatusCodes.Status200OK, new PaymentResponse { Status = "Success ", PaymentMethod = gcashPaymentProcessorService.processPayment() });
        }

        [HttpGet("paymaya")]
        public IActionResult PayMaya()
        {
            return StatusCode(StatusCodes.Status200OK, new PaymentResponse { Status = "Success ", PaymentMethod = paymayaPaymentProcessorService.processPayment() });
        }

    }
}
