using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }

    }
}
