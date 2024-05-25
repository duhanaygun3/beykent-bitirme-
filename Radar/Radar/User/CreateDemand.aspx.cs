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
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateDemand", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));
                    command.Parameters.AddWithValue("@DemandDate", inputDemandDate.Text.Trim());
                    command.Parameters.AddWithValue("@Amount", inputAmount.Text.Trim());
                    command.Parameters.AddWithValue("@CompanyName", inputCompanyName.Text.Trim());
                    command.Parameters.AddWithValue("@CompanyAdress", inputCompanyAddress.Text.Trim());
                    command.Parameters.AddWithValue("@DemandDesc", inputDemandDesc.Text.Trim());

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblMsg.Text = reader["Result"].ToString();
                        }
                        reader.Close();
                        // Eğer sonuçlar varsa
                        if (lblMsg.Text == "Talep oluşturuldu.")
                        {
                            Response.Write("<script>alert('" + lblMsg.Text + "')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('" + lblMsg.Text + "')</script>");
                        }
                    }
                }
            }
        }

    }
}