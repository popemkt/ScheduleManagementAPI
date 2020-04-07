using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColdSchedulesData.Domain;
using ColdSchedulesData.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ColdSchedulesAPI.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : BaseController
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody]EmployeesViewModel model)
        {
            try
            {
                var authDomain = Service<IAuthorizationDomain>();

                var result = authDomain.Login(model.Username, model.Password);

                return Ok(new ResponseViewModel { Data = result, Success = true });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

           
        }
    }
}