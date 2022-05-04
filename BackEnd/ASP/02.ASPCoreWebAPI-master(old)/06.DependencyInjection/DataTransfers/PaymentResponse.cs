using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDemo.DataTransfers
{
    public class PaymentResponse
    {
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
