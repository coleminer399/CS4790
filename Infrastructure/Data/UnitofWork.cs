using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitofWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IGenericRepository<Category> _Category;
        public IGenericRepository<Category> Category
        {
            get
            {
                if (_Category == null) _Category = new GenericRepository<Category>(_dbContext);
                    return _Category;
                
            }
        }

        public int commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> commitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
