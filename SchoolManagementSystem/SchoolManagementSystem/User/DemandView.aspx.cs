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
    public partial class DemandView : System.Web.UI.Page
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
            DataTable dt = fn.Fetch("SELECT DemandId,DemandDate,Amount,CompanyName,CompanyAdress,DemandDesc,StatusDesc FROM Demands D INNER JOIN DemandStatusDesc DS ON DS.StatusID=D.DemandStatus WHERE D.UserID = '" + userID.Text + "'");
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
        protected void btnAllDemands_Click(object sender, EventArgs e)
        {
            DataTable dt = fn.Fetch("SELECT DemandId, DemandDate, Amount, CompanyName, CompanyAdress, DemandDesc, StatusDesc FROM Demands D INNER JOIN DemandStatusDesc DS ON DS.StatusID = D.DemandStatus");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}