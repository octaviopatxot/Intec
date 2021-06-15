using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            List<StudentModel> students = AllStudents();
            return View(students);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        List<StudentModel> AllStudents()
        {
            string connString = "Server=OCTAVIO-LAPTOP;Database=INTEC;User Id=intec;Password=intec;";
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_student", sqlConnection);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<StudentModel> studentModels = new List<StudentModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StudentModel studentModel = new StudentModel();
                    studentModel.Id = new Guid(dt.Rows[i]["Id"].ToString());
                    studentModel.Seq = Convert.ToInt32(dt.Rows[i]["Seq"]);
                    studentModel.FirstName = dt.Rows[i]["FirstName"].ToString();
                    studentModel.LastName = dt.Rows[i]["LastName"].ToString();
                    studentModel.NickName = dt.Rows[i]["Nickname"].ToString();
                    studentModel.DayOfBirth = Convert.ToDateTime(dt.Rows[i]["DayOfBirth"].ToString());
                    studentModel.Email = dt.Rows[i]["Email"].ToString();
                    studentModel.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                    studentModel.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"].ToString());

                    studentModels.Add(studentModel);
                }

               return studentModels;
            }
        }
    }
}