using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.IManager
{
    public interface IEmpManager
    {
        public Employee AddEmployee(Employee obj);
        public bool DeleteEmployee(int empId);
        public List<Employee> GetAllEmployee();
        public bool UpdateEmployee(Employee obj);
    }
}
