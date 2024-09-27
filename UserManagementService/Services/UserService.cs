using System.Linq;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly List<UserModel> _users = new ();

        public UserModel RegisterUser(UserModel user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return user;
        }

        public UserModel Authenticate(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password)!;
        }
    }
}
