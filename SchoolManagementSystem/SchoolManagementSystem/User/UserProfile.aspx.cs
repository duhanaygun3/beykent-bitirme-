using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static Radar.Models.CommonFn;

namespace Radar.User
{
    public partial class UserProfile : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                string query = "SELECT IdentityNo,Name,SurName,BirthDate,Email,Password,Phone,Address FROM Users Where UserID = '" + userID.Text + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            identity.Text = reader["IdentityNo"].ToString();
                            name.Text = reader["Name"].ToString();
                            surname.Text = reader["SurName"].ToString();
                            password.Text = reader["Password"].ToString();
                            mobileNumber.Text = reader["Phone"].ToString();
                            adress.Text = reader["Address"].ToString();
                            eMail.Text = reader["Email"].ToString();
                            if (reader["BirthDate"] != DBNull.Value)
                            {
                                inputbirthDate.Text = ((DateTime)reader["BirthDate"]).ToString("yyyy-MM-dd");
                            }                          

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(eMail.Text) && !string.IsNullOrEmpty(password.Text) &&
     !string.IsNullOrEmpty(mobileNumber.Text) && !string.IsNullOrEmpty(adress.Text))
            {

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UserProfileUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Email", eMail.Text);
                        command.Parameters.AddWithValue("@MobileNumber", mobileNumber.Text);
                        command.Parameters.AddWithValue("@Adress", adress.Text);
                        command.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Text));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                string message = "Profil güncellendi.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

    }
}