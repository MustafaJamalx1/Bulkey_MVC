using Bulkey.Models;
using BulkeyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkeyWeb.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CatagoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Catagory> catagoryList = _db.Catagories.ToList();
            return View(catagoryList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catagory obj)
        {
            //if (obj.Name!= null && obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "the Catagory Name and the display order cannot be exactly the same");
            //}

            if (ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory created successfully";
                return RedirectToAction("Index", "Catagory");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Catagory catagoryFromDb = _db.Catagories.Find(id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Catagory obj) { 
          
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory Updated successfully";

                return RedirectToAction("Index");
            }
        return View();
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Catagory catagoryFromDb = _db.Catagories.Find(id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Catagory deleteCatagory=_db.Catagories.Find(id);
            if (deleteCatagory != null)
            {
                _db.Catagories.Remove(deleteCatagory);
                _db.SaveChanges();
                TempData["success"] = "Catagory deleted successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
