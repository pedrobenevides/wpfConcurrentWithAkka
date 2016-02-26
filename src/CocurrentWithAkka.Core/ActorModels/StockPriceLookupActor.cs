using System;
using Akka.Actor;
using CocurrentWithAkka.Core.Interfaces;
using CocurrentWithAkka.Core.Messages;

namespace CocurrentWithAkka.Core.ActorModels
{
    public class StockPriceLookupActor : ReceiveActor
    {
        private readonly IStockPriceServiceGateway _stockPriceServiceGateway;

        public StockPriceLookupActor(IStockPriceServiceGateway stockPriceServiceGateway)
        {
            _stockPriceServiceGateway = stockPriceServiceGateway;
            Receive<RefreshStockPriceMessage>(msg => LookupStockPrice(msg));
        }

        private void LookupStockPrice(RefreshStockPriceMessage msg)
        {
            var latestPrice = _stockPriceServiceGateway.GetLatestPrice(msg.StockSymbol);
            Sender.Tell(new UpdatedStockPriceMessage(latestPrice, DateTime.Now));
        }
    }
}