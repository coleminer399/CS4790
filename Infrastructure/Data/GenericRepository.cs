using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        //By using ReadOnly ApplicationDbContext, you can have access to only
        //querying capabilitiies of DbContext. UnitOfWOrk actually writes
        //(commits) to the PHYSICAL tables (not internal object)


        public void Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbcontext.Set<T>().RemoveRange(entities);
            _dbcontext.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null)
        {
            if (includes == null)
            {
                if (asNoTracking)
                {
                    return _dbcontext.Set<T>()
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefault();
                }
                else
                {
                    return _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefault();
                }
            }
            else
            {
                IQueryable<T> queryable = _dbcontext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (asNoTracking)
                {
                    return _dbcontext.Set<T>()
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefault();
                }
                else
                {
                    return _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefault();
                }
            }
        }
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null)
        {
            if (includes == null)
            {
                if (asNoTracking)
                {
                    return await _dbcontext.Set<T>()
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
            }
            else
            {
                IQueryable<T> queryable = _dbcontext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (asNoTracking)
                {
                    return await _dbcontext.Set<T>()
                        .AsNoTracking()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
            }
        }

        //virtual keyword is used to modify a method, property, indexer, or
        //and allows for it to be overridden in a derived class.
        public virtual T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> List()
        {
            return _dbcontext.Set<T>().ToList().AsEnumerable();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, string includes = null)
        {
            IQueryable<T> queryable = _dbcontext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbcontext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            else if (includes != null){
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }
            if (predicate == null)
            {
                if(orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    return queryable.OrderBy(orderBy).ToList().AsEnumerable();

                }
                
            }
            else
            {
                if (orderBy == null) {
                    return queryable.Where(predicate).ToList().AsEnumerable();
                }
                else
                {
                    return queryable.Where(predicate).OrderBy(orderBy).ToList().AsEnumerable();
                }
            }
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, string includes = null)
        {
            IQueryable<T> queryable = _dbcontext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbcontext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }
            if (predicate == null)
            {
                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    return await queryable.OrderBy(orderBy).ToListAsync();

                }

            }
            else
            {
                if (orderBy == null)
                {
                    return await queryable.Where(predicate).ToListAsync();
                }
                else
                {
                    return await queryable.Where(predicate).OrderBy(orderBy).ToListAsync();
                }
            }
        }

        public void Update(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }
    }
}
