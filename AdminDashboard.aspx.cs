using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiddhaHospitalManagement
{
	public partial class AdminDashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx"); // Redirect to login if not a Admin
            }
            lblDoctorName.Text = "Logged in as: " + Session["UserEmail"].ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Clear session
            Response.Redirect("Login.aspx");
        }

    }
	
}