using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class Faculty
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string EmpType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Qualification { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }

        public Faculty() { }

        public Faculty(
            int empId, string name,
            int deptId, string deptName,
            int designationId, string designationName,
            string empType, string email,
            string phone, string qualification,
            bool isActive, string status)
        {
            EmpId = empId;
            Name = name;
            DeptId = deptId;
            DeptName = deptName;
            DesignationId = designationId;
            DesignationName = designationName;
            EmpType = empType;
            Email = email;
            Phone = phone;
            Qualification = qualification;
            IsActive = isActive;
            Status = status;
        }
    }
}

