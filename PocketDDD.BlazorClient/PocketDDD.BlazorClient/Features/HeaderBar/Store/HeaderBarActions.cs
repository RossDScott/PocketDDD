namespace PocketDDD.BlazorClient.Features.HeaderBar.Store;

public record SetHeaderBarTitleAction(string Title);
public record SetBackButtonVisabilityAction(bool Visable);
public record ViewFeedbackAction();
public record NavigateBackAction();
