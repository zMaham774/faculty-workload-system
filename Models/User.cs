using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int? EmpId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public string FacultyName { get; set; }

        public User() { }

        public User(
            int userId,
            int? empId,
            string username,
            string role,
            bool isActive,
            string facultyName)
        {
            UserId = userId;
            EmpId = empId;
            Username = username;
            Role = role;
            IsActive = isActive;
            FacultyName = facultyName;
        }
    }
}
