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
    [Route("api/arrange")]
    public class ArrangedScheduleController : BaseController
    {
        [HttpPost("")]
        public IActionResult Arrange(DateTime start, DateTime end)
        {
            try
            {
                var arrDomain = Service<IArrangedScheduleDomain>();
                var result = arrDomain.ArrangeSchedule(start, end);
                
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpGet("")]
        public IActionResult GetArrange(DateTime start, DateTime end)
        {
            try
            {
                var arrDomain = Service<IArrangedScheduleDomain>();
                var result = arrDomain.GetArrangeSchedule(start, end);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpGet("dashboard")]
        public IActionResult GetArrangeDash(DateTime start, DateTime end)
        {
            try
            {
                var arrDomain = Service<IArrangedScheduleDomain>();
                var result = arrDomain.GetArrangedDash(start, end);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpGet("detail")]
        public IActionResult GetArrangeSlot(DateTime date, int slot)
        {
            try
            {
                var arrDomain = Service<IArrangedScheduleDomain>();
                var result = arrDomain.GetArrangedBySlot(date, slot);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }
    }
}