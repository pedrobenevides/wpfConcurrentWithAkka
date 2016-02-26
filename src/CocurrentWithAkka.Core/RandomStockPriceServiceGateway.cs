using System;
using CocurrentWithAkka.Core.Interfaces;

namespace CocurrentWithAkka.Core
{
    public class RandomStockPriceServiceGateway : IStockPriceServiceGateway
    {
        private decimal _lastRandomPrice = 20;
        private readonly Random _random = new Random();

        public decimal GetLatestPrice(string stockSymbol)
        {
            var newPrice = _lastRandomPrice + _random.Next(0, 5);

            if (newPrice < 0)
                return _lastRandomPrice = 5;

            if (newPrice > 50)
                return _lastRandomPrice = 45;

            return _lastRandomPrice = newPrice;
        }
    }
}
