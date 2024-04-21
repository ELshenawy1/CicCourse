using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        CompContext context;
        public EmployeeController()
        {
            context = new CompContext();
        }
        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> emps =  context.Employees.ToList();
            return Ok(emps);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Employee emps =  context.Employees.FirstOrDefault(e => e.Id == id);
            return Ok(emps);
        }

        [HttpPut]
        public IActionResult Update(Employee newEmp) // newemp = id =  3  , name 'maker' 
        {
            Employee oldEmp = context.Employees.FirstOrDefault(e => e.Id == newEmp.Id);
            if(oldEmp is not null)
            {
                 oldEmp.Name = newEmp.Name;
                 context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Employee e = context.Employees.FirstOrDefault(e => e.Id == id);
            if(e is not null)
            {
                context.Employees.Remove(e);
                context.SaveChanges();
            }
            return Ok();
        }
        
    }
}
