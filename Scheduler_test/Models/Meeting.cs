using System;

namespace Scheduler_test.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int EmployeeId { get; set; }
    }
}
