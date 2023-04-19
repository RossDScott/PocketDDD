using Fluxor;
using MudBlazor;
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
    public async Task OnFetchExistingSessionFeedback(FetchExistingSessionFeedbackAction action, IDispatcher dispatcher)
    {
        var feebackItems = await _localStorage.SessionFeedbacks.GetOrDefaultAsync();
        var feedback = feebackItems.FirstOrDefault(x => x.SessionId == action.SessionId);
        if (feedback is not null)
        {
            dispatcher.Dispatch(new SetSessionFeedbackAction(feedback));

            if (feebackItems.Any(x => x.SessionId != feedback.SessionId &&
                                     x.TimeSlotId == feedback.TimeSlotId))
                dispatcher.Dispatch(new SetTimeSlotAlreadyHasFeedbackAction());
        }
    }

    [EffectMethod]
    public async Task OnSubmitSessionFeedbackAction(SubmitSessionFeedbackAction action, IDispatcher dispatcher)
    {
        var feedback = action.Feedback;
        var feedbackItems = await _localStorage.SessionFeedbacks.GetOrDefaultAsync();
        feedbackItems.RemoveAll(x => x.SessionId == feedback.SessionId);
        feedbackItems.Add(feedback);

        await _localStorage.SessionFeedbacks.SetAsync(feedbackItems);
        var syncItem = new SubmitSessionFeedbackDTO
        {
            CreatedOn = DateTimeOffset.Now,
            SpeakerKnowledgeRating = feedback.SpeakerKnowledgeRating,
            SpeakingSkillRating= feedback.SpeakingSkillRating,
            Comments = feedback.Comments
        };
        await _localStorage.SessionFeedbackSync.AddSyncItemAsync(syncItem, syncItem.ClientId);
    }
}
