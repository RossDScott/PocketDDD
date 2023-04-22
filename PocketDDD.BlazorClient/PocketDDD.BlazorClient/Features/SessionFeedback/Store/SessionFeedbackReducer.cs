using Fluxor;
using PocketDDD.BlazorClient.Features.Session.Store;

namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

public static class SessionFeedbackReducer
{
    [ReducerMethod]
    public static SessionFeedbackState OnSetSessionDetails(SessionFeedbackState state, SetSessionDetailsAction action) =>
        state with
        {
            SessionTitle = action.SessionTitle,
            SpeakerName = action.SpeakerName,
            TimeSlotAlreadyHasFeedback = false
        };

    [ReducerMethod]
    public static SessionFeedbackState OnSetTimeSlotAlreadyHasFeedback(SessionFeedbackState state, SetTimeSlotAlreadyHasFeedbackAction action) =>
        state with
        {
            TimeSlotAlreadyHasFeedback = true
        };
}
