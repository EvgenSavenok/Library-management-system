using Microsoft.AspNetCore.Mvc;
using UserManagementService.Models;
using UserManagementService.Services;

namespace UserManagementService.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private void InitializeUsersDb()
        {
            using (UsersManagementContext db = new UsersManagementContext())
            {
                // User tom = new User { FirstName = "Tom", LastName = "Smith", 
                //    Email = "1@rambler.ru", Password = "1111"};
                //
                // db.Users.Add(tom);
                // db.SaveChanges();
                // Console.WriteLine("Объекты успешно сохранены");
                
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.FirstName} - {u.LastName} - {u.Email} - " +
                                      $"{u.Password}");
                }
            }
        }
        public AccountController(IUserService userService)
        {
            _userService = userService;
            InitializeUsersDb();
        }
        
        public IActionResult RoleSelection()
        {
            var userModel = new UserModel(); 
            userModel.Role = UserModel.UserRole.Guest; 
            return View(userModel);
        }
        
        public IActionResult DisplayRegistrationPage(UserModel.UserRole role)
        {
            var user = new UserModel { Role = role };
            return View(user); 
        }
        
        [HttpPost]
        public IActionResult RegisterUser([Bind("FirstName,LastName,Email,Password," +
                                                "PasswordConfirmation,Role")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.RegisterUser(user); 
                return RedirectToAction("DisplayLoginPage"); 
            }
            return View("DisplayRegistrationPage", user); 
        }
        
        public IActionResult DisplayLoginPage()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult DisplayLoginPage([Bind("Email,Password")] UserModel loginModel)
        {
            var user = _userService.Authenticate(loginModel.Email, loginModel.Password);
            if (user != null)
            {
                switch (user.Role)
                {
                    case UserModel.UserRole.User:
                        return Redirect("/UserDashboard");
                    case UserModel.UserRole.Librarian:
                        return Redirect("/LibrarianDashboard");
                    case UserModel.UserRole.Admin:
                        return Redirect("/AdminDashboard");
                }
            }
            ModelState.AddModelError("", "Неудачная попытка входа");
            return View();
        }
    }
}
