using System;
using System.Data.SqlClient;
using System.Configuration;
namespace SiddhaHospitalManagement
{

    public partial class BookAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctors();
            }
        }

        private void LoadDoctors()
        {
            string connStr = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT UserID, Username FROM Users WHERE UserType='Doctor'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlDoctors.DataSource = reader;
                    ddlDoctors.DataTextField = "Username";
                    ddlDoctors.DataValueField = "UserID";
                    ddlDoctors.DataBind();
                }
            }
        }

        protected void btnBookAppointment_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SiddhaDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, AppointmentTime) " +
                               "VALUES (@PatientID, @DoctorID, @AppointmentDate, @AppointmentTime)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientID", Session["UserID"]);
                cmd.Parameters.AddWithValue("@DoctorID", ddlDoctors.SelectedValue);
                cmd.Parameters.AddWithValue("@AppointmentDate", calAppointmentDate.SelectedDate);
                cmd.Parameters.AddWithValue("@AppointmentTime", txtAppointmentTime.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                lblMessage.Text = (rowsAffected > 0) ? "Appointment booked successfully!" : "Error booking appointment.";
            }
        }
    }
}
