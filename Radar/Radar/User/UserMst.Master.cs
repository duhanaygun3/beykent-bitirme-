using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Radar.User
{
    public partial class UserMst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hdnUserID.Value=Session["UserID"].ToString();
            //userID.Text = Session["UserID"].ToString();
            if (!IsPostBack)
            {
                // Örnek kullanıcı kimliği
                string userId = GetUserId();
                HomePage.HRef = $"/Anasayfa/UserID={userId}";
                createDemand.HRef = $"/Talep-Oluştur/UserID={userId}";
                demandView.HRef = $"/Talep-Görüntüle/UserID={userId}";
                giftAndCoupnView.HRef = $"/Hediye-Kuponu-Görüntüle/UserID={userId}";
                UserProfile.HRef = $"/Profil/UserID={userId}";
            }
        }

        private string GetUserId()
        {
            // Burada kullanıcı kimliğini alma mantığınızı ekleyin
            // Örnek olarak sabit bir değer döndürüyorum
            
            return Session["UserID"].ToString(); ; // Örneğin: Session["UserId"] ile alınabilir
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}