using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Radar.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("HomeRoute",
                "Anasayfa/{UserID}",
                "~/User/UserHome.aspx"
                );
            routes.MapPageRoute("UserProfile",
                "Profil/{UserID}",
                "~/User/UserProfile.aspx"
                );
            routes.MapPageRoute("AdminProfile",
                "Admin/Profil/{UserID}",
                "~/Admin/AdminProfile.aspx"
                );
            routes.MapPageRoute("DemandRoute",
                "Talep-Oluþtur/{UserID}",
                "~/User/CreateDemand.aspx"
                );
            routes.MapPageRoute("AdminDemandViewRoute",
                "Admin/Talep-Görüntüle/{UserID}",
                "~/Admin/AdminDemandView.aspx"
                );
            routes.MapPageRoute("AdminHomeRoute",
                "Admin/Anasayfa/{UserID}",
                "~/Admin/AdminHome.aspx"
                );
            routes.MapPageRoute("DemandViewRoute",
               "Talep-Görüntüle/{UserID}",
               "~/User/DemandView.aspx"
               );
            routes.MapPageRoute("AdminDemandTransactionRoute",
                "Talep-Ýþlem/{UserID}",
                "~/Admin/AdminDemandTransaction.aspx"
                );
            routes.MapPageRoute("GiftAndCouponView",
                "Hediye-Kuponu-Görüntüle/{UserID}",
                "~/User/GiftAndCouponView.aspx"
                );
            routes.MapPageRoute("AdminGiftAndCouponView",
               "Admin/Hediye-Kuponu-Görüntüle/{UserID}",
               "~/Admin/AdminGiftAndCouponView.aspx"
               );
            routes.MapPageRoute("UserEditDemand",
                "Talep-Düzenle/{UserID}/{DemandId}",
                "~/User/UserEditDemand.aspx"
                );


        }
    }
}