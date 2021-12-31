using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class Department_DAL:DBConnection
    {
        public List<Department_DTO> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Department_DTO> lstDepartment = new List<Department_DTO>();
            while (reader.Read())
            {
                Department_DTO department = new Department_DTO();
                department.IdDepartment = reader["IdDepartment"].ToString();
                department.Name = reader["Name"].ToString();
                lstDepartment.Add(department);
            }
            conn.Close();
            return lstDepartment;
        }
        public Department_DTO ReadDepartment(string id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department where IdDepartment="+"'"+id.ToString()+"'", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            Department_DTO department = new Department_DTO();
            if (reader.HasRows && reader.Read())
            {
                department.IdDepartment = reader["IdDepartment"].ToString();
                department.Name = reader["Name"].ToString();

            }
            conn.Close();
            return department;
        }
    }
}
