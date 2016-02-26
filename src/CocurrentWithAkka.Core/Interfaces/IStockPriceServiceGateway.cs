namespace CocurrentWithAkka.Core.Interfaces
{
    public interface IStockPriceServiceGateway
    {
        decimal GetLatestPrice(string stockSymbol);
    }
}
