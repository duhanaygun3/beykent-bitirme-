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
    public partial class UserEditDemand : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                userID.Text = Session["UserID"].ToString();
                string url = HttpContext.Current.Request.Url.AbsolutePath;

                string[] urlParts = url.Split('/');
                string lastPart = urlParts[urlParts.Length - 1];

                if (lastPart.StartsWith("DemandId="))
                {
                    string[] demandIdParts = lastPart.Split('=');
                    string demandId = demandIdParts[1]; 
                    demandID.Text = demandId;
                }
                DataTable dt = fn.Fetch("SELECT DemandStatus FROM Demands Where DemandStatus IN (5) and UserID =  '" + userID.Text + "'and DemandId ='" + demandID.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    divDemandAdditional.Visible = true;
                }
                else
                    divDemandAdditional.Visible = false;
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                string query = "SELECT DemandDate,Amount,CompanyName,CompanyAdress,DemandDesc,AdditionalInformation FROM Demands Where UserID =  '" + userID.Text + "'and DemandId ='" + demandID.Text + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            inputDemandDate.Text = ((DateTime)reader["DemandDate"]).ToString("yyyy-MM-dd");
                            inputAmount.Text = reader["Amount"].ToString();
                            inputCompanyName.Text = reader["CompanyName"].ToString();
                            inputCompanyAddress.Text = reader["CompanyAdress"].ToString();
                            inputDemandDesc.Text = reader["DemandDesc"].ToString();
                            inputDemandAdditional.Text = reader["AdditionalInformation"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string DemandAdditional = !string.IsNullOrEmpty(inputDemandAdditional.Text.Trim()) ? inputDemandAdditional.Text.Trim() : null;

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DemandInformationUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DemandID", Convert.ToInt32(demandID.Text));
                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));
                    command.Parameters.AddWithValue("@DemandDate", inputDemandDate.Text.Trim());
                    command.Parameters.AddWithValue("@Amount", inputAmount.Text.Trim());
                    command.Parameters.AddWithValue("@CompanyName", inputCompanyName.Text.Trim());
                    command.Parameters.AddWithValue("@CompanyAdress", inputCompanyAddress.Text.Trim());
                    command.Parameters.AddWithValue("@DemandDesc", inputDemandDesc.Text.Trim());
                    command.Parameters.AddWithValue("@AdditionalInformation", DemandAdditional);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Write("<script>alert('Talep Kaydedildi.')</script>");
            Response.Redirect("/Anasayfa/UserID=" + userID.Text + "");

        }

    }
}