using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalkCycleController : ControllerBase
    {
        public IWalkingCycle? _walkingCycles;

        public WalkCycleController(IWalkingCycle? walkingCycles)
        {
            _walkingCycles = walkingCycles;
        }

        [HttpGet]
        public async Task<ActionResult<List<WalkCycle>>> GetAllActivitiesWC()
        {
            var activities = await _walkingCycles.GetAllActivitiesWC();

            if (activities == null)
            {
                return NotFound("Activity list Empty");
            }
            return Ok(activities);
        }

        [HttpGet("/getByEmail/{email}")]
        public async Task<ActionResult<List<WalkCycle>>> GetWCbyEmail(string email)
        {
            var activities = await _walkingCycles.GetWCbyEmail(email);

            if(activities == null)
            {
                return NotFound("Activity list empty");
            }
            return Ok(activities);

        }

        [HttpGet("/getByStatus/{status}")]
        public async Task<ActionResult<List<WalkCycle>>> GetWCbyStatus(string status)
        {
            var activities = await _walkingCycles.GetWCbyStatus(status);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }
            return Ok(activities);

        }

        [HttpPost]
        public async Task<ActionResult<string>> AddNewActivityWC(WalkCycle walkCycle)
        {
            return await _walkingCycles.AddNewActivityWC(walkCycle);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateActivityWC(int activityID, WalkCycle walkCycle)
        {
            try
            {
                var activity = await _walkingCycles.UpdateActivityWC(activityID, walkCycle);
                return Ok("Updated Successfully");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
