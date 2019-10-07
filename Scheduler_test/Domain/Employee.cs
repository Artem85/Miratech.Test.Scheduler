using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler_test.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Meeting> Meetings { get; set; }
    }
}
