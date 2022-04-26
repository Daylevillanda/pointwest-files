using EntityFrameworkDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Data
{
    public interface IUnitOfWork
    {
        int Commit();

        public ProductRepository ProductRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private static UnitOfWork instance;

        private OnlineShopContext context;
        private ProductRepository productRepository;

        public UnitOfWork()
        {
            this.context = new OnlineShopContext();
            this.productRepository = new ProductRepository(context);
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }

        public ProductRepository ProductRepository
        {
            get
            {
                return this.productRepository;
            }
        }

        public static UnitOfWork GetInstance()
        {
            if (instance == null)
            {
                instance = new UnitOfWork();
            }

            return instance;
        }
    }
}
