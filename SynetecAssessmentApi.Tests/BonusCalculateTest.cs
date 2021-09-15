using AutoMapper;
using Moq;
using SynetecAssessmentApi.BuisnessLogic.Services;
using SynetecAssessmentApi.BuisnessLogic.ViewModels;
using SynetecAssessmentApi.DataAccess.Models;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace SynetecAssessmentApi.Tests
{
    public class Tests
    {
        [Fact]
        public async Task BonusCalculationTest()
        {
            //Create request
            var requestModel = new BonusRequestViewModel();
            requestModel.TotalBonusAmount = 5000;
            requestModel.CurrentEmployeeId = 1;

            var employee = new Employee() { Id = 1, Fullname = "John Smith", JobTitle = "Accountant (Senior)", Salary = 1000, DepartmentId = 1 };
            
            decimal totalSalary = 10000;

            //Mock repository and Automapper

            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = Mock.Of<IMapper>();

            employeeRepository.Setup(x => x.GetByIdAsync(requestModel.CurrentEmployeeId)).Returns(Task.FromResult(employee));
            employeeRepository.Setup(x => x.GetTotalSalaryAsync()).Returns(Task.FromResult(totalSalary));

            var bonusePoolService = new BonusPoolService(employeeRepository.Object, mapper);
            var result = await bonusePoolService.GetBonusByEmployeeAsync(requestModel);

            //Set actual result
            var actualResult = new BonusResponseViewModel();
            actualResult.Amount = 500;
            actualResult.Employee = new EmployeeViewModel()
            {
                Fullname = "John2 Smith",
                JobTitle = "Accountant (Senior)",
                Salary = 6000
            };

            //Compare result
            Assert.Equal(result.Amount, actualResult.Amount);
        }
    }
}