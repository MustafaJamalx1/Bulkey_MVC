﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulkey.DataAccess.Repository.IRepository;
using Bulkey.DataAccess.Data;

namespace Bulkey.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICatagoryRepository Catagory {  get; private set; } 
        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {

            _db = db;
            Catagory = new CatagoryRepository(_db);
            Product = new ProductRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
