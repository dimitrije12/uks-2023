using Backend.Domain.Models;
using Backend.Infrastructure;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services
{
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IConfigurationSection _secretKey;
        public UsersService(DatabaseContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _secretKey = config.GetSection("SecretKey");
        }

        public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(newPassword) || String.IsNullOrEmpty(oldPassword))
            {
                throw new ApplicationException("Some values are empty!");
            }
            Developer? developerToChangePassword = await _dbContext.Developers.FirstOrDefaultAsync(x => x.Username == username);
            if (developerToChangePassword == null)
            {
                throw new ApplicationException("User with that username doesn't exist! ");
            }
            if (BCrypt.Net.BCrypt.Verify(oldPassword, developerToChangePassword.Password))
            {
                developerToChangePassword.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _dbContext.Developers.Update(developerToChangePassword);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            throw new ApplicationException("The passwords aren't equal! ");
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            Developer? user = await _dbContext.Developers.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                throw new ApplicationException("User with that username doesn't exist!");
            }
            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "developer"));
                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "server",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );
                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
            else
            {
                throw new ApplicationException("Invalid password!");
            }
        }

        public async Task<Developer> RegisterAsync(string username, string password, string email)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email))
            {
                throw new ApplicationException("Some values are empty!");
            }
            if (await _dbContext.Developers.AnyAsync(x => x.Username == username || x.Email == email))
            {
                throw new ApplicationException("User with that email or username already exists!");
            }
            Developer? developer = new Developer { Username = username, Password = BCrypt.Net.BCrypt.HashPassword(password), Email = email };
            Developer? retVal = (await _dbContext.Developers.AddAsync(developer)).Entity;
            await _dbContext.SaveChangesAsync();
            return retVal;
        }

        public async Task<Developer> UpdateAsync(string username, string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ApplicationException("Email value is empty! ");
            }
            Developer? developerToUpdate = await _dbContext.Developers.FirstOrDefaultAsync(x => x.Username == username);
            if (developerToUpdate == null)
            {
                throw new ApplicationException("Invalid username! ");
            }
            developerToUpdate.Email = email;
            _dbContext.Developers.Update(developerToUpdate);
            await _dbContext.SaveChangesAsync();
            return developerToUpdate;
        }
    }
}
