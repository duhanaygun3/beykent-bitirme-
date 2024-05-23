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
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            userID.Text = Session["UserID"].ToString();

            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                string query = "SELECT IdentityNo,Name,SurName,Email,Password,Phone,Address FROM Users Where UserID = '" + userID.Text + "'";

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

    }
}