using Microsoft.AspNetCore.Mvc;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;

namespace Proj_Ecorush.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly IUser _user;

    public UserController(IUser user)
    {
        _user = user;
    }

    [HttpPost]
    public async Task<string?> AddUser([FromBody] Userinfo userinfo)
    {
        try
        {
            await _user.AddUser(userinfo);
            return "User Added Nice ^^";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // throw;
            return BadRequest(e.Message).ToString();
        }
    }
}