using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Domains;

namespace WebApiDemo.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
