using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace CustomMediaProvider
{
    public class MediaProvider : Sitecore.Resources.Media.MediaProvider
    {
        public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
        {
            var originalUrl = base.GetMediaUrl(item, options);
            if (Context.Request == null || !Context.Request.HasHttpContext())
            {
                // Happens in events or jobs running outside of HttpContext
                return originalUrl;
            }
            if (Context.Request.IsSitecoreShellRequest())
            {
                return originalUrl;
            }

            return Helper.TransformUrl(originalUrl, item);
        }

       
    }
}