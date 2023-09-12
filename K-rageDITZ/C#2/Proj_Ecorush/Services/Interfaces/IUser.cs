using Proj_Ecorush.Models;

namespace Proj_Ecorush.Services.Interfaces;

public interface IUser
{
    Task<string> AddUser(Userinfo userinfo);
}