namespace CocurrentWithAkka.Core.Messages
{
    public class RefreshStockPriceMessage
    {
        public string StockSymbol { get; private set; }

        public RefreshStockPriceMessage(string stockSymbol)
        {
            StockSymbol = stockSymbol;
        }
    }
}
