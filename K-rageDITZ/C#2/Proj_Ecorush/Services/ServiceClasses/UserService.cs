using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Services.ServiceClasses;

public class UserService: IUser
{
    private readonly EcoRushDbContext? _ecoRushDbContext;

    public UserService(EcoRushDbContext ecoRushDbContext)
    {
        _ecoRushDbContext = ecoRushDbContext;
    }

    public async Task<string> AddUser(Userinfo userinfo)
    {
        _ecoRushDbContext.Add(userinfo);
        await _ecoRushDbContext.SaveChangesAsync();

        return "Saved User! :D";
    }
}