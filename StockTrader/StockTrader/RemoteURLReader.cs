using stock_trader_app_DI_csharp.StockTrader;

using System.Net;

namespace stockTrader
{
    public class RemoteURLReader : IUrlReader
    {
        public string ReadFromUrl(string endpoint)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(endpoint);
            }
        }
    }
}