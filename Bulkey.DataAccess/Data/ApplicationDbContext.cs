using Bulkey.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkeyWeb.DataAccess.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
        
    }
    public DbSet<Catagory> Catagories { get; set; }
}
