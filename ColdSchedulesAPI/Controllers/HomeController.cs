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

                if(result != null)
                {
                    return Ok(new ResponseViewModel { Data = result, Success = true });
                }
                else
                {
                    return Ok(new ResponseViewModel { Message = "Invalid username or password", Success = false });
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

           
        }
    }
}