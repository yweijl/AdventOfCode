using Shared;

namespace Year2023.Days;

public class Day3 : Day
{
    protected override int InputDay => 3;

    public Day3(IAdventClient adventClient) : base(adventClient)
    {
    }

    public override async Task<string> ExecuteFirstAsync()
    {
        var rucksackItems = await GetInputAsync();
        var priority = rucksackItems.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Sum(rucksack =>
            {
                var compartmentDivider = rucksack.Length / 2;
                var firstCompartment = rucksack[..compartmentDivider];
                var secondCompartment = rucksack[compartmentDivider..];
                var matchingItem = firstCompartment.Intersect(secondCompartment).First();
                return GetPriority(matchingItem);
            });
        return priority.ToString();
    }
    
    public override async Task<string> ExecuteSecondAsync()
    {
        var rucksackItems = await GetInputAsync();
        var elfGroups = rucksackItems.Split('\n', StringSplitOptions.RemoveEmptyEntries).Chunk(3);
        var priority = elfGroups.Sum(group =>
        {
            var batchItem = group[0].Intersect(group[1]).Intersect(group[2]).First();
            return GetPriority(batchItem);
        });
        return priority.ToString();
    }

    private static int GetPriority(char matchingItem)
    {
        return char.IsUpper(matchingItem)
            ? matchingItem - 38
            : matchingItem - 96;
    }
}