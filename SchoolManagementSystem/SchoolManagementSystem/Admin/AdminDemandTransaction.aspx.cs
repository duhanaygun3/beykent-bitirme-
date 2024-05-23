using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class AdminDemandTransaction : System.Web.UI.Page
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
                userID.Text = Session["UserID"].ToString();
            }
        }

        private void GetDemands()
        {
            DataTable dt = fn.Fetch("SELECT DemandId,DemandDate,Amount,CompanyName,CompanyAdress,DemandDesc,StatusDesc FROM Demands D INNER JOIN DemandStatusDesc DS ON DS.StatusID=D.DemandStatus");
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DemandReview")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string demandStatus = "2";

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DemandStatusUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                        command.Parameters.AddWithValue("@DemandID", Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]));
                        command.Parameters.AddWithValue("@DemandStatus", demandStatus);// Örnek bir parametre ekleme
                        command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Daha sonra istediðiniz iþlemleri gerçekleþtirebilirsiniz
                // Örneðin, bir mesaj kutusu göstermek için:
                string message = "Stored Procedure çalýþtýrýldý.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
                // GridView'i yeniden yükleme gibi baþka iþlemler de yapýlabilir
            }
            if (e.CommandName == "DemandApproval")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string demandStatus = "3";

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DemandStatusUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                        command.Parameters.AddWithValue("@DemandID", Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]));
                        command.Parameters.AddWithValue("@DemandStatus", demandStatus);
                        command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Daha sonra istediðiniz iþlemleri gerçekleþtirebilirsiniz
                // Örneðin, bir mesaj kutusu göstermek için:
                string message = "Stored Procedure çalýþtýrýldý.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);

                // GridView'i yeniden yükleme gibi baþka iþlemler de yapýlabilir
            }
            if (e.CommandName == "DemandRejection")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string demandStatus = "4";

               // int test = Convert.ToInt32( GridView1.Rows[rowIndex].Cells[0].Text);
               // int test2 = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);


                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DemandStatusUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                        command.Parameters.AddWithValue("@DemandID", Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]));
                        command.Parameters.AddWithValue("@DemandStatus", demandStatus);// Örnek bir parametre ekleme
                        command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Daha sonra istediðiniz iþlemleri gerçekleþtirebilirsiniz
                // Örneðin, bir mesaj kutusu göstermek için:
                string message = "Stored Procedure çalýþtýrýldý.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);

                // GridView'i yeniden yükleme gibi baþka iþlemler de yapýlabilir
            }
            if (e.CommandName == "DemandAdditional")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string demandStatus = "5";

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DemandStatusUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                        command.Parameters.AddWithValue("@DemandID", Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]));
                        command.Parameters.AddWithValue("@DemandStatus", demandStatus);// Örnek bir parametre ekleme
                        command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Daha sonra istediðiniz iþlemleri gerçekleþtirebilirsiniz
                // Örneðin, bir mesaj kutusu göstermek için:
                string message = "Stored Procedure çalýþtýrýldý.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);

                // GridView'i yeniden yükleme gibi baþka iþlemler de yapýlabilir
            }
        }

    }
}