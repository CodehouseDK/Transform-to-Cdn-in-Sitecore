using System;

namespace CustomMediaProvider
{
    public static class UriExtensions
    {
     
        public static bool HasAssetPath(this Uri uri)
        {
            var pathAndQuery = uri.IsAbsoluteUri ? uri.PathAndQuery : uri.ToString();

            var isAssetRequest = pathAndQuery.IndexOf("/~/media/", StringComparison.OrdinalIgnoreCase) > -1 ||
                                 pathAndQuery.IndexOf("/-/media/", StringComparison.OrdinalIgnoreCase) > -1 ||
                                 pathAndQuery.IndexOf("/design/", StringComparison.OrdinalIgnoreCase) > -1 ||
                                 pathAndQuery.IndexOf("/scripts/", StringComparison.OrdinalIgnoreCase) > -1 ||
                                 pathAndQuery.IndexOf("/?css=1", StringComparison.OrdinalIgnoreCase) > -1 ||
                                 pathAndQuery.StartsWith("/upload/contentTemplating/",
                                     StringComparison.OrdinalIgnoreCase);
            return isAssetRequest;
        }
    }
}