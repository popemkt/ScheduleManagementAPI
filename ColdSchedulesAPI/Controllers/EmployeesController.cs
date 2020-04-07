using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColdSchedulesData.Domain;
using ColdSchedulesData.Models;
using ColdSchedulesData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColdSchedulesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : BaseController
    {

        [HttpGet("")]
        public IActionResult GetEmployees()
        {
            try
            {
                var empDomain = Service<IEmployeesDomain>();

                

                return Ok(empDomain.GetEmployees());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateEmployee([FromBody]EmployeesViewModel model)
        {
            try
            {
                var empDomain = Service<IEmployeesDomain>();

                empDomain.CreateEmployees(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateEmployee([FromBody]EmployeesViewModel model)
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
        public IActionResult DeleteEmployee([FromBody]EmployeesViewModel model)
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