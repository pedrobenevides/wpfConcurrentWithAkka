namespace CocurrentWithAkka.Core.Messages
{
    public class WatchStockMessage
    {
        public string StockSymbol { get; private set; }

        public WatchStockMessage(string stockSymbol1)
        {
            StockSymbol = stockSymbol1;
        }
    }
}
