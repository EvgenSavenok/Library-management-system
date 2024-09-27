using UserManagementService.Models;

namespace UserManagementService.Services;

public interface IUserService
{
    UserModel RegisterUser(UserModel user);
    UserModel Authenticate(string email, string password);
    //bool IsEmailTaken(string email);
}
