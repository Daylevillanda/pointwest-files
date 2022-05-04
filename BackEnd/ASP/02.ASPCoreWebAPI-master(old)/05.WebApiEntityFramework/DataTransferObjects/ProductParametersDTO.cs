using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.DataTransferObjects
{
    public class SearchProductByPriceParametersDTO
    {
        public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; }
    }

    public class SearchProductByPriceParametersPagedDTO : PagedDTO
    {
        public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; }
    }
}
