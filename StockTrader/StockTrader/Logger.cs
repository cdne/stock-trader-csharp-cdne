using stock_trader_app_DI_csharp.StockTrader;
using System;
using System.IO;

namespace stockTrader
{
    public class Logger : ILogger
    {
        public void Log(string message) {
            var msg = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " + message;
            Console.WriteLine(msg);
            try
            {
                using (var fileWriter = File.AppendText("log.txt"))  {
                    fileWriter.WriteLine(msg);
                }    
            }
            catch (IOException e) {
                Console.WriteLine("Log file write failed :( " + e);
            }

        }        
    }
}