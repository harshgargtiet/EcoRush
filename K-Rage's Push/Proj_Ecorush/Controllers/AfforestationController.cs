using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AfforestationController : ControllerBase
    {
        public IAfforestation? _afforestation;

        public AfforestationController(IAfforestation? afforestations)
        {
            _afforestation = afforestations;
        }

        [HttpGet]
        public async Task<ActionResult<List<Afforestation>>> GetAllActivitiesAF()
        {
            var activities = await _afforestation.GetAllActivitiesAF();

            if (activities == null)
            {
                return NotFound("Activity list Empty");
            }
            return Ok(activities);
        }

        [HttpGet("/getAFByEmail/{email}")]
        public async Task<ActionResult<List<Afforestation>>> GetAFbyEmail(string email)
        {
            var activities = await _afforestation.GetAFbyEmail(email);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }
            return Ok(activities);

        }

        [HttpGet("/getAFByStatus/{status}")]
        public async Task<ActionResult<List<Afforestation>>> GetAFbyStatus(string status)
        {
            var activities = await _afforestation.GetAFbyStatus(status);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }
            return Ok(activities);

        }

        [HttpPost]
        public async Task<ActionResult<string>> AddNewActivityAF(Afforestation afforestation)
        {
            return await _afforestation.AddNewActivityAF(afforestation);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateActivityAF(int activityID, Afforestation afforestation)
        {
            try
            {
                var activity = await _afforestation.UpdateActivityAF(activityID, afforestation);
                return Ok("Updated Successfully");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
