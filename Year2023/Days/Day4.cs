using Shared;

namespace Year2023.Days;

public class Day4 : Day
{
    public Day4(bool executeFirst, bool executeSecond, AdventClient adventClient) : base(executeFirst, executeSecond, adventClient)
    {
    }

    protected override int InputDay => 4;
    protected override async Task<string> ExecuteFirstAsync()
    {
        var pairs = (await GetInputAsync())
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(pair =>
                pair.Split(',')
                    .SelectMany(elf => elf.Split('-'))
                    .Select(int.Parse)
                    .ToArray());

        var overlappingAssignments = pairs.Sum(section => 
            section[0] <= section[2] && section[1] >= section[3] || 
            section[2] <= section[0] && section[3] >= section[1]
            ? 1 : 0);

        return overlappingAssignments.ToString();
    }

    protected override async Task<string> ExecuteSecondAsync()
    {
        throw new NotImplementedException();
    }
}