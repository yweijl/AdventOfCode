using Shared;

namespace Year2023.Days;

public class Day1 : Day
{
    protected override int InputDay => 1;

    public Day1(IAdventClient adventClient) : base(adventClient)
    {
    }

    public override async Task<string> ExecuteFirstAsync()
    {
        return (await GetCaloriesPerBackAsync()).Max().ToString();
    }

    public override async Task<string> ExecuteSecondAsync()
    {
        var backpacks = await GetCaloriesPerBackAsync();
        return backpacks.OrderDescending().Take(3).Sum().ToString();
    }

    private async Task<IEnumerable<int>> GetCaloriesPerBackAsync()
    {
        var input = await this.GetInputAsync();
        var totalCarriedCalories = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var biggestBackpack = totalCarriedCalories
            .Select(elf => elf.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Sum(int.Parse));

        return biggestBackpack;
    }
}