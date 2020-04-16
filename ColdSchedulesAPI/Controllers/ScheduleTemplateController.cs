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
    [Route("api/template")]

    public class ScheduleTemplateController : BaseController
    {
        [HttpGet("")]
        public IActionResult GetScheduleForWeek(DateTime start, DateTime end)
        {
            try
            {
                var templateDomain = Service<IScheduleTemplateDomain>();
                var result = templateDomain.GetTemplateForWeek(start, end);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpPost("")]
        public IActionResult CreateScheduleForWeek([FromBody]ScheduleTemplateViewModel model)
        {
            try
            {
                var templateDomain = Service<IScheduleTemplateDomain>();

                var result = templateDomain.CreateTemplateForWeek(model);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpPut("")]
        public IActionResult UpdateScheduleForWeek([FromBody]ScheduleTemplateViewModel model)
        {
            try
            {
                var templateDomain = Service<IScheduleTemplateDomain>();
                var result = templateDomain.UpdateTempalteForWeek(model);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }
    }
}