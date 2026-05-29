using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWorkloadSystem.Models
{
    public class AcademicCalendar
    {
        public int CalId { get; set; }
        public int SemId { get; set; }
        public string SemName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public bool IsTeaching { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }

        public AcademicCalendar() { }

        public AcademicCalendar(
            int calId,
            int semId,
            string semName,
            DateTime eventDate,
            string eventType,
            string eventName,
            bool isTeaching,
            string description,
            int? createdBy)
        {
            CalId = calId;
            SemId = semId;
            SemName = semName;
            EventDate = eventDate;
            EventType = eventType;
            EventName = eventName;
            IsTeaching = isTeaching;
            Description = description;
            CreatedBy = createdBy;
        }
    }
}
