using System;

namespace CocurrentWithAkka.Core.Messages
{
    internal class StockPriceMessage
    {
        public DateTime Date { get; set; }
        public decimal StockPrice { get; private set;}
        public string StockSymbol { get; private set;}

        public StockPriceMessage(string stockSymbol, decimal stockPrice, DateTime date)
        {
            StockSymbol = stockSymbol;
            StockPrice = stockPrice;
            Date = date;
        }
    }
}