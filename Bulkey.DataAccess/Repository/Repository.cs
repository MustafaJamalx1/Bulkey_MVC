using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulkey.DataAccess.Data;
using Bulkey.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulkey.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        private ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
            _db.Products.Include(u => u.Catagory);

        }


        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string property in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query= dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(string property in includeProperties
                    .Split( new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                   query=query.Include(property);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
