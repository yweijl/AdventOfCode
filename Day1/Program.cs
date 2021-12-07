using System.Net;

public class Program
{
    public static async Task Main(string[] args)
    {
        var uri = new Uri("https://adventofcode.com");

        var cookieContainer = new CookieContainer();
        cookieContainer.Add(uri, new Cookie("_ga", "GA1.2.397973242.1638869066"));
        cookieContainer.Add(uri, new Cookie("_gid", "GA1.2.752439421.1638869066"));
        cookieContainer.Add(uri, new Cookie("session", "53616c7465645f5f2d37e6deffc39b18a2529b1475ce5b3c928c676a3333065e0c5cbef58531aa04f310945068940937"));

        using var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler) { BaseAddress = uri };

        var response = await client.GetAsync("/2021/day/1/input");
        var content = await response.Content.ReadAsStringAsync();

        var input = content.Split("\n").Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToArray();
        var length = input.Count();


        var answer = Answer1(input, length);
        Console.WriteLine($"Answer 1: {answer}");

        answer = Answer2(input, length);
        Console.WriteLine($"Answer 2: {answer}");
    }

    private static int Answer1(int[] input, int length)
    {
        var answer = 0;
        for (int i = 1; i < length; i++)
        {
            var previusNumber = input[i - 1];
            var curentNumber = input[i];
            if (curentNumber > previusNumber)
            {
                answer++;
            }
        }

        return answer;
    }

    private static int Answer2(int[] input, int length){
        var answer = 0;
        var previousRange = input.Take(3).Sum();

        for (int i = 1; i < length; i++)
        {
            var filterdList = input.Skip(i);
            if (filterdList.Count() < 3){
                break;
            }

            var sum = filterdList.Take(3).Sum();
            if (sum > previousRange){
                answer++;
            }
            previousRange = sum;
        }

        return answer;
    }
}