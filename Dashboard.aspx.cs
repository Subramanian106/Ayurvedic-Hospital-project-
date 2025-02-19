using System;
namespace SiddhaHospitalManagement
{ 

public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblUserName.Text = Session["UserRole"].ToString();
                lblUserRole.Text = Session["UserRole"].ToString();
            }
        }
    }

}