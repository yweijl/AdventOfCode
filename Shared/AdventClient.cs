﻿using System.Net;
using Microsoft.Extensions.Configuration;

namespace Shared;

public class AdventClient : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public static async Task<string> GetInputAsync(int day)
    {
        var endpoint = new Uri($"https://adventofcode.com/2022/day/{day}/input", UriKind.Absolute);

        string? input = null;

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
}