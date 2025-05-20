using Bulkey.DataAccess.Repository;
using Bulkey.DataAccess.Repository.IRepository;
using Bulkey.Models;
using Bulkey.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bulkey.Models.ViewModels;
using NuGet.Common;

namespace BulkeyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll().ToList();
           
            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {

            ProductVM productVM = new()
            {
                CatagoryList = _unitOfWork.Catagory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CatagoryId.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0) {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName=Guid.NewGuid().ToString() +Path.GetExtension(file.FileName);
                    string productPath=Path.Combine(wwwRootPath, @"Images\Product");
                    
                    using( var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                    }
                    productVM.Product.ImageUrl = @"Images\Product"+fileName;
                    
                }
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Product ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            Product deleteProduct = _unitOfWork.Product.Get(u => u.Id == id);
            if (deleteProduct != null)
            {
                _unitOfWork.Product.Remove(deleteProduct);
                _unitOfWork.Save();
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
