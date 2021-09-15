using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.Models;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories
{
    //Standart Base repository for EF. CRUD, get all and get by Id
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task CreateAsync(TEntity model)
        {
            _dbSet.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity model)
        {
            _dbSet.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task SaveChagesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity model)
        {
            _dbSet.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}

