using System.Collections.Generic;
using ToyUniverse.Data.Models;

namespace ToyUniverse.Web.Models
{
    public class ToyPage
    {
        public List<Toy> OperaList { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
