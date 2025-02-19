using System;
using System.Data.SqlClient;
using System.Configuration;
namespace SiddhaHospitalManagement
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "")
            {
                lblMessage.Text = "Please select a role.";
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["SiddhaHospitalDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO Users (FullName, Email, PasswordHash, Role) VALUES (@FullName, @Email, @Password, @Role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Hash password in real app
                cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

                try
                {
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Registration successful! You can now login.";
                }
                catch (Exception )
                {
                    lblMessage.Text = "you have already Registred ,pls Login.";
                }
            }
        }
    }
}