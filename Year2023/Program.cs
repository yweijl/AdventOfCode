using Shared;
using Year2023.Days;

using var client = new AdventClient();

var day1 = new Day1(false,false, client);
await day1.ExecuteAsync();

var day2 = new Day2(false, false, client);
await day2.ExecuteAsync();

var day3 = new Day3(false, false, client);
await day3.ExecuteAsync();

var day4 = new Day4(false, false, client);
await day4.ExecuteAsync();

var day5 = new Day5(true, false, client);
await day5.ExecuteAsync();
    
