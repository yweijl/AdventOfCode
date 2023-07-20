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

    public abstract Task<string> ExecuteFirstAsync();
    public abstract Task<string> ExecuteSecondAsync();
}