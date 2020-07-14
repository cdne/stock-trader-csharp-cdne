namespace stock_trader_app_DI_csharp.StockTrader
{
    public interface IApiService
    {
        double GetPrice(string symbol);

        bool Buy(string symbol);
    }
}