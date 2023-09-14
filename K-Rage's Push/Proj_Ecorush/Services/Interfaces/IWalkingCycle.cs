using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces
{
    public interface IWalkingCycle
    {
        Task<List<WalkCycle>> GetAllActivitiesWC();
        Task<List<WalkCycle>> GetWCbyEmail(string email);
        Task<string> AddNewActivityWC(WalkCycle walkCycle);
        Task<string> UpdateActivityWC(int ActivityID, string StatusApproved);
        Task<List<WalkCycle>> GetWCbyStatus(string status);
    }
}
