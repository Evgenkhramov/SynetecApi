using SynetecAssessmentApi.BuisnessLogic.ViewModels;

namespace SynetecAssessmentApi.BuisnessLogic.ViewModels
{
    public class EmployeeViewModel
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
