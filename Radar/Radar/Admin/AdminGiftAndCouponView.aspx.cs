using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static Radar.Models.CommonFn;

namespace Radar.Admin
{
    public partial class AdminGiftAndCouponView : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");

            }

            if (!IsPostBack)
            {
                GetDemands();
            }
        }

        private void GetDemands()
        {
            DataTable dt = fn.Fetch("SELECT GC.ID, GC.DemandId, GC.Amount, GC.CreationDate, D.CompanyName, CONCAT(U.Name, ' ', U.SurName) AS GiftCreatorAdmin FROM GiftAndCoupons gc INNER JOIN Demands D ON D.DemandId = GC.DemandId INNER JOIN Users U ON U.UserID = GC.CreatedBy");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetDemands();
        }

        protected void btnCompanyNameFilter_Click(object sender, EventArgs e)
        {
            string companyNameFilter = filterCompanyName.Value.Trim();
            DataTable dt = fn.Fetch("SELECT DemandId, DemandDate, Amount, CompanyName, CompanyAdress, DemandDesc, StatusDesc FROM Demands D INNER JOIN DemandStatusDesc DS ON DS.StatusID = D.DemandStatus WHERE CompanyName LIKE '%" + companyNameFilter + "%'");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}