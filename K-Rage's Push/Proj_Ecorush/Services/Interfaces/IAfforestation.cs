using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces
{
    public interface IAfforestation
    {
        Task<List<Afforestation>> GetAllActivitiesAF();
        Task<List<Afforestation>> GetAFbyEmail(string email);
        Task<string> AddNewActivityAF(Afforestation afforestation);
        Task<string> UpdateActivityAF(int ActivityID, Afforestation afforestation);
        Task<List<Afforestation>> GetAFbyStatus(string status);
    }
}
