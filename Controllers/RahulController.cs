﻿using HRMS.Data;
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
                return RedirectToAction("ViewPosition", "Rahul");
            }
            return View(obj);

        }

        [HttpGet]
        public IActionResult ViewPosition()
        {
            var view=_context.Positions.ToList();
            return View(view);
        }


        [HttpGet]
        public IActionResult ViewAssets()
        {
            var view = _context.Assets.ToList();    
            return View(view);
        }




    }
    }