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
        public Form1()
        {
            InitializeComponent();
        }
        private void Employee_GUI_Load(object sender, EventArgs e)
        {
            List<Employee_DTO> lstNv = nvBUS.ReadEmployee();
            foreach (Employee_DTO nv in lstNv)
            {
                dgvEmployee.Rows.Add(nv.IdEmployee, nv.Name, nv.DateBirth, nv.Gender, nv.PlaceBirth, nv.IdDepartment);
            }
        }
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbmanv.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
            tbhoten.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
            dtngaysinh.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
            cbgioitinh.Checked = (bool)dgvEmployee.Rows[idx].Cells[3].Value;
            tbnoisinh.Text = dgvEmployee.Rows[idx].Cells[4].Value.ToString();
            combodonvi.Text = dgvEmployee.Rows[idx].Cells[5].Value.ToString();
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
                nv.IdDepartment = combodonvi.Text;

                nvBUS.NewEmployee(nv);

                dgvEmployee.Rows.Add(nv.IdEmployee, nv.Name, nv.DateBirth, nv.Gender, nv.PlaceBirth, nv.IdDepartment);


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
                nv.IdDepartment = combodonvi.Text;

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
                    nv.IdDepartment = combodonvi.Text;

                    nvBUS.EditEmployee(nv);

                    row.Cells[0].Value = nv.IdEmployee;
                    row.Cells[1].Value = nv.Name;
                    row.Cells[2].Value = nv.DateBirth;
                    row.Cells[3].Value = nv.Gender;
                    row.Cells[4].Value = nv.PlaceBirth;
                    row.Cells[5].Value = nv.IdDepartment;
                }
            }

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                Close();

        }
    }
}
