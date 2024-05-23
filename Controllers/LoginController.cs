using HRMS.Data;
using HRMS.Models;
using HRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            string EnteredEmail = email;
            string EnteredPassword = password;


            var RoleVerification = _context.UserRoles.FirstOrDefault(x => x.Email == email);
            if (RoleVerification != null)
            {
                switch (RoleVerification.RoleType)
                {
                    case "Super Admin":
                        var admin = _context.Users.FirstOrDefault(p => p.Email == RoleVerification.Email);
                        if (admin != null)
                        {
                            if (EnteredPassword == admin.Password)
                            {

                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Error = "INVALID CREDENTIALS";
                            }
                        }
                        break;


                    case "Supervisor":
                        var superAdmin = _context.Users.FirstOrDefault(p => p.Email == RoleVerification.Email);
                        if (superAdmin != null)
                        {
                            // bool doesPasswordMatch = Crypto.VerifyHashedPassword(superAdmin.Password, data.Password);
                            //   if (doesPasswordMatch)
                            //{


                            //    return RedirectToAction("OrganizationDashboard", "Dashboard");
                            //}
                            //else

                            //{
                            //    ViewBag.Error = "INVALID CREDENTIALS";
                            //}
                        }
                        break;


                    case "Assistant":
                        var assistant = _context.Users.FirstOrDefault(p => p.Email == RoleVerification.Email);
                        if (assistant != null)
                        {
                            //bool doesPasswordMatch = Crypto.VerifyHashedPassword(user.Password, data.Password);
                            //if (doesPasswordMatch)
                            //{


                            //    return RedirectToAction("UserDashboard", "Dashboard");
                            //}
                            //else
                            //{
                            //    ViewBag.Error = "INVALID CREDENTIALS";
                            //}
                        }
                        break;


                    case "User":
                        var user = _context.Users.FirstOrDefault(p => p.Email == RoleVerification.Email);
                        if (user != null)
                        {
                            //bool doesPasswordMatch = Crypto.VerifyHashedPassword(user.Password, data.Password);
                            //if (doesPasswordMatch)
                            //{


                            //    return RedirectToAction("UserDashboard", "Dashboard");
                            //}
                            //else
                            //{
                            //    ViewBag.Error = "INVALID CREDENTIALS";
                            //}
                        }
                        break;

                    default:
                        return View();
                }
            }
            else
            {
                ViewBag.Error = "INVALID CREDENTIALS";
            }
            return View();

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            string EnteredFullName = registerVM.FullName;
            string EnteredEmail = registerVM.Email;
            string EnteredPassword = registerVM.Password;
            string EnteredConfirmPassword = registerVM.ConfirmPassword;


            var user = new User
            {
                FullName = EnteredFullName,
                Email = EnteredEmail,
                Password = EnteredPassword,
                ConfirmPasswords = EnteredConfirmPassword
            };

            var role = new UserRole
            {
                Email = EnteredEmail,
                RoleType = ""
            };

            _context.Users.Add(user);
            _context.UserRoles.Add(role);
            _context.SaveChanges();


            return RedirectToAction("Login");
        }


    }
}
