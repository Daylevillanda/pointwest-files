using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Attributes;

namespace WebApiDemo.Controllers
{
    [Route("gtg")]
    [ApiController]
    [ApiKeyAttribute] //using attribute, disable the middleware in the startup
    public class GtgController : ControllerBase
    {

        public string Get()
        {
            return "Some useful information";
        }

    }
}
