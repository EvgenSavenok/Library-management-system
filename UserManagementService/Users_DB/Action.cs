using UserManagementService.Models;

namespace UserManagementService;

public class Actions
{
    public (bool Success, string ErrorMessage) AddUser(UserModel user)
    {
        using (UsersManagementContext db = new UsersManagementContext()) 
        {
            var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
            
            if (existingUser != null)
            {
                return (false, "Пользователь с таким email уже существует.");
            }

            if (user.Password.Length < 4)
            {
                return (false, "Пароль должен быть не менее 4 символов.");
            }

            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role.ToString()
            };

            db.Users.Add(newUser);
            db.SaveChanges();
            return (true, "Пользователь успешно добавлен.");
        }
    }
}
