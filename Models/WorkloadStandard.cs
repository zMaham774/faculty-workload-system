using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class WorkloadStandard
    {
        public int WsId { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int SemId { get; set; }
        public string SemName { get; set; }
        public int MinHours { get; set; }
        public int MaxHours { get; set; }
        public int StdHours { get; set; }

        public WorkloadStandard() { }

        public WorkloadStandard(
            int wsId,
            int deptId,
            string deptName,
            int semId,
            string semName,
            int minHours,
            int maxHours,
            int stdHours)
        {
            WsId = wsId;
            DeptId = deptId;
            DeptName = deptName;
            SemId = semId;
            SemName = semName;
            MinHours = minHours;
            MaxHours = maxHours;
            StdHours = stdHours;
        }
    }
}
