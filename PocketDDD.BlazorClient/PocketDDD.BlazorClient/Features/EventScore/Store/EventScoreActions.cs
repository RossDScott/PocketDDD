namespace PocketDDD.BlazorClient.Features.EventScore.Store;

public record FetchExistingEventScoreAction();
public record SetEventScoreAction(int Score);
public record EventScoreUpdatedAction(int Score);
