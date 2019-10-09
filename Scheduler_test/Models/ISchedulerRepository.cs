using System.Collections.Generic;

namespace Scheduler_test.Models
{
    public interface ISchedulerRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Meeting> GetEmployeeMeetings(int employeeId);
    }
}
