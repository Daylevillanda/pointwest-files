using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Services
{
    public interface IAuthenticationService
    {
        public void Authenticate(string username, string password);
    }
    public class AuthenticationService: IAuthenticationService
    {
        private UnitOfWork unitOfWork ;
        public AuthenticationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Authenticate(string username, string password)
        {
            //var account = unitOfWork.AccountRepository.FindByUsername(username);
            //if (account.)


            //var account = unitOfWork.AccountRepository.FindByUsername(username);
            //if(account.Username != username)
            //{
            //    throw new Exception("Username not found");
            //}
            //if(account.Password != password)
            //{
            //    throw new Exception("Invalid credential");
            //}
        }
    }
}
