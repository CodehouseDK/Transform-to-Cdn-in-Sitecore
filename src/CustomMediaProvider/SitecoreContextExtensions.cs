using System.Web;
using Sitecore;
using Sitecore.Sites;

namespace CustomMediaProvider
{
    public static class SitecoreContextExtensions
    {
        public static bool IsSitecoreShellRequest(this SiteRequest request)
        {
            return Context.GetSiteName() == "shell";
        }

        public static bool HasHttpContext(this SiteRequest request)
        {
            return HttpContext.Current != null;
        }
    }
}