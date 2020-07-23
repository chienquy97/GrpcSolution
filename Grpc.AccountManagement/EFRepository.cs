
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.SharedCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Grpc.AccountManagement
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;


        public EFRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }
        public void AddRange(List<T> entity)
        {
            _context.Add(entity);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return items.Where(predicate);
            }
            catch (Exception e)
            {
                int x = 0;
                return null;
            }
        }

        //public T FindById(int id, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        //}


        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public virtual void RemoveFlg(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }



        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
