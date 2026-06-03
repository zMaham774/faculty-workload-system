using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    
        public class Attendance
        {
            public int AttendanceId { get; set; }
            public int EmpId { get; set; }
            public string FacultyName { get; set; }
            public string DeptName { get; set; }
            public DateTime AttDate { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public int MarkedBy { get; set; }
            public DateTime MarkedOn { get; set; }
        }
    }
