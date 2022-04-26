using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Models
{
    public class Account: BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
