using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Data;
using WebApiDemo.DataTransferObjects;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public ProductController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await UnitOfWork.ProductRepository.FindAll();

            return Ok(products);
        }

        [HttpGet("actions/paginate")]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] PagedDTO pagedDTO)
        {
            var products = await UnitOfWork.ProductRepository.Paginate(pagedDTO);

            return Ok(products);
        }

        [HttpGet("actions/paginate-withinfo")]
        public async Task<IActionResult> GetPaginatedProductsWithInfo([FromQuery] PagedDTO pagedDTO)
        {
            var products = await UnitOfWork.ProductRepository.PaginateWithInfo(pagedDTO);

            return Ok(products);
        }

        [HttpGet("actions/find-by-price")]
        public async Task<IActionResult> GetProductsByPrice([FromQuery] SearchProductByPriceParametersPagedDTO searchParamsDTO)
        {
            var products = await UnitOfWork.ProductRepository.FindProductsByPrice(searchParamsDTO);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await UnitOfWork.ProductRepository.FindByPrimaryKey(id);

            if (product is object)
            {
                return Ok(product);
            }


            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var newProduct = await UnitOfWork.ProductRepository.Insert(product);
                await UnitOfWork.CommitAsync();

                return StatusCode(StatusCodes.Status201Created, product);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                UnitOfWork.ProductRepository.Update(product);
                await UnitOfWork.CommitAsync();

                return Ok(product);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await UnitOfWork.ProductRepository.FindByPrimaryKey(id);

            if (product == null)
            {
                return BadRequest();
            }

            await UnitOfWork.ProductRepository.Delete(id);
            await UnitOfWork.CommitAsync();

            return Ok(product);
        }
    }
}
