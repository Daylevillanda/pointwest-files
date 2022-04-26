using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Exceptions
{
    public class EntityDataException : Exception
    {
        public EntityDataException()
        {
        }

        public EntityDataException(string message)
            : base(message)
        {
        }

        public EntityDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
