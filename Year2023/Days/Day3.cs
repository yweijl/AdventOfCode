using Shared;

namespace Year2023.Days;

public class Day3 : Day
{
    protected override int InputDay => 3;

    public Day3(bool executeFirst, bool executeSecond, AdventClient adventClient) : base(executeFirst, executeSecond,
        adventClient)
    {
    }

    protected override async Task<string> ExecuteFirstAsync()
    {
        var rucksackItems = await GetInputAsync();
        var priority = rucksackItems.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Sum(rucksack =>
            {
                var compartmentDivider = rucksack.Length / 2;
                var firstCompartment = rucksack[..compartmentDivider];
                var secondCompartment = rucksack[compartmentDivider..];
                var matchingItem = firstCompartment.Intersect(secondCompartment).First();

                return char.IsUpper(matchingItem)
                    ? matchingItem - 38
                    : matchingItem - 96;
            });
        return priority.ToString();
    }

    protected override Task<string> ExecuteSecondAsync()
    {
        throw new NotImplementedException();
    }
}