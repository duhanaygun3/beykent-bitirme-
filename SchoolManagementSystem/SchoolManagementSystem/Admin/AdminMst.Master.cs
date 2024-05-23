using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Admin
{
    public partial class AdminMst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hdnUserID.Value=Session["UserID"].ToString();
            //userID.Text = Session["UserID"].ToString();
            if (!IsPostBack)
            {
                // Örnek kullanıcı kimliği
                string userId = GetUserId();
                adminDemandView.HRef = $"/Admin/Talep-Görüntüle/UserID={userId}";
                adminDemandTransaction.HRef = $"/Talep-İşlem/UserID={userId}";
                adminGiftAndCouponView.HRef = $"/Admin/Hediye-Kuponu-Görüntüle/UserID={userId}";
                adminHome.HRef = $"/Admin/Anasayfa/UserID={userId}";
                AdminProfile.HRef = $"/Admin/Profil/UserID={userId}";
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }

        private string GetUserId()
        {
            // Burada kullanıcı kimliğini alma mantığınızı ekleyin
            // Örnek olarak sabit bir değer döndürüyorum

            return Session["UserID"].ToString(); ; // Örneğin: Session["UserId"] ile alınabilir
        }
    }
}