namespace Shared;

public interface IAdventClient
{
    public Task<string> GetInputAsync(int day);
}
    
