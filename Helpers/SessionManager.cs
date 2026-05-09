using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Helpers
{
    public static class SessionManager
    {
        public static int UserId 
        { 
            get; 
            set; 
        }
        public static string Username 
        { 
            get; 
            set; 
        }
        public static string Role 
        { 
            get; 
            set; 
        }
        public static int? EmpId 
        { 
            get; 
            set; 
        }
        public static bool IsAdmin => Role == "Admin";
        public static bool IsHOD => Role == "HOD";
        public static bool IsFaculty => Role == "Faculty";

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            EmpId = null;
        }
    }
}
