namespace PocketDDD.BlazorClient.Features.EventFeedback.Store;

public record LoadExistingEventFeedbackAction();
public record SetEventFeedbackAction(Models.EventFeedback Feedback);
public record SubmitEventFeedbackAction(Models.EventFeedback Feedback);
