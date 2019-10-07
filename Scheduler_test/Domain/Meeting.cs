using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler_test.Domain
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
