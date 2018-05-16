using System.Threading.Tasks;
using BaseBackend.API.Models;

namespace BaseBackend.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> CompleteRegister(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}