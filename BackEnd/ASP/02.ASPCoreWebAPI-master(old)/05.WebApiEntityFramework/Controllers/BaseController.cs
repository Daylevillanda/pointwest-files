using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
