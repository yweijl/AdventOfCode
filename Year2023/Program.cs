using Shared;
using Year2023.Days;

using var client = new AdventClient(2023);

var day1 = new Day1(client);
await day1.ExecuteFirstAsync();
await day1.ExecuteSecondAsync();

var day2 = new Day2(client);
await day2.ExecuteFirstAsync();
await day2.ExecuteSecondAsync();

var day3 = new Day3(client);
await day3.ExecuteFirstAsync();
await day3.ExecuteSecondAsync();

var day4 = new Day4(client);
await day4.ExecuteFirstAsync();
await day4.ExecuteSecondAsync();

var day5 = new Day5(client);
await day5.ExecuteFirstAsync();
await day5.ExecuteSecondAsync();