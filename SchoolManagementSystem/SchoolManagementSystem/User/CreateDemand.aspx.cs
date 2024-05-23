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
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.User
{
    public partial class CreateDemand : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            // hdnUserID.Value = Session["UserID"].ToString();
            //userID.Text = Session["UserID"].ToString();

            userID.Text = Session["UserID"].ToString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        protected void btnCreateDemand_Click(object sender, EventArgs e)
        {
            string demandDate = inputDemandDate.Text.Trim();
            string amount = inputAmount.Text.Trim();
            string companyName = inputCompanyName.Text.Trim();
            string companyAdress = inputCompanyAddress.Text.Trim();
            string demandDesc = inputDemandDesc.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateDemand", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));
                    command.Parameters.AddWithValue("@DemandDate", demandDate);
                    command.Parameters.AddWithValue("@Amount", Convert.ToDecimal(amount));
                    command.Parameters.AddWithValue("@CompanyName", companyName);
                    command.Parameters.AddWithValue("@CompanyAdress", companyAdress);
                    command.Parameters.AddWithValue("@DemandDesc", demandDesc);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Write("<script>alert('Talep Oluşturuldu.')</script>");


            //Response.Redirect("Login.aspx");
        }

    }
}