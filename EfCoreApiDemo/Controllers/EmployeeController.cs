using EfCoreApiDemo.Models;
using EfCoreApiDemo.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _dbContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody]Employee employee)
        {
            var emp = _dbContext.Employees.FirstOrDefault(d => d.Id == employee.Id);
            if (emp == null)
                return NotFound();

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.DepartmentId = employee.DepartmentId;
            emp.UpdatedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return Ok(emp);
        }
    }
}
