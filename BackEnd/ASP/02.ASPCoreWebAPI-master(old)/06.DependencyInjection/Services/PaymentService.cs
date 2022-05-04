using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDemo.Services
{
    public interface IPaymentService
    {
        bool processPayment();
    }

    public class CreditCardPaymentService : IPaymentService
    {
        public bool processPayment()
        {
            return true;
        }
    }
}
