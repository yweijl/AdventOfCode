using Shared;

namespace Year2023.Days;

public abstract class Day
{
    private readonly bool _executeFirst;
    private readonly bool _executeSecond;
    private AdventClient AdventClient { get; }
    protected abstract int InputDay { get; }

    protected Day(bool executeFirst, bool executeSecond, AdventClient adventClient)
    {
        AdventClient = adventClient;
        _executeFirst = executeFirst;
        _executeSecond = executeSecond;
    }

    protected Task<string> GetInputAsync()
    {
        return AdventClient.GetInputAsync(InputDay);
    }

    public async Task ExecuteAsync()
    {
        if (_executeFirst)
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
        }

        if (_executeSecond)
        {
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
    }

    protected abstract Task<string> ExecuteFirstAsync();
    protected abstract Task<string> ExecuteSecondAsync();
}