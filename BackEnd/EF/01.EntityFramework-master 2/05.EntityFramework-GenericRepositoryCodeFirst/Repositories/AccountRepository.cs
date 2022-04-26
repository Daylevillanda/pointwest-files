using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Repositories
{
    public interface IAccountRepository: IBaseRepository<Account>
    {

    }
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(OnlineShopContext context) : base(context)
        {
        }
    }
}
