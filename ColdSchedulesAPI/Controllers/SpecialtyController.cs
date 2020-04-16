using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColdSchedulesData.Domain;
using ColdSchedulesData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColdSchedulesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/specialty")]
    public class SpecialtyController : BaseController
    {
        [HttpGet("")]
        public IActionResult GetSpecialties()
        {
            try
            {
                var specDomain = Service<ISpecialtyDomain>();
                var result = specDomain.GetSpecialties();

                return Ok(new ResponseViewModel { Data = result, Success = true });
            }
            catch(Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Success = false, Message = e.Message });
            }

        }
    }
}