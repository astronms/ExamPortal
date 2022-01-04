using System.Threading.Tasks;
using ExamPortal.Models.Users;

namespace ExamPortal.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDto);
        Task<string> CreateToken();
    }
}
