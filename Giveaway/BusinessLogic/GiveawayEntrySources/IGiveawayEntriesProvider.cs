namespace Giveaway.BusinessLogic.GiveawayEntrySources;

public interface IGiveawayEntriesProvider
{
    Task<IList<GiveawayEntry>> GetEntries();
}