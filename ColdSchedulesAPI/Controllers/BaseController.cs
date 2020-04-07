using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ColdSchedulesAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected T Service<T>()
        {
            return HttpContext.RequestServices.GetService<T>();
        }
    }
}