using EfCoreApiDemo.Models;
using EfCoreApiDemo.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;
        public DepartmentController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var departments = _dbContext.Departments.ToList();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            var dept = _dbContext.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (dept == null)
                return NotFound();

            dept.Name = department.Name;
            dept.Description = department.Description;
            dept.UpdatedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return Ok(dept);
        }
    }
}
