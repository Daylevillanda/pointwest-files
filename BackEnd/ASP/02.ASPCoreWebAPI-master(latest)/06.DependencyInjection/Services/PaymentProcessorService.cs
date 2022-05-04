using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDemo.Services
{
    public interface IPaymentProcessorService
    {
        string processPayment();
    }

    public class PaypalPaymentProcessorService : IPaymentProcessorService
    {
        public string processPayment()
        {
            return "paypal";
        }
    }

    public class GcashPaymentProcessorService : IPaymentProcessorService
    {
        public string processPayment()
        {
            return "gcash";
        }
    }

    public class PaymayaPaymentProcessorService : IPaymentProcessorService
    {
        public string processPayment()
        {
            return "paymaya";
        }
    }

}
