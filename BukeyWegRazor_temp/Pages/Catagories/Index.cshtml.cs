using BukeyWegRazor_temp.Data;
using BukeyWegRazor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace BukeyWegRazor_temp.Pages.Catagories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Catagory> CatagoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CatagoryList = _db.Catagories.ToList();
        }
    }
}
