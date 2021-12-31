using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Department_DTO
    {
        public string IdDepartment { get; set; }
        public string Name { get; set; }
        public List<Employee_DTO> Employee { get; set; }


    }
}
