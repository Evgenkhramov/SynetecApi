using System.Collections.Generic;

namespace SynetecAssessmentApi.DataAccess.Models
{
    public class Department : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
