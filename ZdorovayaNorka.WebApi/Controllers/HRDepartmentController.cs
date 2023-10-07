using Microsoft.AspNetCore.Mvc;
using ZdorovayaNorka.Common.Entities;
using ZdorovayaNorka.Service.Interfaces;
using System.Text.Json;
using System.Collections.Generic;
using ZdorovayaNorka.Common.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZdorovayaNorka.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRDepartmentController : ControllerBase
    {
        private readonly IEmployeeManagerService _employeeManagerService;

        public HRDepartmentController(IEmployeeManagerService employeeManagerService)
        {
            _employeeManagerService = employeeManagerService;
        }

        [HttpPost("Create/{lastname}/{firstname}/{positionId}")]
        public IActionResult Create(string lastname, string firstname, string? middlename, int positionId)
        {
            if (string.IsNullOrWhiteSpace(lastname) ||
                string.IsNullOrWhiteSpace(firstname) ||
                positionId == 0)
                return BadRequest(400);

            var employee = new Employee()
            {
                FirstName = firstname.Trim(),
                LastName = lastname.Trim(),
                MiddleName = string.IsNullOrWhiteSpace(middlename) ? null: middlename.Trim(),
                PositionId = positionId
            };

            var result = _employeeManagerService.Create(employee);

            if (result != null)
            {
                //return Ok(result);
                return Ok(JsonSerializer.Serialize(result));
            }

            return BadRequest(400);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeManagerService.Delete(id);
            if (!result)
                return BadRequest(400);
            return Ok(200);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, string? lastname, string? firstname, string? middlename, int position_id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(lastname) ||
                string.IsNullOrWhiteSpace(firstname) ||
                position_id <= 0)
            {
                return BadRequest(400);
            }
            var employee = new Employee()
            {
                Id = id,
                LastName = lastname,
                FirstName = firstname.Trim(),
                MiddleName = string.IsNullOrWhiteSpace(middlename) ? null : middlename.Trim(),
                PositionId = position_id
            };

            var result = _employeeManagerService.Update(employee);

            if (result != null)
            {
                return Ok(JsonHelper.Serialize(result));
            }
            return BadRequest(400);
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees(int? position_id)
        {
            string result = "";
            if (position_id is null)
            {
                result = JsonHelper.Serialize(_employeeManagerService.GetAllEmployees());
            }
            else
            {
                result = JsonHelper.Serialize(_employeeManagerService.GetAllEmployees(position_id.Value));
            }
            return Ok(result);
        }

        [HttpGet("GetAllPositions")]
        public IActionResult GetAllPositions()
        {
            string result = result = JsonHelper.Serialize(_employeeManagerService.GetAllPositions());
            return Ok(result);
        }

        //// GET: api/<EmployeeManagerController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<EmployeeManagerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EmployeeManagerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EmployeeManagerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EmployeeManagerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
