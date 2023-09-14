using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers
{
    public class PrevActController : ControllerBase
    {
        public IPrevAct? _prevAct;

        public PrevActController(IPrevAct? prevActs)
        {
            _prevAct = prevActs;
        }

        [HttpGet("/getPrevAct/{email}")]
        public async Task<ActionResult<List<PrevAct>>> GetPrevAct(string email)
        {
            var activities = await _prevAct.GetPrevAct(email);

            if (activities == null)
            {
                return NotFound("Activity list empty");
            }
            return Ok(activities);

        }
    }
}
