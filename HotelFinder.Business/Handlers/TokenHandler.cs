using Domain.Entities;
using HotelFinder.Business.Models;
using HotelFinder.DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class TokenHandler
{
    private readonly IConfiguration _configuration;
    private readonly dbContext _context;

    public TokenHandler(IConfiguration configuration, dbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<TokenResponse> CreateAccessToken(Register user)
    {
        var token = new TokenResponse();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role ?? "User")
        };

        token.Expiration = DateTime.UtcNow.AddMinutes(15);

        var jwtToken = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: token.Expiration,
            signingCredentials: creds
        );

        token.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        token.RefreshToken = await CreateRefreshTokenAsync(user.Id);

        return token;
    }

    private async Task<string> CreateRefreshTokenAsync(int userId)
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        var refreshToken = Convert.ToBase64String(randomNumber);

        var refreshEntity = new RefreshTokenEntities
        {
            Token = refreshToken,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        _context.RefreshTokens.Add(refreshEntity);
        await _context.SaveChangesAsync();

        return refreshToken;
    }
}
