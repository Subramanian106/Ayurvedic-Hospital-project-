using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiddhaHospitalManagement
{
    public partial class MyAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            string connStr = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT U.Username AS DoctorName, A.AppointmentDate, A.AppointmentTime, A.Status " +
                               "FROM Appointments A INNER JOIN Users U ON A.DoctorID = U.UserID " +
                               "WHERE A.PatientID = @PatientID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientID", Session["UserID"]);

                SqlDataReader reader = cmd.ExecuteReader();
                gvMyAppointments.DataSource = reader;
                gvMyAppointments.DataBind();
            }
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress("hospital@example.com");
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("your_email@gmail.com", "your_password");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        // Call this after a successful booking
       

    }
}
