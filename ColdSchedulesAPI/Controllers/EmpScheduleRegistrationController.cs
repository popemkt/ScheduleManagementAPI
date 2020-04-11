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
        public IActionResult GetScheduleForWeek(int empID, DateTime start, DateTime end)
        {
            try
            {
                var empSRDomain = Service<IEmpScheduleRegistrationDomain>();
                var result = empSRDomain.GetScheduleForWeek(empID, start, end);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpPost("")]
        public IActionResult CreateScheduleForWeek([FromBody]EmpScheduleRegistrationViewModel model)
        {
            try
            {
                var empSRDomain = Service<IEmpScheduleRegistrationDomain>();

                empSRDomain.CreateScheduleForWeek(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpPut("")]
        public IActionResult UpdateScheduleForWeek([FromBody]EmpScheduleRegistrationViewModel model)
        {
            try
            {
                var empSRDomain = Service<IEmpScheduleRegistrationDomain>();
                var result = empSRDomain.UpdateScheduleForWeek(model);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }
    }
}