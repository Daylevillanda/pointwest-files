using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDemo.Services
{
    public enum PaymentProcessorTypes
    {
        PaypalPaymentProcessor,
        GcashPaymentProcessor,
        PaymayaPaymentProcessor
    }

    public delegate IPaymentProcessorService PaymentProcessorServiceResolver(PaymentProcessorTypes serviceType);
}
