﻿using System.Collections.Generic;
using Akka.Actor;
using Akka.DI.Core;
using CocurrentWithAkka.Core.ActorModels;
using CocurrentWithAkka.Core.Messages;

namespace CocurrentWithAkka.Core.ActorSystems
{
    public class StockActor : ReceiveActor
    {
        private readonly string _stockSymbol;
        private readonly HashSet<IActorRef> _subscribers;
        private readonly IActorRef _priceLookupActor;
        private decimal _stockPrice;

        public StockActor(string stockSymbol)
        {
            _stockSymbol = stockSymbol;
            _subscribers = new HashSet<IActorRef>();
            _priceLookupActor = Context.ActorOf(Context.DI().Props<StockPriceLookupActor>());

            Receive<SubscribeToNewStockPriceMessage>(message => _subscribers.Add(message.Subscriber));
            Receive<UnsubscribeFromNewStockPriceMessage>(message => _subscribers.Remove(message.Subscriber));

            Receive<RefreshStockPriceMessage>(message => _priceLookupActor.Tell(message.StockSymbol));
            Receive<UpdatedStockPriceMessage>(message =>
            {
                _stockPrice = message.Price;
                var stockPriceMessage = new StockPriceMessage(_stockSymbol, _stockPrice, message.Date);

                foreach (var subscriber in _subscribers)
                    subscriber.Tell(stockPriceMessage);
            });
        }
    }
}
