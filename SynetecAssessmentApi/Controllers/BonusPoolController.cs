using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.BuisnessLogic.Services.Interfaces;
using SynetecAssessmentApi.BuisnessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    /// <summary>
    /// API BonusPoolController summary.
    /// </summary>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Internal Server Error.</response>
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;
        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployees")]
        [ProducesResponseType(typeof(List<EmployeeViewModel>), 200)]
        public async Task<IActionResult> GetAll()
        {
            List<EmployeeViewModel> employees = await _bonusPoolService.GetEmployeesAsync();

            return Ok(employees);
        }

        /// <summary>
        /// Calculate bonus per customerId and total bonusPool Amount.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetEmployeeBonus")]
        [ProducesResponseType(typeof(BonusResponseViewModel), 200)]
        public async Task<IActionResult> CalculateBonus([FromBody] BonusRequestViewModel request)
        {
            BonusResponseViewModel result = await _bonusPoolService.GetBonusByEmployeeAsync(request);

            return Ok(result);
        }
    }
}
