using Grpc.ProductManagement.Context;
using Grpc.ProductManagement.SharedCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Grpc.ProductManagement
{
    public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
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
            public void Add(List<T> entity)
            {
                _context.AddRange(entity);
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
                return items.Where(x => x.DeleteFlag != 1);
            }

            public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return items.Where(predicate).Where(x => x.DeleteFlag != 1);
            }

            public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
            {
                return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
            }

            public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
            {
                return FindAll(includeProperties).SingleOrDefault(predicate);
            }

            public virtual void RemoveFlg(T entity)
            {
                entity.DeleteFlag = 1;
                _context.Set<T>().Update(entity);
            }

            public void Remove(T entity)
            {
                _context.Set<T>().Remove(entity);
            }

            public void Remove(K id)
            {
                RemoveFlg(FindById(id));
            }



            public void RemoveMultiple(List<T> entities)
            {
                _context.Set<T>().RemoveRange(entities);
            }

            public void Update(T entity)
            {
                _context.Set<T>().Update(entity);
            }

            public void Update(List<T> entity)
            {
                _context.Set<T>().UpdateRange(entity);
            }
    }
    
}
