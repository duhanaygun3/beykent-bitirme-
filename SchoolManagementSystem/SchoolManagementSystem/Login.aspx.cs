using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string ıdentity = inpuIdentity.Value.Trim();
            string password = inputPassword.Value.Trim();
            DataTable dt = fn.Fetch("Select * from Users where IdentityNo = '" + ıdentity + "' and password = '"+password+"' ");
            DataTable db = fn.Fetch("Select * from Users where IdentityNo = '" + ıdentity + "' and password = '" + password + "' and IsAdmin=1");
            if (db.Rows.Count>0)
            {
                Session["admin"] = ıdentity;
                Response.Redirect("Admin/AdminHome.aspx");
            }
            else if (dt.Rows.Count > 0)
            {
                Session["staff"] = ıdentity;
                Response.Redirect("Teacher/TeacherHome.aspx");
            }
            else
            {
                lblMsg.Text = "Login Failed!!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
          
                Response.Redirect("SignUp.aspx");
           
        }
    }
}