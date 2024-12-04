using System.Net;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Shared;

public class AdventClient : IAdventClient, IDisposable
{
    private readonly int year;

    public AdventClient(int year)
    {
        this.year = year;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<string> GetInputAsync(int day)
    {
        var directory = Path.Combine(GetSolutionDirectory(), $"Inputs", $"{year}");
        Directory.CreateDirectory(directory);
        var input = Path.Combine(directory, $"Day-{day}");
        if (File.Exists(input))
        {
            return File.ReadAllText(input);
        }

        var endpoint = new Uri($"https://adventofcode.com/{year}/day/{day}/input", UriKind.Absolute);

        using var handler = new HttpClientHandler();
        using var httpClient = new HttpClient(handler);
        try
        {
            var cookieContainer = new CookieContainer();
            var cookie = new Cookie("session", GetSessionCookieValue());
            cookieContainer.Add(endpoint, cookie);
            handler.CookieContainer = cookieContainer;

            var response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            File.WriteAllText(input, responseBody);
            return responseBody;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Error fetching input for day {day}: {ex.Message}");
        }
    }

    private static string GetSessionCookieValue()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<AdventClient>();

        IConfiguration configuration = builder.Build();

        // Session Cookie stored in UserSecrets
        return configuration["SessionCookie"]!;
    }

    private string GetSolutionDirectory()
    {
        var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        return Directory.GetParent(exePath!)!.Parent!.Parent!.FullName;
    }
}
