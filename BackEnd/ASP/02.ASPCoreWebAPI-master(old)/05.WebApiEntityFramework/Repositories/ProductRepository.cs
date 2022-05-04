using WebApiDemo.Data;
using WebApiDemo.Exceptions;
using WebApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.DataTransferObjects;

namespace WebApiDemo.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> FindProductsByName(string name);

        Task<PagedListDTO<Product>> FindProductsByPrice(SearchProductByPriceParametersPagedDTO pagedDTO);
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> FindProductsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EntityDataException("Name cannot be null or empty.");
            }

            var products = await this.Context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
            return products;
        }

        public async Task<PagedListDTO<Product>> FindProductsByPrice(SearchProductByPriceParametersPagedDTO pagedDTO)
        {
            var query = this.Context.Products.Where(p => p.Price >= pagedDTO.MinimumPrice && p.Price <= pagedDTO.MaximumPrice);
            return await PagedListDTO<Product>.ToPagedList(query, pagedDTO.PageNumber, pagedDTO.PageSize);
        }
    }
}
