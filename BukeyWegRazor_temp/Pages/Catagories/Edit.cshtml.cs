using BukeyWegRazor_temp.Data;
using BukeyWegRazor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BukeyWegRazor_temp.Pages.Catagories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Catagory catagory { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                 catagory=_db.Catagories.Find(id);  
            }
            
        }
        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(catagory);
                _db.SaveChanges();
                TempData["success"] = "Catagory Updated successfully";

                return RedirectToPage("Index");
            }
          
            return Page();
        }
    }
}
