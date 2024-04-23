namespace Giveaway.BusinessLogic.PrizeSource;

public interface IPrizeProvider
{
    IList<string> GetPrizes();
}