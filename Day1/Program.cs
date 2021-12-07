using Shared;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var AdventOfCodeClient = new AdventOfCodeClient();
        var x = await AdventOfCodeClient.GetAsync("/2021/day/1/input");
        var list = x.Select(int.Parse).ToList();

        Console.WriteLine($"Answer 1: {Assignment1(list)}");
        Console.WriteLine($"Answer 2: {Assignment2(list)}");
    }

    private static Func<List<int>, int> occurenceCounter = input
        => input.Skip(1).Where((item, index) => item > input[index]).Count();

    private static int Assignment1(List<int> list)
        => occurenceCounter(list);

    private static int Assignment2(List<int> list)
    {
        var sums = list.GetRange(0, list.Count -2).Select((item, index) => item + list[index +1] + list[index +2]).ToList();
        return occurenceCounter(sums);
    }
}