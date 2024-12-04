using Shared;

namespace Year2024.Days;

public class Day2 : Day
{
    protected override int DayInput => 2;

    public Day2(IAdventClient adventClient)
        : base(adventClient)
    {
    }

    public override async Task<string> ExecuteFirstAsync()
    {
        var reports = await GetReportsAsync();
        var safeReports = 0;

        foreach (var report in reports)
        {
            if (IsSafeReport(report))
            {
                safeReports++;
            }
        }

        return safeReports.ToString();
    }


    public override async Task<string> ExecuteSecondAsync()
    {
        var reports = await GetReportsAsync();
        var safeReports = 0;

        foreach (var report in reports)
        {
            if (IsSafeReport(report))
            {
                safeReports++;
            }
        }

        return safeReports.ToString();
    }

    private static bool IsSafeReport(int[] report)
    {
        int direction = 0;

        for (int i = 1; i < report.Length; i++)
        {
            var diff = report[i - 1] - report[i];
            var currentDirection = Math.Sign(diff);

            if (diff == 0 || Math.Abs(diff) > 3 ||
                currentDirection == 0 ||
                currentDirection != direction && direction != 0)
            {
                return false;
            }

            direction = currentDirection;
        }

        return true;
    }

    private async Task<IEnumerable<int[]>> GetReportsAsync()
    {
        var input = await GetInputAsync();

        var reports = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray());

        return reports;
    }
}