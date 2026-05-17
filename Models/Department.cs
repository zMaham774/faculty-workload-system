using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string HodName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        // Constructor - empty (for creating new dept)
        public Department() { }

        // Constructor - full (for loading from DB)
        public Department(int deptId, string deptName,
                          string hodName, string contact,
                          string email, bool isActive)
        {
            DeptId = deptId;
            DeptName = deptName;
            HodName = hodName;
            Contact = contact;
            Email = email;
            IsActive = isActive;
        }
    }
}
