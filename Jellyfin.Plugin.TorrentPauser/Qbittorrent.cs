using System.Net.Http;
using System.Threading.Tasks;

namespace Jellyfin.Plugin.TorrentPauser
{
    public class Qbittorrent
    {
        private static Qbittorrent _instance;
        private string _sid;

        public Qbittorrent()
        {
        }

        public Qbittorrent GetInstance()
        {
            if (_instance == null)
                _instance = new Qbittorrent();

            return _instance;
        }

        public async Task<HttpResponseMessage> Authenticate()
        {
            return await Utils.MakeRequest(
                    Plugin.Instance.Configuration.QBittorrent_Url,
                    Constants.Request_Login
                );
        }
    }
}
