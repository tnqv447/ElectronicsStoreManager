using System;
using System.Collections.Generic;
using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class Repository<T> : IRepository<T> where T : class {
        private readonly ElectronicsStoreContext _context;

        public Repository (ElectronicsStoreContext context) {
            _context = context;
        }

        public IList<T> GetAll () {
            return _context.Set<T> ().ToList ();
        }

        public T GetBy (int id) {
            return _context.Set<T> ().Find (id);
        }

        public virtual T Add (T entity) {
            T toCreate = _context.Set<T>().CreateProxy();
            _context.Entry(toCreate).CurrentValues.SetValues(entity);
            var tracked = _context.Set<T> ().Add (entity);
            _context.SaveChanges ();

            return tracked.Entity;
        }

        public virtual void Update (T entity) {
            _context.Set<T> ().Update (entity);
            _context.SaveChanges ();
        }

        public virtual void Delete (T entity) {
            _context.Set<T> ().Remove (entity);
            _context.SaveChanges ();
        }

        public virtual void AddRange (IList<T> entities) {
            _context.Set<T> ().AddRange (entities);
            _context.SaveChanges ();
        }
        public virtual void UpdateRange (IList<T> entities){
            _context.Set<T> ().UpdateRange (entities);
            _context.SaveChanges ();
        }
        public virtual void DeleteRange (IList<T> entities){
            _context.Set<T> ().RemoveRange (entities);
            _context.SaveChanges ();
        }

        public bool Exists (int id) {
            return this.GetBy (id) != null;
        }

    }
}