using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Proj_Ecorush.Services.Services
{
    public class PrevActServices : IPrevAct
    {
        public EcoRushDbContext? _context;
        public PrevActServices(EcoRushDbContext? context)
        {
            _context = context;
        }
        public async Task<List<PrevAct>> GetPrevAct(string emailID)
        {
            List<PrevAct> list = new List<PrevAct>();
            var CpItem = await _context.Carpoolings.Where(x=>x.EmailId==emailID).OrderByDescending(x => x.ActivityDate).FirstOrDefaultAsync();
            if (CpItem != null)
            {
                list.Add(new PrevAct { ActivityType = "Used carpooling to reduce carbon footprints", Ccawarded = CpItem.Ccawarded, Status = CpItem.Status });
            }
            var EvItem = await _context.EvTravels.Where(x => x.EmailId == emailID).OrderByDescending(x => x.ActivityDate).FirstOrDefaultAsync();
            if (EvItem != null)
            {
                list.Add(new PrevAct { ActivityType = "Used EV to reduce carbon footprints", Ccawarded = EvItem.Ccawarded, Status = EvItem.Status });
            }
            var WcItem = await _context.WalkCycles.Where(x => x.EmailId == emailID).OrderByDescending(x => x.ActivityDate).FirstOrDefaultAsync();
            if (WcItem != null)
            {
                list.Add(new PrevAct { ActivityType = "Used cycling to reduce carbon footprints", Ccawarded = WcItem.Ccawarded, Status = WcItem.Status });
            }
            var AfItem = await _context.Afforestations.Where(x => x.EmailId == emailID).OrderByDescending(x => x.ActivityDate).FirstOrDefaultAsync();
            if (AfItem != null)
            {
                list.Add(new PrevAct { ActivityType = "Used afforestation to reduce carbon footprints", Ccawarded = AfItem.Ccawarded, Status = AfItem.Status });
            }

            return list;
        }
    }
}
