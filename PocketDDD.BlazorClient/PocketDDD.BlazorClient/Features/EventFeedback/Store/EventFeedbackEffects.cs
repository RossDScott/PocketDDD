using Fluxor;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;

namespace PocketDDD.BlazorClient.Features.EventFeedback.Store;

public class EventFeedbackEffects
{
    private readonly IState<EventFeedbackState> _state;
    private readonly LocalStorageService _localStorage;

    public EventFeedbackEffects(IState<EventFeedbackState> state, IDispatcher dispatcher, LocalStorageService localStorage)
    {
        _state = state;
        _localStorage = localStorage;

        _localStorage.SubscribeToSyncItem(LocalStorageService.Key_EventFeedbackPrefix,
            () => dispatcher.Dispatch(new SubmitSyncItemsAction()));
    }

    [EffectMethod]
    public async Task OnLoadExistingEventFeedback(LoadExistingEventFeedbackAction action, IDispatcher dispatcher)
    {
        var feedback = await _localStorage.GetEventFeedback();
        if (feedback is not null)
            dispatcher.Dispatch(new SetEventFeedbackAction(feedback));
    }

    [EffectMethod]
    public async Task OnSubmitEventFeedback(SubmitEventFeedbackAction action, IDispatcher dispatcher)
    {
        var feedback = action.Feedback;
        await _localStorage.SetEventFeedback(feedback);
        var syncItem = new SubmitEventFeedbackDTO
        {
            CreatedOn = DateTimeOffset.Now,
            Refreshments = feedback.Refreshments,
            Venue = feedback.Venue,
            Overall = feedback.Overall,
            Comments = feedback.Comments
        };
        await _localStorage.AddEventFeedbackSyncItem(syncItem);
        //dispatcher.Dispatch(new SubmitSyncItemsAction());
    }
}
