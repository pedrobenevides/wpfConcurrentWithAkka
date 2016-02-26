using Akka.Actor;

namespace CocurrentWithAkka.Core.Messages
{
    public class SubscribeToNewStockPriceMessage
    {
        public SubscribeToNewStockPriceMessage(IActorRef subscriber)
        {
            Subscriber = subscriber;
        }

        public IActorRef Subscriber { get; private set; }
    }
}
