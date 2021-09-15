using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.BuisnessLogic.MapperProfiles;
using SynetecAssessmentApi.BuisnessLogic.Services;
using SynetecAssessmentApi.BuisnessLogic.Services.Interfaces;
using SynetecAssessmentApi.DataAccess.Repositories;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;

namespace SynetecAssessmentApi.BuisnessLogic.DI
{
    public static class DependencyInjection
    {
        public static void SetDependencies(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IBonusPoolService, BonusPoolService>();
        }
    }
}
