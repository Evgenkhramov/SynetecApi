namespace SynetecAssessmentApi.DataAccess.Models
{
    public class Employee : BaseModel
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
