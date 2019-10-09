using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Scheduler_test.Models
{
    public class SchedulerRepository : ISchedulerRepository
    {
        private List<Employee> employees;
        private List<Meeting> meetings;

        public SchedulerRepository ()
        {
            employees = new List<Employee>();
            meetings = new List<Meeting>();

            //TODO: Unify csv parser for any file. Remove duplicated code.

            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Scheduler_test.EmbeededData.Employees.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    bool skipLine = true;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (skipLine)
                        {
                            skipLine = false;
                        }
                        else
                        {
                            string[] values = line.Split(',');

                            //TODO: Add error handling.

                            Employee employee = new Employee();
                            employee.Id = Convert.ToInt32(values[0]);
                            employee.Name = values[1];

                            employees.Add(employee);
                        }
                    }
                }
            }

            resourceName = "Scheduler_test.EmbeededData.Meetings.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    bool skipLine = true;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (skipLine)
                        {
                            skipLine = false;
                        }
                        else
                        {
                            string[] values = line.Split(',');

                            Meeting meeting = new Meeting();
                            meeting.Id = Convert.ToInt32(values[0]);
                            meeting.EmployeeId = Convert.ToInt32(values[1]);
                            meeting.ScheduledTime = DateTime.Parse(values[2]);

                            meetings.Add(meeting);
                        }
                    }
                }
            }
        }
        
        public IEnumerable<Employee> GetAllEmployees()
        {
            
            return employees;
        }

        public IEnumerable<Meeting> GetEmployeeMeetings(int employeeId)
        {
            return meetings.Where(meeting => meeting.EmployeeId == employeeId);
        }
    }
}
