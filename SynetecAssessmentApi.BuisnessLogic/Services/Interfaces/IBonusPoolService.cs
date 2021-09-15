using SynetecAssessmentApi.BuisnessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BuisnessLogic.Services.Interfaces
{
    public interface IBonusPoolService
    {
        public Task<List<EmployeeViewModel>> GetEmployeesAsync();
        public Task<BonusResponseViewModel> GetBonusByEmployeeAsync(BonusRequestViewModel model);
    }
}
