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
                var result = empDomain.GetEmployees();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var empDomain = Service<IEmployeesDomain>();
                var result = empDomain.GetEmployee(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpPost("")]
        [Authorize(Roles = Role.Admin)]
        public IActionResult CreateEmployee([FromBody]EmployeesViewModel model)
        {
            try
            {
                var empDomain = Service<IEmployeesDomain>();
                var result = empDomain.CreateEmployees(model);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpPut("")]
        public IActionResult UpdateEmployee([FromBody]EmployeesViewModel model)
        {
            try
            {
                var empDomain = Service<IEmployeesDomain>();
                var result = empDomain.UpdateEmployees(model);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var empDomain = Service<IEmployeesDomain>();
                var result = empDomain.DeleteEmployees(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResponseViewModel { Message = e.Message, Success = false });
            }
        }
    }
}