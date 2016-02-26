namespace CocurrentWithAkka.Core.Messages
{
    public class UnWatchStockMessage
    {
        public UnWatchStockMessage(string stockSymbol)
        {
            StockSymbol = stockSymbol;
        }

        public string StockSymbol { get; private set; }
    }
}
