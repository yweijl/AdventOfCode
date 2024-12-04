using Shared;

namespace Runner
{
    public static class DayFactory
    {
        public static async Task <string> GetAnswerAsync(int year, int day, Part part, IAdventClient adventClient)
        {
            var typeName = $"Year{year}.Days.Day{day}, Year{year}";
            var type = Type.GetType(typeName) 
                ?? throw new ArgumentException($"Type {typeName} not found.");

            if (Activator.CreateInstance(type, adventClient) is not Day instance)
            {
                throw new InvalidOperationException($"Could not create an instance of {typeName}.");
            }

            var result = await instance.ExecuteFunctionAsync(part);
            Console.WriteLine($"The result for {year}-{day}-{part} is: {result}");
            return result;
        }

        private static async Task<string> ExecuteFunctionAsync(this Day day, Part part)
        {
            var functionName = part == Part.first ? "ExecuteFirstAsync" : "ExecuteSecondAsync";
            var method = day.GetType().GetMethod(functionName) 
                ?? throw new ArgumentException($"Method {functionName} not found in {day.GetType().Name}.");
            
            var result = method.Invoke(day, null) as Task<string> 
                ?? throw new InvalidOperationException($"Method {functionName} did not return a Task<string>.");
            
            return await result;
        }
    }
}
