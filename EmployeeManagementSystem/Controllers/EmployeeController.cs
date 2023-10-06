using EmployeeManager.IManager;
using EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmpManager empManager;
        public EmployeeController(IEmpManager empManager)
        {
            this.empManager = empManager;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            try
            {
                var result = this.empManager.GetAllEmployee();
                return this.Ok(result.AsEnumerable());//200
            } catch (Exception ex)
            {
                return this.BadRequest(ex.Message);//400, 500                }
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                var result = this.empManager.AddEmployee(employee);
                return this.Ok(result);//201
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);//400, 500                }
            }
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int empId)
        {
            try
            {
                var result = this.empManager.DeleteEmployee(empId);
                return this.Ok(result);//200
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);//400, 500                }
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var result = this.empManager.UpdateEmployee(employee);
                return this.Ok(result);//200
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);//400, 500                }
            }
        }
    }
}
