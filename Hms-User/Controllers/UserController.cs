using Microsoft.AspNetCore.Mvc;

namespace Hms_User.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}