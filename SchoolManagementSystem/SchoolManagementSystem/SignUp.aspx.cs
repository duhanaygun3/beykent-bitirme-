using Radar.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Radar.Models.CommonFn;

namespace Radar
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
            string birthDate = inputBirthDate.Value.Trim();
            DateTime birthDateYear = DateTime.Parse(inputBirthDate.Value);
            int year = birthDateYear.Year;
            bool status;
            if (password != checkPassword)
            {
                lblMsg.Text = "�ifreler birbiri ile uyu�muyor";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                Response.Write("<script>alert('�ifreler birbiri ile uyu�muyor')</script>");

            }
            else
            {
                try
                {
                    using (IdentityValidation.KPSPublicSoapClient identityService = new IdentityValidation.KPSPublicSoapClient())
                    {
                        long identityNumber;
                        if (long.TryParse(identity, out identityNumber))
                        {
                            // D�n���m ba�ar�l� ise, T.C. Kimlik Numaras�n� kullanarak do�rulamay� yapabilirsiniz
                            status = identityService.TCKimlikNoDogrula(identityNumber, name, surName, year);
                            if (status)
                            {
                                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    using (SqlCommand command = new SqlCommand("UserSignUp", connection))
                                    {
                                        command.CommandType = CommandType.StoredProcedure;

                                        // Di�er parametreleri ekleyin
                                        command.Parameters.AddWithValue("@Name", name);
                                        command.Parameters.AddWithValue("@Surname", surName);
                                        command.Parameters.AddWithValue("@Identitiy", identity);
                                        command.Parameters.AddWithValue("@Password", password);
                                        command.Parameters.AddWithValue("@Email", email);
                                        command.Parameters.AddWithValue("@BirthDate", birthDate);

                                        connection.Open();
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                lblMsg.Text = reader["Result"].ToString();
                                            }
                                            reader.Close();
                                            // E�er sonu�lar varsa
                                            if (lblMsg.Text == "Kay�t ba�ar�yla eklendi.")
                                            {
                                                Response.Redirect("Login.aspx");
                                                Response.Write("<script>alert('" + lblMsg.Text + "')</script>");
                                            }
                                            else
                                            {
                                                lblMsg.Text = "Bu TC Kimlik Numaras�na sahip bir kullan�c� zaten mevcut.";
                                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                            }
                                        }
                                    }
                                }
                            }

                            else
                            {
                                lblMsg.Text = "Girilen bilgiler, kimlik bilgileri ile uyu�muyor!";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}