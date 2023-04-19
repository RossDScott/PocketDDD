using Fluxor;
using PocketDDD.BlazorClient.Features.Session.Store;

namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

public static class SessionFeedbackReducer
{
    [ReducerMethod]
    public static SessionFeedbackState OnFetchExistingSessionFeedback(SessionFeedbackState state, FetchExistingSessionFeedbackAction action) =>
        state with
        {
            SessionId = action.SessionId,
            TimeSlotAlreadyHasFeedback = false
        };

    [ReducerMethod]
    public static SessionFeedbackState OnSetTimeSlotAlreadyHasFeedback(SessionFeedbackState state, SetTimeSlotAlreadyHasFeedbackAction action) =>
        state with
        {
            TimeSlotAlreadyHasFeedback = true
        };
}
