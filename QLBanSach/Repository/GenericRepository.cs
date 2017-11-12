﻿using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLBanSach.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected QLBS _db { get; set; }
        protected DbSet<T> _table = null;

        public GenericRepository()
        {
            _db = new QLBS();
            _table = _db.Set<T>();
        }

        public GenericRepository(QLBS db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            //return _table.AsNoTracking().ToList();
            return _table.ToList();
        }
        
        public T SelectById(object id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}