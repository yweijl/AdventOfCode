using Shared;
using Year2023.Days;

using var client = new AdventClient();

var day1 = new Day1(false,false, client);
await day1.ExecuteAsync();

var day2 = new Day2(false, true, client);
await day2.ExecuteAsync();