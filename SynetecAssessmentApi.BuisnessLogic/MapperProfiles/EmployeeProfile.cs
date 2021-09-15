using AutoMapper;
using SynetecAssessmentApi.BuisnessLogic.ViewModels;
using SynetecAssessmentApi.DataAccess.Models;

namespace SynetecAssessmentApi.BuisnessLogic.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        //Automapper config
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
