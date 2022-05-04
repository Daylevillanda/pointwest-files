using WebApiDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        public IProductRepository ProductRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IProductOrderRepository ProductOrderRepository { get; }
        public IOrderRepository OrderRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private OnlineShopContext context;

        public IProductRepository ProductRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IProductOrderRepository ProductOrderRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }

        public UnitOfWork(OnlineShopContext context)
        {
            this.context = context;
            this.ProductRepository = new ProductRepository(context);
            this.CustomerRepository = new CustomerRepository(context);
            this.ProductOrderRepository = new ProductOrderRepository(context);
            this.OrderRepository = new OrderRepository(context);
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
