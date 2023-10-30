using EmployeeModels;
using EmployeeRepository.IEmpRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository.EmpRepository
{
    public class EmpRepo : IEmpRepo
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionStr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = EmployeeManagement; integrated security = true";
            con = new SqlConnection(connectionStr);
        }
        public Employee AddEmployee(Employee obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@City", obj.City);
                com.Parameters.AddWithValue("@Address", obj.Address);
                con.Open();
                com.ExecuteNonQuery();
                return obj;
                //var i = com.ExecuteScalar();
                //if (i != null)
                //{
                //    Console.WriteLine("Employee added");
                //    obj.EmpId = Convert.ToInt32(i);
                //    Console.WriteLine(obj.EmpId);
                //    return obj;
                //}
                //else
                //{
                //    return null;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteEmployee(int empId)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", empId);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public List<Employee> GetAllEmployee()
        {
            Connection();
            List<Employee> EmpList = new List<Employee>();
            SqlCommand com = new SqlCommand("GetAllEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Employee()
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    }
                    );
            }
            foreach (var data in EmpList)
            {
                Console.WriteLine(data.EmpId + "" + data.Name);
            }
            return EmpList;
        }
        public bool UpdateEmployee(Employee obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("UpdateEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.EmpId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
