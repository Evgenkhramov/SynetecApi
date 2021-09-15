using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SynetecAssessmentApi.DataAccess.Common
{
    public static class DBDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Employees.Any())
            {
                return;
            }

            SeedData(context);
        }

        public static void SeedData(AppDbContext context)
        {
            var departments = new List<Department>
            {
                new Department() { Id = 1, Description = "Finance", Title = "The finance department for the company" },
                new Department() { Id = 2, Description = "Human Resources", Title = "The Human Resources department for the company" },
                new Department() { Id = 3, Description = "IT", Title = "The IT support department for the company" },
                new Department() { Id = 4, Description = "Marketing", Title = "The Marketing department for the company" }
            };

            var employees = new List<Employee>
            {
                new Employee() { Id = 1, Fullname = "John Smith", JobTitle = "Accountant (Senior)", Salary = 60000, DepartmentId = 1 },
                new Employee() { Id = 2, Fullname = "Janet Jones", JobTitle = "HR Director", Salary = 90000, DepartmentId = 2 },
                new Employee() { Id = 3, Fullname = "Robert Rinser", JobTitle = "IT Director", Salary = 95000, DepartmentId = 3 },
                new Employee() { Id = 4, Fullname = "Jilly Thornton", JobTitle = "Marketing Manager (Senior)", Salary = 55000, DepartmentId = 4 },
                new Employee() { Id = 5, Fullname = "Gemma Jones", JobTitle = "Marketing Manager (Junior)", Salary = 45000, DepartmentId = 4 },
                new Employee() { Id = 6, Fullname = "Peter Bateman", JobTitle = "IT Support Engineer", Salary = 35000, DepartmentId = 3 },
                new Employee() { Id = 7, Fullname = "Azimir Smirkov", JobTitle = "Creative Director", Salary = 62500, DepartmentId = 4 },
                new Employee() { Id = 8, Fullname = "Penelope Scunthorpe", JobTitle = "Creative Assistant", Salary = 38750, DepartmentId = 4 },
                new Employee() { Id = 9, Fullname = "Amil Kahn", JobTitle = "IT Support Engineer", Salary = 36000, DepartmentId = 3 },
                new Employee() { Id = 10, Fullname = "Joe Masters", JobTitle = "IT Support Engineer", Salary = 36500, DepartmentId = 3 },
                new Employee() { Id = 11, Fullname = "Paul Azgul", JobTitle = "HR Manager", Salary = 53000, DepartmentId = 2 },
                new Employee() { Id = 12, Fullname = "Jennifer Smith", JobTitle = "Accountant (Junior)", Salary = 48000, DepartmentId = 1 },
            };

            context.AddRange(departments);
            context.AddRange(employees);

            context.SaveChanges();
        }
    }
}
