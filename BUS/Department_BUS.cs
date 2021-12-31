using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class Department_BUS
    {
        Department_DAL dal = new Department_DAL();
        public List<Department_DTO> ReadDepartmentList()
        {
            List<Department_DTO> lstDepartment = dal.ReadDepartmentList();
            return lstDepartment;
        }
    }
}
