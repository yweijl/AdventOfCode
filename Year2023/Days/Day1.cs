using Shared;


namespace Year2023.Days;

public class Day1 : Day
{
    protected override int InputDay => 1;

    public Day1(AdventClient adventClient) : base(adventClient)
    {
    }

    public override async Task<string> ExecuteAsync()
    {
        var input = await this.GetInputAsync();
        var totalCarriedCalories = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        
        var biggestBackpack = totalCarriedCalories
            .Select(elf => elf.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Sum(int.Parse))
            .Max().ToString();
        
        return biggestBackpack;
    }
}