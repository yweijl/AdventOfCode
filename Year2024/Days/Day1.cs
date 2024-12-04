using Shared;

namespace Year2024.Days;

public class Day1 : Day
{
    protected override int DayInput => 1;

    public Day1(IAdventClient adventClient)
        : base(adventClient)
    {
    }

    public override async Task<string> ExecuteFirstAsync()
    {
        var (firstArray, secondArray) = await GetLocationIdsAsync();
        return firstArray.Zip(secondArray, (a, b) => Math.Abs(a - b)).Sum().ToString();
    }

    public override async Task<string> ExecuteSecondAsync()
    {
        var (firstArray, secondArray) = await GetLocationIdsAsync();
        var secondArrayCounts = secondArray
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
        var sum = 0;

        foreach (var first in firstArray)
        {
            if (secondArrayCounts.TryGetValue(first, out var count))
            {
                sum += count * first;
            }
        }

        return sum.ToString();
    }

    private async Task<(int[], int[])> GetLocationIdsAsync()
    {
        var input = await GetInputAsync();
        var firstList = new List<int>();
        var secondList = new List<int>();

        foreach (var parts in input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)))
        {
            firstList.Add(int.Parse(parts[0]));
            secondList.Add(int.Parse(parts[1]));
        }

        firstList.Sort();
        secondList.Sort();

        return (firstList.ToArray(), secondList.ToArray());
    }
}