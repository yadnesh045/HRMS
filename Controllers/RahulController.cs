using HRMS.Data;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HRMS.Controllers
{

    public class RahulController : Controller
    {
        readonly ApplicationDbContext _context;
        public RahulController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Addposition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addposition(Position obj)
        {
            if (ModelState.IsValid)
            {

                _context.Positions.Add(obj);
                _context.SaveChanges();
                return View();
            }
            return View(obj);

        }

        [HttpGet]
        public IActionResult ViewPosition()
        {
            var view=_context.Positions.ToList();
            return View(view);
        }


    }
    }