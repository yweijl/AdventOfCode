using System.Text;
using Shared;

namespace Year2023.Days;

public class Day5 : Day
{
    protected override int InputDay => 5;

    public Day5(bool executeFirst, bool executeSecond, AdventClient adventClient) : base(executeFirst, executeSecond,
        adventClient)
    {
    }

    protected override async Task<string> ExecuteFirstAsync()
    {
        var (stacks, rearrangementProcedure)
            = await GetStartingStacksAndProceduresAsync();

        RearrangeStacks(rearrangementProcedure, stacks);

        return string.Join("",
            stacks.SelectMany(x => x.First().ToString()));
    }

    private static void RearrangeStacks(IEnumerable<int[]> rearrangementProcedure, List<char>[] stacks)
    {
        foreach (var procedure in rearrangementProcedure)
        {
            // move x from y to z
            var crateAmount = procedure[0];
            var from = procedure[1] - 1;
            var to = procedure[2] - 1;
            PrintState(crateAmount, from, to, stacks, true);

            var movingCrates = stacks[from].Take(crateAmount).Reverse().ToList();
            stacks[from].RemoveRange(0, crateAmount);
            stacks[to].InsertRange(0, movingCrates);

            PrintState(crateAmount, from, to, stacks, false);
        }
    }

    private async Task<(List<char>[], IEnumerable<int[]>)> GetStartingStacksAndProceduresAsync()
    {
        var input = (await GetInputAsync()).Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        var stacks = GetStartingStacks(input[0]);
        var rearrangementProcedure = GetRearrangementProcedure(input[1]);
        return (stacks, rearrangementProcedure);
    }

    private static void PrintState(int crateAmount, int from, int to, IReadOnlyList<List<char>> stacks, bool initial)
    {
        var movedCrates = initial
            ? string.Join(" ", stacks[from].GetRange(0, crateAmount))
            : string.Join(" ", stacks[to].GetRange(0, crateAmount));

        var sb = new StringBuilder();
        sb.AppendLine($"move {crateAmount} crates: {movedCrates} ");
        sb.AppendLine();
        sb.AppendLine($"{(initial ? " Initial" : " New State")}");
        sb.AppendLine($" {from + 1} ---- {to + 1}");
        for (var i = 0; i < Math.Max(stacks[from].Count, stacks[to].Count); i++)
        {
            var fromIndexExists = i < stacks[from].Count;
            var toIndexExists = i < stacks[to].Count;
            sb.AppendLine($" {(fromIndexExists ? stacks[from][i] : " ")} ---- {(toIndexExists ? stacks[to][i] : " ")}  ");
        }

        Console.WriteLine(sb.ToString());
    }

    private IEnumerable<int[]> GetRearrangementProcedure(string instructionsString)
    {
        var instructions = instructionsString.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(instruction =>
            instruction.Replace("move ", "").Replace(" from ", " ").Replace(" to ", " ")
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
        );
        return instructions;

    }

    protected override async Task<string> ExecuteSecondAsync()
    {
        throw new NotImplementedException();
    }

    private static List<char>[] GetStartingStacks(string startingStackString)
    {
        var startingStacks = startingStackString.Split('\n');
        var stackLength = (startingStacks[0].Length + 3) / 4;

        var stacks = new List<char>[stackLength];
        for (var i = 0; i < stackLength; i++)
        {
            stacks[i] = new List<char>();
        }

        for (int i = 0, n = stackLength - 1; i < n; i++)
        {
            var stackLine = startingStacks[i];
            var stackIndex = 0;
            for (int j = 0, m = stackLine.Length - 1; j < m; j++)
            {
                var crate = stackLine[j];
                if (j % 4 != 1) continue;

                if (!char.IsWhiteSpace(crate))
                {
                    stacks[stackIndex].Add(crate);
                }
                stackIndex++;
            }
        }

        return stacks;
    }
}