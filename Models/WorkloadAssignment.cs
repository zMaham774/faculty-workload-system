using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class WorkloadAssignment
    {
        public int WaId { get; set; }
        public int EmpId { get; set; }
        public string FacultyName { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public int CreditHours { get; set; }
        public string DeptName { get; set; }
        public int SemId { get; set; }
        public string SemName { get; set; }
        public decimal TotalHours { get; set; }
        public string Status { get; set; }
        public DateTime AssignedDate { get; set; }

        public WorkloadAssignment() { }

        public WorkloadAssignment(
            int waId,
            int empId,
            string facultyName,
            int courseId,
            string courseTitle,
            string courseCode,
            int creditHours,
            string deptName,
            int semId,
            string semName,
            decimal totalHours,
            string status,
            DateTime assignedDate)
        {
            WaId = waId;
            EmpId = empId;
            FacultyName = facultyName;
            CourseId = courseId;
            CourseTitle = courseTitle;
            CourseCode = courseCode;
            CreditHours = creditHours;
            DeptName = deptName;
            SemId = semId;
            SemName = semName;
            TotalHours = totalHours;
            Status = status;
            AssignedDate = assignedDate;
        }
    }
}
