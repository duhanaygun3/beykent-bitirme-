using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Radar.Models.CommonFn;

namespace Radar.User
{
    public partial class UserHome : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if(!IsPostBack)
            {
                userID.Text = Session["UserID"].ToString();
                GetUserCount();
                GetRadarTotalDemandCount();
                GetUserOpenDemandCount();
            }
        }

        private void GetUserCount()
        {
            DataTable dt = fn.Fetch("SELECT COUNT(*) FROM Users WHERE IsAdmin = 0");
            inputTotalUser.Text = dt.Rows[0][0].ToString();
        }

        private void GetRadarTotalDemandCount()
        {
            DataTable dt = fn.Fetch("SELECT COUNT(*) FROM Demands Where DemandStatus = 3");
            inputTotalRadarConfirmDemand.Text = dt.Rows[0][0].ToString();
        }
        private void GetUserOpenDemandCount()
        {
            DataTable dt = fn.Fetch("SELECT COUNT(*) FROM Demands Where DemandStatus IN (1,2,5) and UserID =" + userID.Text + "");
            inputUserOpenDemandCount.Text = dt.Rows[0][0].ToString();
        }
    }
}