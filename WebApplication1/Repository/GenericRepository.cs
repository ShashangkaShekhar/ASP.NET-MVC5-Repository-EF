using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Customer_Entities context = null;
        private DbSet<T> entities = null;

        public GenericRepository(Customer_Entities context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities.ToList();
        }
        public T GetById(object id)
        {
            return this.entities.Find(id);
        }
        public void Insert(T model)
        {
            context.Entry(model).State = EntityState.Added;
        }
        public void Update(T model)
        {
            context.Entry(model).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = this.entities.Find(id);
            this.entities.Remove(existing);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}