namespace Giveaway.BusinessLogic.PrizeSource;

public class InMemoryPrizeProvider :IPrizeProvider
{
    public IList<string> GetPrizes()
    {
        return ["JetBrains Licence 1", "JetBrains Licence 2"];
    }
}