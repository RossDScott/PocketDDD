using Fluxor;
using PocketDDD.BlazorClient.Features.Sync.Store;
using PocketDDD.BlazorClient.Services;
using PocketDDD.Shared.API.RequestDTOs;
using System.Collections.ObjectModel;

namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

public class EventFeedbackEffects
{
    private readonly IState<SessionFeedbackState> _state;
    private readonly LocalStorageService _localStorage;

    public EventFeedbackEffects(IState<SessionFeedbackState> state, IDispatcher dispatcher, LocalStorageService localStorage)
    {
        _state = state;
        _localStorage = localStorage;
    }

    [EffectMethod]
    public async Task OnDisplaySessionFeedback(DisplaySessionFeedbackAction action, IDispatcher dispatcher)
    {
        var feebackItems = await _localStorage.SessionFeedbacks.GetOrDefaultAsync(() => new Collection<Models.SessionFeedback>());
        var feedback = feebackItems.FirstOrDefault(x => x.SessionId == action.SessionId);
        if (feedback is not null)
            dispatcher.Dispatch(new SetSessionFeedbackAction(feedback));

        //todo show dialog
    }

    //[EffectMethod]
    //public async Task OnSubmitEventFeedback(SubmitEventFeedbackAction action, IDispatcher dispatcher)
    //{
    //    var feedback = action.Feedback;
    //    await _localStorage.EventFeedback.SetAsync(feedback);
    //    var syncItem = new SubmitEventFeedbackDTO
    //    {
    //        CreatedOn = DateTimeOffset.Now,
    //        Refreshments = feedback.Refreshments,
    //        Venue = feedback.Venue,
    //        Overall = feedback.Overall,
    //        Comments = feedback.Comments
    //    };
    //    await _localStorage.EventFeedbackSync.AddSyncItemAsync(syncItem, syncItem.ClientId);
    //}
}
