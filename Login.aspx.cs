
using System;
using System.Data.SqlClient;
using System.Configuration;
namespace SiddhaHospitalManagement
{

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT Role FROM Users WHERE Email = @Email AND PasswordHash = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Hash password in real application

                object role = cmd.ExecuteScalar();

                if (role != null)
                {
                    Session["UserRole"] = role.ToString(); // Store role in session
                    Session["UserEmail"] = txtEmail.Text; // Store email for future use

                    if (role.ToString() == "Doctor")
                        Response.Redirect("DoctorDashboard.aspx");
                    else if (role.ToString() == "Admin")
                        Response.Redirect("AdminDashboard.aspx");
                    else if (role.ToString() == "Receptionist")
                        Response.Redirect("ReceptionistDashboard.aspx");
                    else 
                        Response.Redirect("PatientDashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}

