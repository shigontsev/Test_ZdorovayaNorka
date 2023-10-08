using Microsoft.AspNetCore.Mvc;
using System;
using ZdorovayaNorka.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZdorovayaNorka.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckpointController : ControllerBase
    {
        private readonly IShiftManagerService _shiftManagerService;

        public CheckpointController(IShiftManagerService shiftManagerService)
        {
            _shiftManagerService = shiftManagerService;
        }


        //2022-01-01T12:00:00.000Z
        [HttpPost("StartShift/{employee_id}/{start_dateTime}")]
        public IActionResult StartShift(int employee_id, DateTime start_dateTime)
        {
            var result = _shiftManagerService.StartShift(employee_id, start_dateTime);
            if (result)
            {
                return Ok(200);
            }
            return BadRequest(400);
        }

        //2022-01-01T15:00:00.000Z
        [HttpPut("EndShift/{employee_id}/{end_dateTime}")]
        public IActionResult EndShift(int employee_id, DateTime end_dateTime)
        {
            var result = _shiftManagerService.EndShift(employee_id, end_dateTime);
            if (result)
            {
                return Ok(200);
            }
            return BadRequest(400);
        }
    }
}
