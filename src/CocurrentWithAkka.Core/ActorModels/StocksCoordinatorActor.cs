using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using CocurrentWithAkka.Core.ActorSystems;
using CocurrentWithAkka.Core.Messages;

namespace CocurrentWithAkka.Core.ActorModels
{
    public class StocksCoordinatorActor : ReceiveActor
    {
        private readonly IActorRef _chartingActor;
        private readonly IDictionary<string, IActorRef> _stockActors; 

        public StocksCoordinatorActor(IActorRef chartingActor)
        {
            _chartingActor = chartingActor;
            _stockActors = new Dictionary<string, IActorRef>();

            Receive<WatchStockMessage>(message => WatchStock(message));
            Receive<UnWatchStockMessage>(message => UnWatchStock(message));
        }

        private void UnWatchStock(UnWatchStockMessage message)
        {
            if(_stockActors[message.StockSymbol] == null) return;

            _stockActors[message.StockSymbol].Tell(new UnsubscribeFromNewStockPriceMessage(_chartingActor));
        }

        private void WatchStock(WatchStockMessage message)
        {
            var childActorNeedsCreating = !_stockActors.ContainsKey(message.StockSymbol);

            if (childActorNeedsCreating)
            {
                var newChildActor = Context.ActorOf(Props.Create(() => new StockActor(message.StockSymbol)),
                    $"StockActor_{message.StockSymbol}");

                _stockActors.Add(message.StockSymbol, newChildActor);
            }

            _stockActors[message.StockSymbol].Tell(new SubscribeToNewStockPriceMessage(_chartingActor));
        }
    }
}
