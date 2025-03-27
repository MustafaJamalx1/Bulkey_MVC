using BukeyWegRazor_temp.Data;
using BukeyWegRazor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BukeyWegRazor_temp.Pages.Catagories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Catagory catagory { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost ()
        {
            if (catagory == null)
            {
                return NotFound();
            }
            _db.Catagories.Add(catagory);
            _db.SaveChanges();
            TempData["success"] = "Catagory created successfully";
            return RedirectToPage("Index");

        }
    }
}
