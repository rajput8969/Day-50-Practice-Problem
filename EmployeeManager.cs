using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeePayRoll
{
    public class EmployeeManager
    {
        public string ConnectionString = @"Data Source=(local);Initial Catalog=EmployeePayRollDB;Integrated Security=True;";
        public List<Employee> GetEmployees()
        {
            SqlConnection con=new SqlConnection(ConnectionString);
            var sqlQuery = "select * from EmployeeTB";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            var reader=cmd.ExecuteReader();
            var employees = new List<Employee>();
            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Gender = reader.GetBoolean(2)?'M':'F',
                    Department = reader.GetString(3),
                    Salary = reader.GetInt32(4),
                    StartDate = reader.GetDateTime(5),
                }) ;
            }
            con.Close();
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            var sqlQuery = $"select * from EmployeeTB where id={id}";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            Employee emp = null;
            while (reader.Read())
            {
                emp=new Employee
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Gender = reader.GetBoolean(2) ? 'M' : 'F',
                    Department = reader.GetString(3),
                    Salary = reader.GetInt32(4),
                    StartDate = reader.GetDateTime(5),
                };
            }
            con.Close();
            return emp;
        }
        public void DeleteEmployeeById(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            var sqlQuery = $"delete from EmployeeTB where id={id}";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
             cmd.ExecuteNonQuery();
            con.Close();
            return;
        }
        public void AddEmployee(Employee emp)
        {
            var value = emp.Gender == 'M' ? 0 : 1;
            SqlConnection con = new SqlConnection(ConnectionString);
            var sqlQuery = $"insert into EmployeeTB(Name,Gender,Department,Salary,StartDate) values('{emp.Name}',{value},'{emp.Department}',{emp.Salary},'{emp.StartDate}')";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

    }
}
