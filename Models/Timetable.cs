using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class Timetable
    {
        public int TtId { get; set; }
        public int WaId { get; set; }
        public string FacultyName { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string SemName { get; set; }
        public int SemId { get; set; }
        public int EmpId { get; set; }
        public string DeptName { get; set; }
        public string DayOfWeek { get; set; }
        public int SlotId { get; set; }
        public string SlotLabel { get; set; }
        public string Room { get; set; }
        public bool ConflictFlag { get; set; }

        public Timetable() { }

        public Timetable(
            int ttId,
            int waId,
            string facultyName,
            string courseTitle,
            string courseCode,
            string semName,
            int semId,
            int empId,
            string deptName,
            string dayOfWeek,
            int slotId,
            string slotLabel,
            string room,
            bool conflictFlag)
        {
            TtId = ttId;
            WaId = waId;
            FacultyName = facultyName;
            CourseTitle = courseTitle;
            CourseCode = courseCode;
            SemName = semName;
            SemId = semId;
            EmpId = empId;
            DeptName = deptName;
            DayOfWeek = dayOfWeek;
            SlotId = slotId;
            SlotLabel = slotLabel;
            Room = room;
            ConflictFlag = conflictFlag;
        }
    }
}
