using Microsoft.AspNetCore.Mvc;
using RolesManagementService.Models;
using RolesManagementService.Services;

namespace RolesManagementService.Controllers;

public class UseManagementController : Controller
{
    private readonly IUserManagementService _userService;

    public UseManagementController(IUserManagementService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult UsersList()
    {
        var users = _userService.GetAllUsers();
        return View(users);  
    }

    [HttpPost]
    public IActionResult DeleteUser(int userId)
    {
        if (_userService.DeleteUser(userId))
        {
            return RedirectToAction("Index");  
        }
        return BadRequest("Ошибка при удалении пользователя.");
    }

    [HttpPost]
    public IActionResult ChangeUserRole(ChangeUserRoleModel model)
    {
        if (_userService.ChangeUserRole(model.UserId, model.NewRole))
        {
            return RedirectToAction("Index");
        }
        return BadRequest("Ошибка при изменении роли.");
    }

    [HttpPost]
    public IActionResult ConfirmUserRegistration(int userId)
    {
        if (_userService.ConfirmUserRegistration(userId))
        {
            return RedirectToAction("Index");
        }
        return BadRequest("Ошибка при подтверждении регистрации.");
    }
}
