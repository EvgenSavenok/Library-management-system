using Microsoft.AspNetCore.Mvc;

namespace BorrowingManagementService.Controllers;

public class BorrowingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
