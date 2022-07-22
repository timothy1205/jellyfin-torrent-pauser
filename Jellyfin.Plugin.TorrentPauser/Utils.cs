using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Jellyfin.Plugin.TorrentPauser
{
    public class Utils
    {
        public static string FormatUrl(string url, string request, string parameters)
        {
            return string.Format("{0}/{1}?{2}", url, request, parameters);
        }

        public static string FormatUrl(string url, string request)
        {
            return string.Format("{0}/{1}", url, request);
        }

        public static async Task<HttpResponseMessage> MakeRequest(string url, string request, string parameters)
        {
            var httpClient = Plugin.Instance.GetHttpClient();
            HttpContent content = new FormUrlEncodedContent(Enumerable.Empty<KeyValuePair<string, string>>());

            if (parameters.Equals(""))
                return await httpClient.PostAsync(FormatUrl(url, request), content);
            else
                return await httpClient.PostAsync(FormatUrl(url, request, parameters), content);
        }

        public static async Task<HttpResponseMessage> MakeRequest(string url, string request)
        {
            return await MakeRequest(url, request, "");
        }
    }
}
