using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.User
{
    public partial class GiftAndCouponView : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");

            }

            if (!IsPostBack)
            {
                userID.Text = Session["UserID"].ToString();
                GetDemands();
            }
        }

        private void GetDemands()
        {
            DataTable dt = fn.Fetch("SELECT GC.ID, GC.DemandId, GC.Amount, GC.CreationDate, D.CompanyName, CONCAT(U.Name, ' ', U.SurName) AS GiftCreatorAdmin FROM GiftAndCoupons gc INNER JOIN Demands D ON D.DemandId = GC.DemandId INNER JOIN Users U ON U.UserID= '" + userID.Text + "'");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetDemands();
        }
    }
}