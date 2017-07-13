using System.Web.Mvc;

namespace Leaf.Web.Areas.Moderation
{
    public class ModerationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Moderation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Moderation_default",
                "Moderation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}