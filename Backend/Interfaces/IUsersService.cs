using Backend.Domain.Models;

namespace Backend.Interfaces
{
    public interface IUsersService
    {
        Task<string> LoginAsync(string username, string password);
        Task<Developer> RegisterAsync(string username, string password,string email); 
        Task<Developer> UpdateAsync(string username, string email);
        Task<bool> ChangePasswordAsync(string username,string oldPassword,string newPassword);
    }
}
