using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulkey.DataAccess.Repository.IRepository;
using Bulkey.Models;
using Bulkey.DataAccess.Data;

namespace Bulkey.DataAccess.Repository
{
    public class CatagoryRepository : Repository<Catagory>,ICatagoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CatagoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
            
        }

        public void Update(Catagory obj)
        {
            _db.Catagories.Update(obj);
        }
    }
}
