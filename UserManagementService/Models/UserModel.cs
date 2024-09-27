namespace UserManagementService.Models;

public class UserModel
{
    public enum UserRole
    {
        Guest,
        User,
        Librarian,
        Admin
    }
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string PasswordConfirmation { get; set; } = "";
    public UserRole Role { get; set; } 
}
