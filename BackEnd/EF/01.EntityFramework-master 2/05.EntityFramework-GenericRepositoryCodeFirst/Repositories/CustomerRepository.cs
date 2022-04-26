using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.DataTransferObjects;
using EntityFrameworkDemo.Exceptions;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<CustomerOrderDTO> FindCustomerOrders(Guid customerId);

        IEnumerable<CustomersOrderIdListDTO> FindCustomerOrderIdList(Guid customerId);
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<CustomerOrderDTO> FindCustomerOrders(Guid customerId)
        {
            var customerOrders = this.Context.Customers.Join(
                this.Context.Orders,
                customer => customer.Id,
                order => order.Customer.Id,
                (customer, order) => new CustomerOrderDTO
                {
                    CustomerId = customer.Id,
                    FullName = $"{customer.FirstName} {customer.LastName}",
                    OrderId = order.Id,
                    OrderPlaced = order.OrderPlaced
                }
            ).Where(c => c.CustomerId == customerId).ToList();

            return customerOrders;
        }

        public IEnumerable<CustomersOrderIdListDTO> FindCustomerOrderIdList(Guid customerId)
        {
            var customerOrders = this.Context.Customers.GroupJoin(
                this.Context.Orders,
                customer => customer.Id,
                order => order.Customer.Id,
                (customer, order) => new CustomersOrderIdListDTO
                {
                    CustomerId = customer.Id,
                    OrderIdList = order.Select(o => o.Id).ToList()
                }
            ).Where(c => c.CustomerId == customerId).ToList();

            return customerOrders;
        }
    }
}
