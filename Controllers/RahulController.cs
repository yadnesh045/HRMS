using HRMS.Data;
using HRMS.Models;
using HRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var view = _context.Positions.ToList();
            return View(view);
        }


        [HttpGet]
        public IActionResult ViewAssets()
        {
            var total = _context.Assets.Count();
            ViewBag.TotalAssets = total;
            var view = _context.Assets.ToList();
            return View(view);
        }


        [HttpPost]
        public IActionResult AddAssets(Assets obj)
        {
            if (ModelState.IsValid)
            {

                _context.Assets.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("ViewAssets", "Rahul");
            }
            return View();

        }

       
        public async Task<IActionResult> EditAssets(int id)
        {
            var asset = _context.Assets.FirstOrDefault(a => a.id == id);
            if (asset == null)
            {
                return NotFound();
            }
            return Json(asset);
        }

        [HttpPost]

        public IActionResult EditAssets(Assets model)
        {
            if (ModelState.IsValid)
            {
                // Update asset in the database
                var assetToUpdate = _context.Assets.FirstOrDefault(a => a.id == model.id);
                if (assetToUpdate != null)
                {
                    assetToUpdate.asset_name = model.asset_name; 
                    assetToUpdate.category = model.category;
                    assetToUpdate.description = model.description;
                    assetToUpdate.serial_number = model.serial_number;
                    assetToUpdate.quantitiy = model.quantitiy;



                    
                    _context.Assets.Update(assetToUpdate);
                    _context.SaveChanges();

                    return RedirectToAction("Index"); // Redirect to the assets list or any other appropriate action
                }
                else
                {
                    return NotFound(); // Asset not found
                }
            }
            else
            {
                // Model validation failed, return to the view
                return View(model);
            }
        }


        public IActionResult delete(int id)
        {
            var assetToDelete = _context.Assets.FirstOrDefault(a => a.id == id);

            if (assetToDelete == null)
            {
                return NotFound(); // Return 404 Not Found if asset with the specified id is not found
            }

            _context.Assets.Remove(assetToDelete);
            _context.SaveChanges();

            return RedirectToAction("ViewAssets","Rahul"); // Redirect to the action that displays assets list (e.g., Index)
        }

    
    }
}