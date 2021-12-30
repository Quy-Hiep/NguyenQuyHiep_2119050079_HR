using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class Employee_DAL:DBConnection
    {
        public List<Employee_DTO> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spReadEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee_DTO> lstNv = new List<Employee_DTO>();
            while (reader.Read())
            {
                Employee_DTO nv = new Employee_DTO();
                nv.IdEmployee = reader["IdEmployee"].ToString();
                nv.Name = reader["Name"].ToString();
                nv.DateBirth = DateTime.Parse(reader["DateBirth"].ToString());
                nv.Gender = bool.Parse(reader["Gender"].ToString());
                nv.PlaceBirth = reader["PlaceBirth"].ToString();
                nv.IdDepartment = reader["IdDepartment"].ToString();
                lstNv.Add(nv);
            }
            conn.Close();
            return lstNv;
        }

        public void DeleteEmployee(Employee_DTO nv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spDeleteEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", nv.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewEmployee(Employee_DTO nv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spInsertEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Add(new SqlParameter("@IdEmployee", nv.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", nv.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", nv.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", nv.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", nv.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", nv.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditEmployee(Employee_DTO nv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //khỏi tạo instance của class SqlCommand
            SqlCommand cmd = new SqlCommand();
            //sử dụng thuộc tính CommandText để chỉ định tên Proc
            cmd.CommandText = "spUpdateEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", nv.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", nv.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", nv.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", nv.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", nv.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", nv.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
