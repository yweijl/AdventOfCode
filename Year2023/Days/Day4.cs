using Shared;

namespace Year2023.Days;

public class Day4 : Day
{
    public Day4(bool executeFirst, bool executeSecond, AdventClient adventClient) : base(executeFirst, executeSecond,
        adventClient)
    {
    }

    protected override int InputDay => 4;

    protected override async Task<string> ExecuteFirstAsync()
    {
        var pairs = await GetPairsAsync();
        var overlappingAssignments = pairs.Sum(_countOverlappingAssignments);
        return overlappingAssignments.ToString();
    }

    private static int _countOverlappingAssignments(int[] sections)
    {
        var left = (start: sections[0], end: sections[1]);
        var right = (start: sections[2], end: sections[3]);

        if (left.start <= right.start && left.end >= right.end ||
            right.start <= left.start && right.end >= left.end)
        {
            return 1;
        }

        return 0;
    }

    private async Task<IEnumerable<int[]>> GetPairsAsync()
    {
        return (await GetInputAsync())
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(pair =>
                pair.Split(',')
                    .SelectMany(elf => elf.Split('-'))
                    .Select(int.Parse)
                    .ToArray());
    }

    protected override async Task<string> ExecuteSecondAsync()
    {
        var pairs = await GetPairsAsync();
        var overlappingSections = pairs.Sum(_countOverlappingSections);

        return overlappingSections.ToString();
    }

    private static int _countOverlappingSections(int[] sections)
    {
        var left = (start: sections[0], end: sections[1]);
        var right = (start: sections[2], end: sections[3]);

        if (left.start < right.start && left.end < right.end && left.end < right.start ||
            left.start > right.start && left.end > right.end && left.start > right.end)
        {
            return 0;
        }

        return 1;
    }
}