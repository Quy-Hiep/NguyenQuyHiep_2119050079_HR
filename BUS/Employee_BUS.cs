using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BUS
{
    public class Employee_BUS
    {
        Employee_DAL dal = new Employee_DAL();
        public List<Employee_DTO> ReadEmployee()
        {
            List<Employee_DTO> lstNv = dal.ReadEmployee();
            return lstNv;
        }
        public void NewEmployee(Employee_DTO nv)
        {
            dal.NewEmployee(nv);
        }
        public void DeleteEmployee(Employee_DTO nv)
        {
            dal.DeleteEmployee(nv);
        }
        public void EditEmployee(Employee_DTO nv)
        {
            dal.EditEmployee(nv);
        }
    }
}
