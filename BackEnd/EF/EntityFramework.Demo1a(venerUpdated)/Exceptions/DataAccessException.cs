using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Demo1a.Exceptions
{
    public class DataAccessException: Exception
    {
        private DataAccessException(): this("Data Access Error")
        {

        }

        private DataAccessException(string message): base(message)
        {

        }

        public static DataAccessException instance(string message)
        {
            return new DataAccessException(message);
        }
    }
}
