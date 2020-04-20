using System;

namespace WebsiteManagement.Domain.ValueObjects
{
    public static class CreateWebsiteUrl
    {
        public static bool IsValidUrl(this string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
         }
    }
}
