using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.DataTransferObjects
{
    public class CustomerOrderDTO
    {
        public Guid CustomerId { get; set; }

        public string FullName { get; set; }

        public Guid OrderId { get; set; }

        public DateTime OrderPlaced { get; set; }
    }

    public class CustomersOrderIdListDTO
    {
        public Guid CustomerId { get; set; }

        public IEnumerable<Guid> OrderIdList { get; set; }
    }
}
