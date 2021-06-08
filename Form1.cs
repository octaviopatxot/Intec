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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            var oSubjectForm = new SubjectForm();
            oSubjectForm.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oStudentForm = new StudentForm();
            oStudentForm.Show();

            this.Hide();
        }
    }
}
