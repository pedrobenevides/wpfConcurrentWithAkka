using System;

namespace CocurrentWithAkka.Core.Messages
{
    public class UpdatedStockPriceMessage
    {
        public UpdatedStockPriceMessage(decimal price, DateTime date)
        {
            Price = price;
            Date = date;
        }

        public decimal Price { get; private set; }
        public DateTime Date { get; private set; }
    }
}
