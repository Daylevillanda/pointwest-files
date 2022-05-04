using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Settings
{
    public class EmailSettings
    {
        public string SMTPEmail { get; private set; }
        public string SMTPPassword { get; private set; }
        public int SMTPPort { get; private set; }
        public string SMTPHostname { get; private set; }
    }
}
