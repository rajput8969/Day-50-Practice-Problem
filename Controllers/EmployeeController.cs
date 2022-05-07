using Microsoft.AspNetCore.Mvc;

namespace EmployeePayRoll.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        public EmployeeController(EmployeeManager manager)
        {
            Manager = manager;
        }

        public EmployeeManager Manager { get; }

        [Route("list"),HttpGet]
        public IActionResult get()
        {
            var list = this.Manager.GetEmployees();
            return Json(list);
        }
        [Route("{id}"), HttpGet]
        public IActionResult get(int id)
        {
            var list = this.Manager.GetEmployeeById(id);
            return Json(list);
        }
        [Route("{id}"), HttpDelete]
        public IActionResult Delete(int id)
        {
            this.Manager.DeleteEmployeeById(id);
            return Json("Deleted");
        }
        [Route("create"), HttpPost]
        public IActionResult AddEmployee([FromBody]Employee emp)
        {
            this.Manager.AddEmployee(emp);
            return Json("Success");
        }
    }
}
