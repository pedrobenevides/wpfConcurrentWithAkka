using System.Collections.Generic;
using Akka.Actor;
using CocurrentWithAkka.Core.Messages;

namespace CocurrentWithAkka.Core.ActorSystems
{
    public class StockActor : ReceiveActor
    {
        private readonly string _stockSymbol;
        private readonly HashSet<IActorRef> _subscribers; 

        public StockActor(string stockSymbol)
        {
            _stockSymbol = stockSymbol;
            _subscribers = new HashSet<IActorRef>();

            Receive<SubscribeToNewStockPriceMessage>(message => _subscribers.Add(message.Subscriber));
            Receive<UnsubscribeFromNewStockPriceMessage>(message => _subscribers.Remove(message.Subscriber));
        }
    }
}
