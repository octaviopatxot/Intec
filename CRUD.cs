using Intec.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intec
{
    public partial class CRUD : Form
    {
        List<StudentDTO> studentDTOs = new List<StudentDTO>();
        StudentDTO studentDTO = new StudentDTO();

        public CRUD()
        {
            InitializeComponent();

            studentDTOs = new List<Models.StudentDTO>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCedula(txtCedula.Text))
            {
                MessageBox.Show("Cedula Invalida");
                return;
            }

            Save();
            ClearForm();
            GetRecords();
        }

        void Save()
        {
            var student = new Models.StudentDTO
            {
                Id = Guid.NewGuid(),
                FirstName = txtFirstname.Text,
                LastName = txtLastname.Text,
                Cedula = txtCedula.Text,
                Gender = cbGender.Text,
                DOB = dtpDOB.Value,
                Age = Helpers.Routines.CalculateAge(dtpDOB.Value.Year)
            };
            studentDTOs.Add(student);
        }

        void GetRecords()
        {
            dgvRecords.DataSource = studentDTOs.Count == 0 ? null : studentDTOs;
        }

        void ClearForm()
        {
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtCedula.Text = string.Empty;
            cbGender.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Now;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        bool CheckCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula)) return false;

            if (cedula.Length < 11) return false;

            return true;
        }

        private void dgvRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           var student = GetRecord(new Guid(dgvRecords.Rows[e.RowIndex].Cells[0].Value.ToString()));

            txtFirstname.Text = student.FirstName;
            txtLastname.Text = student.LastName;
            txtCedula.Text = student.Cedula;
            cbGender.Text = student.Gender;
            dtpDOB.Value = student.DOB;

            btnRemove.Enabled = true;
            btnSave.Enabled = false;
        }

        StudentDTO GetRecord(Guid Id)
        {
            studentDTO = studentDTOs.FirstOrDefault(x => x.Id == Id);

            return studentDTO;
        }

        bool RemoveStudent(StudentDTO student)
        {
           return studentDTOs.Remove(student);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveStudent(studentDTO);
            GetRecords();
            ClearForm();

            btnRemove.Enabled = false;
            btnSave.Enabled = true;
        }
    }
}
