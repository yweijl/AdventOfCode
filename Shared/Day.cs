namespace Shared;

public abstract class Day
{
    private IAdventClient AdventClient { get; }
    protected abstract int DayInput { get; }

    protected Day(IAdventClient adventClient)
    {
        AdventClient = adventClient;
    }

    protected Task<string> GetInputAsync()
    {
        return AdventClient.GetInputAsync(DayInput);
    }

    public abstract Task<string> ExecuteFirstAsync();
    public abstract Task<string> ExecuteSecondAsync();
}