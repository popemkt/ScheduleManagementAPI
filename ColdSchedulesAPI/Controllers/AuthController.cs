using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColdSchedulesData.Domain;
using ColdSchedulesData.ViewModels;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ColdSchedulesAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        [HttpPost("login")]
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
        [HttpPost("firebase")]
        public async Task<IActionResult> LoginAsync([FromBody]EmployeesViewModel model)
        {
            try
            {
                var authDomain = Service<IAuthorizationDomain>();
                var decodedTokenModel = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(model.Token);
                var uid = decodedTokenModel.Uid;

                var result = authDomain.LoginFirebase(uid);

                if (result != null)
                {
                    return Ok(new ResponseViewModel { Data = result, Success = true });
                }
                else
                {
                    return Ok(new ResponseViewModel { Message = "Invalid username or password", Success = false });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}