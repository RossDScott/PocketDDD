using Fluxor;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;

namespace PocketDDD.BlazorClient.Features.EventScore.Store;

public class EventScoreEffects
{
    private readonly LocalStorageContext _localStorage;

    public EventScoreEffects(LocalStorageContext localStorage)
    {
        _localStorage = localStorage;
    }

    [EffectMethod]
    public async Task OnFetchExistingEventScore(FetchExistingEventScoreAction action, IDispatcher dispatcher)
    {
        var eventScore = await _localStorage.EventScore.GetOrDefaultAsync(() => 0);
        dispatcher.Dispatch(new SetEventScoreAction(eventScore));
    }

    [EffectMethod]
    public async Task OnEventScoreUpdated(EventScoreUpdatedAction action, IDispatcher dispatcher)
    {
        await _localStorage.EventScore.SetAsync(action.Score);
    }
}
