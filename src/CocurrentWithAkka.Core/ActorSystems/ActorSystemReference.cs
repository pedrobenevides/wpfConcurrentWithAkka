using Akka.Actor;
using Akka.DI.Ninject;
using CocurrentWithAkka.Core.ActorModels;
using CocurrentWithAkka.Core.Interfaces;
using Ninject;

namespace CocurrentWithAkka.Core.ActorSystems
{
    public static class ActorSystemReference
    {
        public static ActorSystem ActorSystem { get; private set; }

        static ActorSystemReference()
        {
            CreateActorSystem();
        }

        private static void CreateActorSystem()
        {
            ActorSystem = ActorSystem.Create("ReactiveStockActorSystem");
            ConfigureNinjectBinds();
        }

        private static void ConfigureNinjectBinds()
        {
            var container = new StandardKernel();
            var resolver = new NinjectDependencyResolver(container, ActorSystem);

            container.Bind<IStockPriceServiceGateway>().To<RandomStockPriceServiceGateway>();
            container.Bind<StockPriceLookupActor>().ToSelf();
        }
    }
}
