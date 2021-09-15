using AutoMapper;
using SynetecAssessmentApi.BuisnessLogic.Exceptions;
using SynetecAssessmentApi.BuisnessLogic.Services.Interfaces;
using SynetecAssessmentApi.BuisnessLogic.ViewModels;
using SynetecAssessmentApi.DataAccess.Models;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BuisnessLogic.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private const string EMPLOYEE_NOT_FOUND = "Employee not found!";

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public BonusPoolService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeViewModel>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAllAsync();
            List<EmployeeViewModel> mappedResult = _mapper.Map<List<EmployeeViewModel>>(employees);

            return mappedResult;
        }

        public async Task<BonusResponseViewModel> GetBonusByEmployeeAsync(BonusRequestViewModel model)
        {
            var employee = await _employeeRepository.GetByIdAsync(model.CurrentEmployeeId);
            if (employee is null)
            {
                throw new ApplicationWarningException(EMPLOYEE_NOT_FOUND);
            }

            //Use Automapper
            var mappedEmployee = _mapper.Map<EmployeeViewModel>(employee);

            decimal totalSalary = await _employeeRepository.GetTotalSalaryAsync();
            decimal percentOfTotalSalary = (decimal)employee.Salary / (decimal)totalSalary;
            decimal individualBonus = Math.Round(model.TotalBonusAmount * percentOfTotalSalary, 2);

            var result = new BonusResponseViewModel();
            result.Employee = mappedEmployee;
            result.Amount = individualBonus;

            return result;
        }
    }
}
