using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDTO dto)
    {
        var user = new Register
        {
            Username = dto.Username,
            Password = dto.Password, // TODO: Hashle
            Role = dto.Role
        };

        var result = await _userService.AddNewUser(user);
        return Ok(new UserResponseDTO { Id = result.Id, Username = result.Username, Role = result.Role });
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers();
        var response = users.Select(u => new UserResponseDTO { Id = u.Id, Username = u.Username, Role = u.Role }).ToList();
        return Ok(response);
    }
}
