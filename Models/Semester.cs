using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FacultyWorkloadSystem.Models
{
    public class Semester
    {
        public int SemId { get; set; }
        public string SemName { get; set; }
        public string AcadYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
