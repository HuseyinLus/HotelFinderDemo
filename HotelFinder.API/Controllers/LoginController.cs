using Domain.Entities;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly TokenHandler _tokenHandler;
    private readonly dbContext _context;

    public LoginController(TokenHandler tokenHandler, dbContext context)
    {
        _tokenHandler = tokenHandler;
        _context = context;
    }

    [HttpPost("user-login")]
    public async Task<IActionResult> UserLogin([FromBody] LoginModel model)
    {
        var user = await _context.Registers
            .FirstOrDefaultAsync(u => u.Username == model.UserName
                                   && u.Password == model.Password
                                   && u.Role == "User");

        if (user == null) return Unauthorized("Invalid username or password");

        // Access + Refresh token oluştur
        var token = await _tokenHandler.CreateAccessToken(user);
        return Ok(token);
    }

    [HttpPost("admin-login")]
    public async Task<IActionResult> AdminLogin([FromBody] LoginModel model)
    {
        var admin = await _context.Registers
            .FirstOrDefaultAsync(u => u.Username == model.UserName
                                   && u.Password == model.Password
                                   && u.Role == "Admin");

        if (admin == null) return Unauthorized("Invalid admin credentials");

        var token = await _tokenHandler.CreateAccessToken(admin);
        return Ok(token);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] string refreshToken)
    {
        var tokenEntity = await _context.RefreshTokens
            .FirstOrDefaultAsync(t => t.Token == refreshToken);

        if (tokenEntity == null || tokenEntity.IsRevoked || tokenEntity.Expires < DateTime.UtcNow)
            return Unauthorized("Invalid or expired refresh token");

        var user = await _context.Registers
            .FirstOrDefaultAsync(u => u.Id == tokenEntity.UserId);

        if (user == null) return Unauthorized();

        // Eski tokeni iptal et
        tokenEntity.IsRevoked = true;
        await _context.SaveChangesAsync();

        var newToken = await _tokenHandler.CreateAccessToken(user);
        return Ok(newToken);
    }
}
