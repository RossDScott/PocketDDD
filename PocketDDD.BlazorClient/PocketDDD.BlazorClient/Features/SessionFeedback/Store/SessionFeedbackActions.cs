namespace PocketDDD.BlazorClient.Features.SessionFeedback.Store;

public record DisplaySessionFeedbackAction(int SessionId);
public record SetSessionFeedbackAction(Models.SessionFeedback Feedback);
public record SubmitSessionFeedbackAction(Models.SessionFeedback Feedback);
