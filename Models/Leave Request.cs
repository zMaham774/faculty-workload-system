using System;

namespace FacultyWorkloadSystem.Models
{
    public class LeaveRequest
    {
        public int RequestId { get; set; }
        public int EmpId { get; set; }
        public string FacultyName { get; set; }
        public string DeptName { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime AppliedOn { get; set; }
        public int? ApprovedBy { get; set; }
        public string ApprovalRemarks { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }
}