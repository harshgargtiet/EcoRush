using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.Services
{
    public class WalkCycleServices : IWalkingCycle
    {
        public EcoRushDbContext? _context;

        public WalkCycleServices(EcoRushDbContext? context)
        {
            _context = context;
        }
        public async Task<string> AddNewActivityWC(WalkCycle walkCycle)
        {
            _context.WalkCycles.Add(walkCycle);
            await _context.SaveChangesAsync();

            return "Activity successfully saved";
        }

        public async Task<List<WalkCycle>> GetWCbyStatus(string status)
        {
            List<WalkCycle> walkCycles = await _context.WalkCycles.ToListAsync();
            walkCycles = walkCycles.Where(wc => wc.Status == status).ToList();

            if (walkCycles == null)
            {
                throw new Exception();
            }

            return walkCycles;
        }

        public async Task<List<WalkCycle>> GetAllActivitiesWC()
        {
            
            List<WalkCycle> walkCycles = await _context.WalkCycles.ToListAsync();
            return walkCycles;
        }

        public async Task<List<WalkCycle>> GetWCbyEmail(string email)
        {
            List<WalkCycle> walkCycles = await _context.WalkCycles.ToListAsync();
            walkCycles = walkCycles.Where(wc=>wc.EmailId==email).ToList();

            if (walkCycles == null)
            {
                throw new Exception();
            }

            return walkCycles;
        }

        public async Task<string> UpdateActivityWC(int activityID, WalkCycle walkCycle)
        {
            var walkCycles = await _context.WalkCycles.FindAsync(activityID);



            if (walkCycles == null)
            {
                throw new Exception();
            }
            else
            {
                walkCycles.Evidence = walkCycle.Evidence;
                walkCycles.Distance = walkCycle.Distance;
                walkCycles.ActivityDate = walkCycle.ActivityDate;
                walkCycles.Ccawarded = walkCycle.Ccawarded;
                walkCycles.Status = walkCycle.Status;
                await _context.SaveChangesAsync();

                return "Update was successfull";
            }
        }
    }
}
