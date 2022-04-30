using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operas.Data.Models
{
    public class Opera : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Composer { get; set; }
    }
}
