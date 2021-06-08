using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intec
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            getStudent();
        }

        void getStudent()
        {
            string connString = "Server=OCTAVIO-LAPTOP;Database=INTEC;User Id=intec;Password=intec;";
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_student", sqlConnection);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add("@Seq", SqlDbType.Int).Value = 1;

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStudent.DataSource = dt;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gbEdit.Enabled = true;
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}