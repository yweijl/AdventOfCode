// See https://aka.ms/new-console-template for more information

using Shared;
using Year2023.Days;

using var client = new AdventClient();

var day1 = new Day1(client);
await day1.ExecuteAsync();

Console.WriteLine(day1);