using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces
{
    public interface IPrevAct
    {
        Task<List<PrevAct>> GetPrevAct(string emailID);
    }
}
