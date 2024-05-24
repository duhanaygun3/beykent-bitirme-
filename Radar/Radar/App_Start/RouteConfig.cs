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
                "Talep-Olu�tur/{UserID}",
                "~/User/CreateDemand.aspx"
                );
            routes.MapPageRoute("AdminDemandViewRoute",
                "Admin/Talep-G�r�nt�le/{UserID}",
                "~/Admin/AdminDemandView.aspx"
                );
            routes.MapPageRoute("AdminHomeRoute",
                "Admin/Anasayfa/{UserID}",
                "~/Admin/AdminHome.aspx"
                );
            routes.MapPageRoute("DemandViewRoute",
               "Talep-G�r�nt�le/{UserID}",
               "~/User/DemandView.aspx"
               );
            routes.MapPageRoute("AdminDemandTransactionRoute",
                "Talep-��lem/{UserID}",
                "~/Admin/AdminDemandTransaction.aspx"
                );
            routes.MapPageRoute("GiftAndCouponView",
                "Hediye-Kuponu-G�r�nt�le/{UserID}",
                "~/User/GiftAndCouponView.aspx"
                );
            routes.MapPageRoute("AdminGiftAndCouponView",
               "Admin/Hediye-Kuponu-G�r�nt�le/{UserID}",
               "~/Admin/AdminGiftAndCouponView.aspx"
               );
            routes.MapPageRoute("UserEditDemand",
                "Talep-D�zenle/{UserID}/{DemandId}",
                "~/User/UserEditDemand.aspx"
                );


        }
    }
}