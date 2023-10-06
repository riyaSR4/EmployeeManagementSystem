using EmployeeManager.IManager;
using EmployeeModels;
using EmployeeRepository.IEmpRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Manager
{
    public class EmpManager : IEmpManager
    {
        public readonly IEmpRepo empRepo;
        public EmpManager(IEmpRepo empRepo)
        {
            this.empRepo = empRepo;
        }
        public Employee AddEmployee(Employee obj)
        {
            try
            {
                var result = this.empRepo.AddEmployee(obj);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool DeleteEmployee(int empId)
        {
            try
            {
                var result = this.empRepo.DeleteEmployee(empId);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Employee> GetAllEmployee()
        {
            try
            {
                var result = this.empRepo.GetAllEmployee();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool UpdateEmployee(Employee obj)
        {
            try
            {
                var result = this.empRepo.UpdateEmployee(obj);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
