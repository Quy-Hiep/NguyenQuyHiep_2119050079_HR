using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class Form1 : Form
    {
        Employee_BUS nvBUS = new Employee_BUS();
        Department_BUS DepartmentBUS = new Department_BUS();

        public Form1()
        {
            InitializeComponent();
        }
        private void Employee_GUI_Load(object sender, EventArgs e)
        {
            List<Employee_DTO> lstNv = nvBUS.ReadEmployee();
            foreach (Employee_DTO nv in lstNv)
            {
                dgvEmployee.Rows.Add(nv.IdEmployee, nv.Name, nv.DateBirth, nv.Gender, nv.PlaceBirth, nv.DepamentName);
            }
            List<Department_DTO> lstDepartment = DepartmentBUS.ReadDepartmentList();
            foreach (Department_DTO Department in lstDepartment)
            {
                combodonvi.Items.Add(Department);
            }
            combodonvi.DisplayMember = "Name";

        }
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[idx];
            tbmanv.Text = row.Cells[0].Value.ToString();
            tbhoten.Text = row.Cells[1].Value.ToString();
            dtngaysinh.Text = row.Cells[2].Value.ToString();
            cbgioitinh.Checked = (bool)row.Cells[3].Value;
            tbnoisinh.Text = row.Cells[4].Value.ToString();
            combodonvi.Text = row.Cells[5].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            if (tbmanv.Text == "")
                MessageBox.Show("mã nhân viên không được để trống", "Cảnh Báo");
            else if (tbhoten.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else if (tbnoisinh.Text == "")
                MessageBox.Show("Nơi sinh không được để trống", "Cảnh Báo");
            else
            {
                Employee_DTO nv = new Employee_DTO();
                nv.IdEmployee = tbmanv.Text;
                nv.Name = tbhoten.Text;
                nv.DateBirth = DateTime.Parse(dtngaysinh.Text);
                nv.Gender = cbgioitinh.Checked;
                nv.PlaceBirth = tbnoisinh.Text;
                nv.Department = (Department_DTO)combodonvi.SelectedItem;

                nvBUS.NewEmployee(nv);

                dgvEmployee.Rows.Add(nv.IdEmployee, nv.Name, nv.DateBirth, nv.Gender, nv.PlaceBirth, nv.Department.Name);
            }

        }
        
        private void btnxoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Employee_DTO nv = new Employee_DTO();
                nv.IdEmployee = tbmanv.Text;
                nv.Name = tbhoten.Text;
                nv.DateBirth = DateTime.Parse(dtngaysinh.Text);
                nv.Gender = cbgioitinh.Checked;
                nv.PlaceBirth = tbnoisinh.Text;
                nv.Department = (Department_DTO)combodonvi.SelectedItem;

                nvBUS.DeleteEmployee(nv);

                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbmanv.Text == "")
                MessageBox.Show("mã nhân viên không được để trống", "Cảnh Báo");
            else if (tbhoten.Text == "")
                MessageBox.Show("Tên nhân viên không được để trống", "Cảnh Báo");
            else if (tbnoisinh.Text == "")
                MessageBox.Show("Nơi sinh không được để trống", "Cảnh Báo");
            else
            {
                var confirmResult = MessageBox.Show("Bạn có chắc muốn sửa nhân viên này?",
                         "Cảnh Báo!!",
                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DataGridViewRow row = dgvEmployee.CurrentRow;

                    Employee_DTO nv = new Employee_DTO();
                    nv.IdEmployee = tbmanv.Text;
                    nv.Name = tbhoten.Text;
                    nv.DateBirth = DateTime.Parse(dtngaysinh.Text);
                    nv.Gender = cbgioitinh.Checked;
                    nv.PlaceBirth = tbnoisinh.Text;
                    nv.Department = (Department_DTO)combodonvi.SelectedItem;

                    nvBUS.EditEmployee(nv);

                    row.Cells[0].Value = nv.IdEmployee;
                    row.Cells[1].Value = nv.Name;
                    row.Cells[2].Value = nv.DateBirth;
                    row.Cells[3].Value = nv.Gender;
                    row.Cells[4].Value = nv.PlaceBirth;
                    row.Cells[5].Value = nv.Department.Name;
                }
            }

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có thật sự muốn thoát?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                Close();

        }
    }
}
