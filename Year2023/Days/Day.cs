using System.Runtime.CompilerServices;
using Shared;

namespace Year2023.Days;

public abstract class Day
{
    private AdventClient AdventClient { get; }
    protected abstract int InputDay { get; }

    protected Day(AdventClient adventClient)
    {
        AdventClient = adventClient;
    }

    protected Task<string> GetInputAsync()
    {
        return AdventClient.GetInputAsync(InputDay);
    }

    public async Task ExecuteAsync()
    {
        try
        {
            var first = await ExecuteFirstAsync();
            Console.WriteLine($"Part-1 of {GetType().Name}: {first}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Part-1 of {GetType().Name} failed {e}");
            throw;
        }

        try
        {
            var second = await ExecuteSecondAsync();
            Console.WriteLine($"Part-2 of {GetType().Name}: {second}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Part-2 of {GetType().Name} failed {e}");
            throw;
        }


    }

    protected abstract Task<string> ExecuteFirstAsync();
    protected abstract Task<string> ExecuteSecondAsync();
}