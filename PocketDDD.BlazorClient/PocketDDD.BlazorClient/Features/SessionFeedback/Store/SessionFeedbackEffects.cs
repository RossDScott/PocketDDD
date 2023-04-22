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
        var feedbackItems = await _localStorage.SessionFeedbacks.GetOrDefaultAsync();
        var feedback = feedbackItems.FirstOrDefault(x => x.SessionId == action.SessionId);
        int? timeSlotId = feedback?.TimeSlotId;

        if (feedback is not null)
        {
            dispatcher.Dispatch(new SetSessionFeedbackAction(feedback));
        }

        if (timeSlotId is null)
        {
            var eventData = await _localStorage.EventData.GetAsync();
            timeSlotId = eventData!.Sessions.Single(x => x.Id == action.SessionId).TimeSlotId;
        }

        if (feedbackItems.Any(x => x.SessionId != action.SessionId &&
                                   x.TimeSlotId == timeSlotId))
            dispatcher.Dispatch(new SetTimeSlotAlreadyHasFeedbackAction());
    }

    [EffectMethod]
    public async Task OnSubmitSessionFeedbackAction(SubmitSessionFeedbackAction action, IDispatcher dispatcher)
    {
        var feedback = action.Feedback;

        var eventData = await _localStorage.EventData.GetAsync();
        feedback.TimeSlotId = eventData!.Sessions.Single(x => x.Id == feedback.SessionId).TimeSlotId;
        
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
