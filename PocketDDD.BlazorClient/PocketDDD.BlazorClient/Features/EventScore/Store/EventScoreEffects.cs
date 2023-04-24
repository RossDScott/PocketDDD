using Fluxor;
using PocketDDD.BlazorClient.Features.EventScore.Components;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;

namespace PocketDDD.BlazorClient.Features.EventScore.Store;

public class EventScoreEffects
{
    private readonly LocalStorageContext _localStorage;

    public EventScoreEffects(LocalStorageContext localStorage, IDispatcher dispatcher)
    {
        _localStorage = localStorage;
        _localStorage.EventScore.SubscribeToChanges(newScore => 
            dispatcher.Dispatch(new SetEventScoreAction(newScore)));
    }

    [EffectMethod]
    public async Task OnFetchExistingEventScore(FetchExistingEventScoreAction action, IDispatcher dispatcher)
    {
        var eventScore = await _localStorage.EventScore.GetAsync();
        dispatcher.Dispatch(new SetEventScoreAction(eventScore));
    }
}
