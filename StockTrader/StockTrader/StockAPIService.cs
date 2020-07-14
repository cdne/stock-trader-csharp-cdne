using Newtonsoft.Json.Linq;
using stock_trader_app_DI_csharp.StockTrader;
using System;
using static stockTrader.StockAPIService;

namespace stockTrader
{
    /// <summary>
    /// Stock price service that gets prices from a remote API
    /// </summary>
    public class StockAPIService : IApiService
    {
        private IUrlReader urlReader;

        public StockAPIService(IUrlReader urlReader)
        {
            this.urlReader = urlReader;
        }

        private static string apiPath = "https://financialmodelingprep.com/api/v3/stock/real-time-price/{0}?apikey=demo";

        /// <summary>
        /// Get stock price from iex
        /// </summary>
        /// <param name="symbol">symbol Stock symbol, for example "aapl"</param>
        /// <returns>the stock price</returns>
        public double GetPrice(string symbol)
        {
            string url = String.Format(apiPath, symbol);
            string result = urlReader.ReadFromUrl(url);
            var json = JObject.Parse(result);
            string price = json.GetValue("price").ToString();
            return double.Parse(price);
        }

        /// <summary>
        /// Buys a share of the given stock at the current price. Returns false if the purchase fails
        /// </summary>
        public bool Buy(string symbol)
        {
            // Stub. No need to implement this.
            return true;
        }

    }
}