using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scheduler_test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler_test.Controllers
{
    [Route("api/[controller]")]
    public class SchedulerController : Controller
    {
        public ISchedulerRepository Scheduler { get; set; }

        public SchedulerController(ISchedulerRepository scheduler)
        {
            Scheduler = scheduler;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return Scheduler.GetAllEmployees();
        }

        [HttpGet("{id}", Name = "Employee")]
        public IActionResult GetEmployeeMeetings(int id)
        {
            var meetings = Scheduler.GetEmployeeMeetings(id);
            if (meetings == null)
            {
                return NotFound();
            }
            return new ObjectResult(meetings);
        }
    }
}
