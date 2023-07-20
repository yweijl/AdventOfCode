using System.Net;
using Microsoft.Extensions.Configuration;

namespace Shared;

public class AdventClient : IDisposable
{
    private static Uri Uri => new Uri("https://adventofcode.com/2022/day/1/input");

    public async Task<string?> GetInputAsync()
    {
        string? input = null;

        using var handler = new HttpClientHandler();
        using var httpClient = new HttpClient(handler);
        try
        {
            var cookieContainer = new CookieContainer();
            var cookie = new Cookie("session", GetSessionCookieValue());
            cookieContainer.Add(Uri, cookie);
            handler.CookieContainer = cookieContainer;

            var response = await httpClient.GetAsync(Uri);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return input!;
    }

    private static string GetSessionCookieValue()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<AdventClient>();

        IConfiguration configuration = builder.Build();

        // Session Cookie stored in UserSecrets
        return configuration["SessionCookie"]!;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}