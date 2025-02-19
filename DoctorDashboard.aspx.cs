using SiddhaHospitalManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace SiddhaHospitalManagement
{
    public partial class DoctorDashboard : System.Web.UI.Page
    {
             // protected void Page_Load(object sender, EventArgs e)


      int selectedAppointmentID = 0; // Default value
        protected void Page_Load(object sender, EventArgs e)
        {
            object userId = Session["UserID"];
            if (userId == null)
            {
                string connStr = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT A.AppointmentID, U.Username AS PatientName, A.AppointmentDate, " +
                                   "A.AppointmentTime, A.Status " +
                                   "FROM Appointments A INNER JOIN Users U ON A.PatientID = U.UserID " +
                                   "WHERE A.DoctorID = @DoctorID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DoctorID", userId.ToString());

                        SqlDataReader reader = cmd.ExecuteReader();
                        gvAppointments.DataSource = reader;
                        gvAppointments.DataBind();
                    }
                }
            }
            else
            {
                // Redirect to login if the session is null
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
         {
           UpdateAppointmentStatus("Approved");
         }

        protected void btnReject_Click(object sender, EventArgs e)
          {
             UpdateAppointmentStatus("Rejected");
          }

        private void UpdateAppointmentStatus(string status)
         {
            string connStr = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
           {
             conn.Open();
             string query = "UPDATE Appointments SET Status = @Status WHERE AppointmentID = @AppointmentID";
             SqlCommand cmd = new SqlCommand(query, conn);
             cmd.Parameters.AddWithValue("@Status", status);
             cmd.Parameters.AddWithValue("@AppointmentID", selectedAppointmentID);
             cmd.ExecuteNonQuery();
            }
         }
        protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve" || e.CommandName == "Reject")
            {
                string newStatus = e.CommandName == "Approve" ? "Approved" : "Rejected";
                int appointmentID = Convert.ToInt32(e.CommandArgument);

                string connStr = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE Appointments SET Status = @Status WHERE AppointmentID = @AppointmentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session and redirect to login page
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }


    }
}

