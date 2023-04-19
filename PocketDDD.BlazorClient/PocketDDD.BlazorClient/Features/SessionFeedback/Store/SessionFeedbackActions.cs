namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

public record FetchExistingSessionFeedbackAction(int SessionId);
public record SetTimeSlotAlreadyHasFeedbackAction();
public record SetSessionFeedbackAction(Models.SessionFeedback Feedback);
public record SubmitSessionFeedbackAction(Models.SessionFeedback Feedback);
