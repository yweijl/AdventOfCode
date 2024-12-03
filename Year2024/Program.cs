using Shared;
using Year2024.Days;

using var client = new AdventClient(2024);

var day1 = new Day1(client);
await day1.ExecuteFirstAsync();
var result = await day1.ExecuteSecondAsync();
Console.WriteLine(result);