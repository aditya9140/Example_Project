using Example_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Example_Project.Repository
{
    public class EmployeeRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["connectionDB"].ToString();
            con = new SqlConnection(constring);
        }

        public bool Employee(Employee employee)
        {
            connection();
            SqlCommand sqlCommand = new SqlCommand("sp_InsertUpdateDelete_Employee", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            sqlCommand.Parameters.AddWithValue("@Designation", employee.Designation);
            sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@Mobile", employee.Mobile);
            sqlCommand.Parameters.AddWithValue("@Qualification", employee.Qualification);
            sqlCommand.Parameters.AddWithValue("@Manager", employee.Manager);
            sqlCommand.Parameters.AddWithValue("@Flag","Insert");

            con.Open();
            int i = sqlCommand.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
       
        public List<Employee> GetList()
        {
            connection();
            List<Employee> employeelist = new List<Employee>();

            SqlCommand cmd = new SqlCommand("sp_InsertUpdateDelete_Employee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag","Select");
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                employeelist.Add(
                    new Employee
                    {
                        EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                        EmployeeName = Convert.ToString(dr["EmployeeName"]),
                        Designation = Convert.ToString(dr["Designation"]),
                        Salary = Convert.ToDecimal(dr["Salary"]),
                        Email = Convert.ToString(dr["Email"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        Qualification = Convert.ToString(dr["Qualification"]),
                        Manager = Convert.ToString(dr["Manager"])
                    });
            }
            return employeelist;
        }
        public bool UpdateDetails(Employee employee)
        {
            connection();
            SqlCommand sqlCmd = new SqlCommand("sp_InsertUpdateDelete_Employee", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            sqlCmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            sqlCmd.Parameters.AddWithValue("@Designation", employee.Designation);
            sqlCmd.Parameters.AddWithValue("@Salary", employee.Salary);
            sqlCmd.Parameters.AddWithValue("@Email", employee.Email);
            sqlCmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
            sqlCmd.Parameters.AddWithValue("@Qualification", employee.Qualification);
            sqlCmd.Parameters.AddWithValue("@Manager", employee.Manager);
            sqlCmd.Parameters.AddWithValue("@Flag","Update");

            con.Open();
            int i = sqlCmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeleteEmployee(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_InsertUpdateDelete_Employee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeId", id);
            cmd.Parameters.AddWithValue("@Flag", "Delete");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}