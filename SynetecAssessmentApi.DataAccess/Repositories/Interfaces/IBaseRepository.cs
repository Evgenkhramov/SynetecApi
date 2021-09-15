using SynetecAssessmentApi.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories.Interfaces
{
    public interface  IBaseRepository<TEntity> where TEntity : BaseModel
    {
        public Task CreateAsync(TEntity model);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(long id);
        public Task UpdateAsync(TEntity model);
        public Task DeleteAsync(TEntity model);
        public Task SaveChagesAsync();
    }
}
