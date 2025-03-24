using BulkeyWeb.Data;
using BulkeyWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (ModelState.IsValid)
            {
            _db.Catagories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index","Catagory");
            }
            return View();
        }
    }
}
