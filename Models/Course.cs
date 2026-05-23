namespace FacultyWorkloadSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int CreditHours { get; set; }
        public string CourseType { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public bool IsActive { get; set; }
    }
}