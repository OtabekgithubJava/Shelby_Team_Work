using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }
    
    // Action - controllergi method, bitta http messageni handle qiladi

    [HttpGet("[action]")]
    public ValueTask<IActionResult> GetUsers()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("[action]")]
    public ValueTask<IActionResult> GetById()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("[action]")]
    public ValueTask<IActionResult> CreateUser()
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("[action]")]
    public ValueTask<IActionResult> UpdateUser()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("[action]")]
    public ValueTask<IActionResult> DeleteUser()
    {
        throw new NotImplementedException();
    }
    
}
