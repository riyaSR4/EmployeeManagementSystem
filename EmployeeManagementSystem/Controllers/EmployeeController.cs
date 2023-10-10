using EmployeeManager.IManager;
using EmployeeModels;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmpManager empManager;
        public EmployeeController(IEmpManager empManager)
        {
            this.empManager = empManager;
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            try
            {
                var result = this.empManager.AddEmployee(emp);
                if (result != null)
                {
                    ViewBag.Message = "Employee Details Added Successfully";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}