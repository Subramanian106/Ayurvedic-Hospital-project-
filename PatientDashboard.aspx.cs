using SiddhaHospitalManagement;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace SiddhaHospitalManagement
{
    public partial class PatientDashboard : System.Web.UI.Page

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
            // Get database connection string
            string connStr = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Ensure UserID is available in the session
                object userID = Session["UserID"];
                if (userID == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect if session is null
                    return;
                }

                // SQL query to fetch patient’s appointments
                string query = "SELECT A.AppointmentID, U.Username AS DoctorName, A.AppointmentDate, A.AppointmentTime, A.Status " +
                               "FROM Appointments A " +
                               "INNER JOIN Users U ON A.DoctorID = U.UserID " +
                               "WHERE A.PatientID = @PatientID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Pass the patient ID from session
                    cmd.Parameters.AddWithValue("@PatientID", userID.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();
                    gvAppointments.DataSource = reader;
                    gvAppointments.DataBind();
                }
            }
        }
        protected GridView gvAppointments;


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Clear session
            Response.Redirect("Login.aspx"); // Redirect to login page
        }
    }
}
