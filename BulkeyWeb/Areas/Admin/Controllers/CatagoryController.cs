using Bulkey.DataAccess.Repository;
using Bulkey.DataAccess.Repository.IRepository;
using Bulkey.Models;
using Bulkey.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Bulkey.Utilites;

namespace BulkeyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CatagoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatagoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Catagory> catagoryList = _unitOfWork.Catagory.GetAll().ToList();
            return View(catagoryList);
        }

        public IActionResult Create()
        {
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
                _unitOfWork.Catagory.Add(obj);
                _unitOfWork.Save();
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
            Catagory catagoryFromDb = _unitOfWork.Catagory.Get(u => u.CatagoryId== id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Catagory obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Catagory.Update(obj);
                _unitOfWork.Save();
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
            Catagory catagoryFromDb = _unitOfWork.Catagory.Get(u => u.CatagoryId == id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Catagory deleteCatagory = _unitOfWork.Catagory.Get(u => u.CatagoryId == id);
            if (deleteCatagory != null)
            {
                _unitOfWork.Catagory.Remove(deleteCatagory);
                _unitOfWork.Save();
                TempData["success"] = "Catagory deleted successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
