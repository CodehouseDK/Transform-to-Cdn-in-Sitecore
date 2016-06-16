using System;
using System.Globalization;
using Sitecore.Data.Items;

namespace CustomMediaProvider
{
    public class Helper
    {
        public static string GetRevision(MediaItem item)
        {
            if (item == null)
            {
                return null;
            }

            var blobId = item.InnerItem["Blob"];

            return !string.IsNullOrEmpty(blobId) ? blobId.GetHashCode().ToString(CultureInfo.InvariantCulture) : "";
        }

        static bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }

        public static string TransformUrl(string url, MediaItem item)
        {
           
            if (!IsAbsoluteUrl(url))
            {
                url = string.Format("http://cdn.yourdomain.com{0}", url);
            }

            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            var builder = new UriBuilder(uri);
            builder.Host = "cdn.yourdomain.com";
            builder.Query = "rev=" + GetRevision(item);
            return builder.ToString().Replace("http:", "").Replace("https:", "").Replace(":80", "");
        }
    }
}
