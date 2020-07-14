using stock_trader_app_DI_csharp.StockTrader;
using System;

namespace stockTrader
{
    internal class TradingApp
    {
        private readonly ILogger logger;
        private readonly ITrader trader;
        private readonly IUrlReader urlReader;
        private readonly IApiService apiService;

        public TradingApp(ILogger logger, ITrader trader, IUrlReader urlReader, IApiService apiService)
        {
            this.logger = logger;
            this.trader = trader;
            this.urlReader = urlReader;
            this.apiService = apiService;
        }

        public static void Main(string[] args)
        {
            ILogger logger = new Logger();
            IUrlReader urlReader = new RemoteURLReader();
            IApiService apiService = new StockAPIService(urlReader);
            ITrader trader = new Trader(logger,apiService);

            TradingApp app = new TradingApp(logger, trader, urlReader, apiService) ;
            app.Start();
        }

        public void Start()
        {
            Console.WriteLine("Enter a stock symbol (for example aapl):");
            string symbol = Console.ReadLine();
            Console.WriteLine("Enter the maximum price you are willing to pay: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please enter a number.");
            }

            try
            {
                bool purchased = trader.Buy(symbol, price);
                if (purchased)
                {
                    logger.Log("Purchased stock!");
                }
                else
                {
                    logger.Log("Couldn't buy the stock at that price.");
                }
            }
            catch (Exception e)
            {
                logger.Log("There was an error while attempting to buy the stock: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}