namespace Shared;

using System.Net;

public class AdventOfCodeClient : IDisposable
{
    private readonly HttpClient _client;
    private readonly HttpClientHandler _handler;

    public AdventOfCodeClient()
    {
        var uri = new Uri("https://adventofcode.com");

        var cookieContainer = new CookieContainer();
        cookieContainer.Add(uri, new Cookie("_ga", "GA1.2.397973242.1638869066"));
        cookieContainer.Add(uri, new Cookie("_gid", "GA1.2.752439421.1638869066"));
        cookieContainer.Add(uri, new Cookie("session", "53616c7465645f5f2d37e6deffc39b18a2529b1475ce5b3c928c676a3333065e0c5cbef58531aa04f310945068940937"));

        _handler = new HttpClientHandler() { CookieContainer = cookieContainer };
        _client = new HttpClient(_handler) { BaseAddress = uri };
    }

    public void Dispose()
    {
        _client.Dispose();
        _handler.Dispose();
        
    }

    public async Task<IEnumerable<string>> GetAsync(string endpoint){
        var response = await _client.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();

        return content.Split("\n").Where(x => !string.IsNullOrEmpty(x));
    }
}
