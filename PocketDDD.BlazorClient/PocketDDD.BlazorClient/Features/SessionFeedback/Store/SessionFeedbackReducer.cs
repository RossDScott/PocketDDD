using Fluxor;
using PocketDDD.BlazorClient.Features.Session.Store;

namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

public static class SessionFeedbackReducer
{
    [ReducerMethod]
    public static SessionFeedbackState OnDisplaySessionFeedback(SessionFeedbackState state, DisplaySessionFeedbackAction action) =>
    state with
    {
        SessionId = action.SessionId
    };
}
