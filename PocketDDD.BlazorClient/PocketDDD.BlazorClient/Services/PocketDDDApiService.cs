using PocketDDD.Shared.API.ResponseDTOs;

namespace PocketDDD.BlazorClient.Services;

public interface IPocketDDDApiService
{
    Task<LoginResult> Login(string name);
}

public class PocketDDDApiService : IPocketDDDApiService
{
    private readonly HttpClient _http;

    public PocketDDDApiService(HttpClient http)
    {
        _http = http;
    }

    public Task<LoginResult> Login(string name)
    {
        throw new NotImplementedException();
    }
}

public class FakePocketDDDApiService : IPocketDDDApiService
{
    public Task<LoginResult> Login(string name)
    {
        return Task.FromResult(new LoginResult(name, Guid.NewGuid().ToString()));
    }
}