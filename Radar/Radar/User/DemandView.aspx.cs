using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static Radar.Models.CommonFn;

namespace Radar.User
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
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        // Satır verilerini al
                        string demandId = GridView1.DataKeys[row.RowIndex].Value.ToString();

                        // Butonu bul
                        Button btnEditDemand = (Button)row.FindControl("btnEditDemand");

                        // Butonun aktiflik durumunu belirle
                        btnEditDemand.Enabled = IsDemandEditable(demandId); // Talep düzenlenebilir mi?
                    }
                }
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

            GridView1.DataBind(); // GridView'ı yeniden bağla

            // Butonların durumunu güncelle
            UpdateButtonStatus();
        }
        protected void btnAllDemands_Click(object sender, EventArgs e)
        {
            DataTable dt = fn.Fetch("SELECT DemandId, DemandDate, Amount, CompanyName, CompanyAdress, DemandDesc, StatusDesc FROM Demands D INNER JOIN DemandStatusDesc DS ON DS.StatusID = D.DemandStatus");
            GridView1.DataSource = dt;
            GridView1.DataBind();

            // Butonların durumunu güncelle
            UpdateButtonStatus();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditDemand")
            {
                int demandId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
                DataTable dt = fn.Fetch("SELECT * FROM Demands WHERE DemandId = " + demandId + " AND UserId = " + userID.Text);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("/Talep-Düzenle/UserID=" + userID.Text + "/DemandId=" + demandId + "");
                }
                else
                    Response.Write("<script>alert('Farklı kullanıcı talebi düzenlenemez!')</script>");
            }
        }

        // Veritabanından talep durumunu kontrol eden bir metod
        private bool IsDemandEditable(string demandId)
        {
            // Bu metod, gerçek bir veritabanı sorgusu veya başka bir yöntem kullanarak talep durumunu kontrol eder.
            // Örneğin, talep durumu "Beklemede" ise düzenlenebilir olarak kabul edilebilir.

            bool isEditable = false;

            // Örnek olarak, talep durumu "Beklemede" ise düzenlenebilir olarak kabul edelim.
            // Gerçek uygulamada, bu durum belki de bir veritabanı sorgusu veya başka bir durum kontrolüyle belirlenir.
            bool demandStatus = GetDemandStatusFromDatabase(demandId); // Veritabanından talep durumunu al

            if (demandStatus)
            {
                isEditable = true;
            }

            return isEditable;
        }

        // Veritabanından talep durumunu getiren bir metod
        private bool GetDemandStatusFromDatabase(string demandId)
        {
            DataTable dt = fn.Fetch("SELECT DemandStatus FROM Demands Where DemandStatus IN(1,2,5) and DemandId = '" + demandId + "' ");
            if (dt.Rows.Count > 0)
                return true;
            else return false;
        }
        private void UpdateButtonStatus()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    // Satır verilerini al
                    string demandId = GridView1.DataKeys[row.RowIndex].Value.ToString();

                    // Butonu bul
                    Button btnEditDemand = (Button)row.FindControl("btnEditDemand");

                    // Butonun aktiflik durumunu belirle
                    btnEditDemand.Enabled = IsDemandEditable(demandId); // Talep düzenlenebilir mi?
                }
            }
        }
    }
}