using SynetecAssessmentApi.DataAccess.Models;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public Task<decimal> GetTotalSalaryAsync();
    }
}
