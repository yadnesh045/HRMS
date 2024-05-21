using HRMS.Data;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        } 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpGet]
        public IActionResult CreateRole()
        {
            var roles = _context.Roles.ToList();

            return View(roles);
        }


        [HttpPost]
        public IActionResult CreateRole(Roles role)
        {
            if (ModelState.IsValid)
            {
                var newRole = new Roles
                {
                    RoleName = role.RoleName,
                    Description = role.Description
                };

                _context.Roles.Add(newRole);
                _context.SaveChanges();
                return RedirectToAction("CreateRole");
            }
            return View();
        }


        [HttpGet]
        public IActionResult AssignRoles()
        {
            var users = _context.Users.ToList();

            return View(users);
       
        }

        [HttpGet]
        public IActionResult AssignUserRoles(int id)
        {
            var roles = _context.Roles.ToList();
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            ViewBag.Roles = roles;

            return View(user);
        }


        [HttpPost]
        public IActionResult AssignUserRoles(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                var existingUserRole = _context.UserRoles.FirstOrDefault(x => x.Email == userRole.Email);

                if (existingUserRole != null)
                {
                    existingUserRole.RoleType = userRole.RoleType;
                    _context.UserRoles.Update(existingUserRole);
                }
                else
                {
                    _context.UserRoles.Add(userRole);
                }

                _context.SaveChanges();
                return RedirectToAction("AssignRoles");
            }
            return View(userRole);
        }






















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
