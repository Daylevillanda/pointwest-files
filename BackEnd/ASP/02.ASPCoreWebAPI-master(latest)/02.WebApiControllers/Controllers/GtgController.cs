using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Controllers
{
    [Route("gtg")]
    [ApiController]
    public class GtgController : ControllerBase
    {
        private ProgramConfiguration programConfiguration;
        public GtgController(ProgramConfiguration programConfiguration)
        {
            this.programConfiguration = programConfiguration;
        }

        [HttpGet]
        public ProgramConfiguration Get()
        {
            return this.programConfiguration;
        }

    }
}
