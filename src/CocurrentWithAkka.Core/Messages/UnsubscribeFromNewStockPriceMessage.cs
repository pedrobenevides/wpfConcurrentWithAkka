using Akka.Actor;

namespace CocurrentWithAkka.Core.Messages
{
    public class UnsubscribeFromNewStockPriceMessage
    {
        public UnsubscribeFromNewStockPriceMessage(IActorRef subscriber)
        {
            Subscriber = subscriber;
        }

        public IActorRef Subscriber { get; private set; }
    }
}
