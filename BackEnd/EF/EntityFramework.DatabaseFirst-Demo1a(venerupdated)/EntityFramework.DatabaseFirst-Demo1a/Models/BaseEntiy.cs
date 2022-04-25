using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DatabaseFirst_Demo1a.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
