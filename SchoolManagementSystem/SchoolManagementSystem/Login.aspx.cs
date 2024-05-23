using SchoolManagementSystem.Admin;
using SchoolManagementSystem.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
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
            DataTable dt = fn.Fetch("Select UserID from Users where IdentityNo = '" + ıdentity + "' and password = '"+password+"' ");
            DataTable db = fn.Fetch("Select UserID from Users where IdentityNo = '" + ıdentity + "' and password = '" + password + "' and IsAdmin=1");
            if (dt.Rows.Count <= 0)
            {
                lblMsg.Text = "Hatalı Giriş!!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                var hdnUserID = dt.Rows[0][0];
                if (db.Rows.Count > 0)
                {
                    Session["admin"] = ıdentity;
                    Session["UserId"] = hdnUserID;
                    Response.Redirect("/Admin/Anasayfa/UserID=" + hdnUserID + "");


                }
                else if (dt.Rows.Count > 0)
                {
                    Session["staff"] = ıdentity;
                    Session["UserId"] = hdnUserID;
                    Response.Redirect("/Anasayfa/UserID=" + hdnUserID + "");
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
          
                Response.Redirect("SignUp.aspx");
           
        }
    }
}