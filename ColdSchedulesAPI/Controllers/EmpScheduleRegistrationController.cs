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
    [Route("api/empsr")]

    public class EmpScheduleRegistrationController : BaseController
    {
        [HttpGet("")]
        public IActionResult GetScheduleForWeek(int id)
        {
            try
            {
                var empSRDomain = Service<IEmpScheduleRegistrationDomain>();
                
                return Ok(empSRDomain.GetScheduleForWeek(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateScheduleForWeek([FromBody]List<EmpScheduleRegistrationViewModel> model)
        {
            try
            {
                var empSRDomain = Service<IEmpScheduleRegistrationDomain>();

                empSRDomain.CreateScheduleForWeek(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateScheduleForWeek([FromBody]List<EmpScheduleRegistrationViewModel> model)
        {
            try
            {
                //var empDomain = dependency injection IDomain
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("")]
        public IActionResult DeleteScheduleForWeek([FromBody]List<EmpScheduleRegistrationViewModel> model)
        {
            try
            {
                //var empDomain = dependency injection IDomain
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}