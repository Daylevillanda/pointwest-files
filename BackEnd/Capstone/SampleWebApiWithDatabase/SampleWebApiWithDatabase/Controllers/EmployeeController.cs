using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiWithDatabase.Data;
using SampleWebApiWithDatabase.Models;
using System.Threading.Tasks;

namespace SampleWebApiWithDatabase.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var employees = await UnitOfWork.EmployeeRepository.FindAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var employee = await UnitOfWork.EmployeeRepository.FindByPrimaryKey(id);
            if (employee is object)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = await UnitOfWork.EmployeeRepository.Insert(employee);
                await UnitOfWork.CommitAsync();

                return StatusCode(StatusCodes.Status201Created, employee);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                UnitOfWork.EmployeeRepository.Update(employee);
                await UnitOfWork.CommitAsync();

                return Ok(employee);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var employee = await UnitOfWork.EmployeeRepository.FindByPrimaryKey(id);

            if (employee == null)
            {
                return BadRequest();
            }

            await UnitOfWork.EmployeeRepository.Delete(id);
            await UnitOfWork.CommitAsync();

            return Ok(employee);
        }
    }
}
