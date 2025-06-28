using BlogManagementSystem.Application.DTOs.Auth;
using BlogManagementSystem.Application.Interfaces;
using BlogManagementSystem.Domain.Entities;
using BlogManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlogManagementSystem.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterRequestDto dto)
        {
            if(await _context.Users.AnyAsync(x => x.Email == dto.Email))
            {
                throw new Exception("Bu e-posta zaten kayıtlı!");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                UserName = dto.UserName,
                PasswordHash = HashPassword(dto.Password),
                Role = "Writer"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return GenerateToken(user);
        }

        public async Task<string> LoginAsync(LoginRequestDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if(user == null || !VerifyPassword(dto.Password, user.PasswordHash)) 
            {
                throw new Exception("Geçersiz kullanıcı adı ve şifre");
            }

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var secretKey = _configuration["JwtSettings:Secret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var hashed = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashed);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
