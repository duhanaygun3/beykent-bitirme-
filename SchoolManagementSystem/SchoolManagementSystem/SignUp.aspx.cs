using SchoolManagementSystem.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem
{
    public partial class SignUp : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string name = inputName.Value.Trim();
            string surName = inputSurName.Value.Trim();
            string identity = inputIdentity.Value.Trim();
            string password = inputPassword.Value.Trim();
            string checkPassword = inputCheckPassword.Value.Trim();
            string email = inputEmail.Value.Trim();
            if (password != checkPassword)
            {
                lblMsg.Text = "Þifreler birbiri ile uyuþmuyor";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                Response.Write("<script>alert('Þifreler birbiri ile uyuþmuyor')</script>");

            }
            else if (identity.Length !=11)
            {
                lblMsg.Text = "T.C Kimlik No hatalý !";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                Response.Write("<script>alert('Þifreler birbiri ile uyuþmuyor')</script>");
            }
            else
            {
                //fn.Query(@"Insert into Users values ('" + name + "'," +
                //" '" + surName + "'," +
                //" '" + identity + "'," +
                //" '" + email + "'," +
                //" '" + null + "'," +
                //" '" + password + "'," +
                //" '" + 0 + "'," +
                //" '" + DateTime.Now.ToString("yyyy/MM/dd") + "'," +
                //" '" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                //Response.Redirect("Login.aspx");
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UserSignUp", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Stored Procedure'a gerekli parametreleri ekleyebilirsiniz
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surName);
                        command.Parameters.AddWithValue("@Identitiy", identity);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Daha sonra istediðiniz iþlemleri gerçekleþtirebilirsiniz
                // Örneðin, bir mesaj kutusu göstermek için:
                string message = "Baþarýyla kayýt edildi.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
                Response.Redirect("Login.aspx");
            }
        }
        }
    }