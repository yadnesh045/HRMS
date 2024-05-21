using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HRMS.Controllers
{
    public class RahulController : Controller
    {
        public IActionResult Addposition()
        {
            return View();
        }

        public IActionResult Addposition(Position obj)
        {
            return View();
        }
    }
    }