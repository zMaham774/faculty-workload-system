using System.Data;
using FacultyWorkloadSystem.Helpers;

namespace FacultyWorkloadSystem.DAL
{
    public static class TimeSlotDAL
    {
        // Get all for ComboBox 
        public static DataTable GetAllForCombo()
        {
            string sql = @"
                SELECT slot_id,
                       slot_label
                FROM   time_slots
                ORDER  BY start_time ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }
    }
}