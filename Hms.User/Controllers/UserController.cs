using Hms.Common.Dao;
using Hms.User.Dao.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Hms.User.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IAppDbContext<UserEntity> _userDbContext;

    public UserController(IAppDbContext<UserEntity> userDbContext)
    {
        _userDbContext = userDbContext;
    }
    
    [HttpGet]
    public string Get()
    {
        var userEntities = _userDbContext.Entity.ToList();
        Console.WriteLine(userEntities);
        return "Hello World";
    }
}