using BukeyWegRazor_temp.Data;
using BukeyWegRazor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BukeyWegRazor_temp.Pages.Catagories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Catagory catagory { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                catagory = _db.Catagories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Catagory deleteCatagory = _db.Catagories.Find(catagory.CatagoreyId);
            if (deleteCatagory != null)
            {
                _db.Catagories.Remove(deleteCatagory);
                _db.SaveChanges();
                TempData["success"] = "Catagory Deleted successfully";

                return RedirectToPage("Index");
            }
            return RedirectToPage("index");

        }
    }
}
