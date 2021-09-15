using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.Models;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<decimal> GetTotalSalaryAsync()
        {
            var result = await _dbSet.SumAsync(x => x.Salary);

            return result;
        }
    }
}
